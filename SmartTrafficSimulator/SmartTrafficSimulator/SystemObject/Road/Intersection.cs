using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SmartTrafficSimulator.SystemObject;
using System.Windows.Forms;
using System.Collections;
using Optimization;
using SmartTrafficSimulator.SystemManagers;
using SmartTrafficSimulator.OptimizationModels.OptimizationAdjustment;

namespace SmartTrafficSimulator.SystemObject
{
    public class Intersection
    {
        int SIGNAL_GREEN = 0, SIGNAL_YELLOW = 1, SIGNAL_RED = 2, SIGNAL_TEMPRED = 3;

        //intersection profile
        public int intersectionID = -1;
        public string intersectionName = "default";
        public int currentCycle = 0; //以ConfigNo 0 結束紅燈時算一個cycle

        int minGreen = 30;
        int maxGreen = 90;
        Boolean cycleLengthFixed = false;

        //List of roads
        public List<Road> roadList = new List<Road>();

        //List of adjacent intersections
        public List<Intersection> adjacentIntersectionsList = new List<Intersection>();

        //Signal config and state
        public List<SignalConfig> signalConfigList;
        public List<int[]> signalStatusList; //[0] = state , [1] = current second
       
        //Signal config for next ues
        public List<SignalConfig> nextConfig;

        //End time of each cycle
        public List<int> cycleEneTime;


        //Traffic Optimization
        TrafficOptimization TO;
        double currentIAWR = 0;
        public int latestOptimizationCycle;
        public double optimizationThreshold_IAWR;
        public int optimizationInterval_Cycle;

        double lowTrafficIAWR = 50;
        double mediumTrafficIAWR = 70;

        //Adaptive Optimization
        AdaptiveAdjustment AA;
        int stability;
        int minOptimizationInterval = 5;
        int maxOptimizationInterval = 40;

        public Intersection(int intersectionID)
        {
            this.intersectionID = intersectionID;
        }

        public void Initialize()
        {
            //Initial signal config
            signalConfigList = new List<SignalConfig>();
            signalStatusList = new List<int[]>();

            //Initial optimization setting
            optimizationInterval_Cycle = Simulator.IntersectionManager.defaultOptimizeInterval;
            optimizationThreshold_IAWR = Simulator.IntersectionManager.defaultIAWR;

            latestOptimizationCycle = 0;
            currentCycle = 0;
            stability = 0;

            TO = new TrafficOptimization(minGreen, maxGreen, cycleLengthFixed);
            AA = new AdaptiveAdjustment();

            //Register to DM
            Simulator.DataManager.RegisterIntersection(intersectionID);
            cycleEneTime = new List<int>();
        }

        public void AddComposedRoad(int roadID)
        {
            Road addedRoad = Simulator.RoadManager.GetRoadByID(roadID);
            addedRoad.belongsIntersection = this;
            addedRoad.connectIntersection = this;
            this.roadList.Add(addedRoad);
        }

        public void EstablishAdjacentIntersectionInfo()
        {
            string results = "Intersection : " + intersectionID + ", adjacent intersection : ";
            foreach (Road road in roadList)
            {
                foreach (int conID in road.connectedRoadIDList)
                {
                    Road connectedRoad = Simulator.RoadManager.GetRoadByID(conID);
                    if (connectedRoad.fromIntersection == null)
                    {
                        connectedRoad.fromIntersection = this;
                    }

                    Intersection adjInte = connectedRoad.belongsIntersection;
                    if (adjInte != null && !adjacentIntersectionsList.Contains(adjInte))
                    { 
                        adjacentIntersectionsList.Add(adjInte);
                        results += adjInte.intersectionID + " ";
                    }
                }
            }

            if(Simulator.TESTMODE)
                Simulator.UI.AddMessage("System", results);
        }

        public void AddNewSignalSetting(SignalConfig newConfig)
        {
            signalConfigList.Add(newConfig);

            CalculateRedLight();

            RenewSignalStatusList();

            RefreshSignalGraphic();
        }

        public void DeleteSignalSetting(int configNo)
        {
            for (int r = 0; r < roadList.Count;r++)
            {
                if (roadList[r].phaseNo == configNo)
                {
                    roadList[r].phaseNo = 0;
                }
                else
                {
                    if (roadList[r].phaseNo > configNo)
                    {
                        roadList[r].phaseNo--;
                    }
                }
            }

            signalConfigList.RemoveAt(configNo);

            CalculateRedLight();

            RenewSignalStatusList();

            RefreshSignalGraphic();

        }

        public void SetIntersectionSignalConfig(List<SignalConfig> newLightConfig)
        {
            nextConfig = newLightConfig;

            if (!Simulator.simulatorStarted)
            {
                for (int i = 0; i < newLightConfig.Count; i++)
                {
                    SetSignalConfig(i, newLightConfig[i]);
                }
                CalculateRedLight();
                RenewSignalStatusList();
                RefreshSignalGraphic();
            }
            else
            {
                if (newLightConfig.Count > 2)
                    CalculateTemporarilyRedLight();
                else
                {
                    for (int i = 0; i < newLightConfig.Count; i++)
                    {
                        SetSignalConfig(i, newLightConfig[i]);
                    }
                }
                CalculateRedLight();
            }

            //Test code
            if (Simulator.TESTMODE)
            {

            }
        }

        public void SetSignalConfig(int configNo, SignalConfig lightConfig)
        {
            signalConfigList[configNo] = lightConfig;
        }

        public void CalculateTemporarilyRedLight()
        {
            if (Simulator.TESTMODE)
            {
                Simulator.UI.AddMessage("System", "Intersection :" + intersectionID + " calculate temporarily red light");
            }

            int intsectionOrders = signalConfigList.Count;

            List<int[]> nowSetting = new List<int[]>();

            for (int a = 0; a < signalConfigList.Count; a++)
            {
                int[] setting = { signalConfigList[a].Green, signalConfigList[a].Yellow };
                nowSetting.Add(setting);
            }


            for (int i = 0; i < intsectionOrders; i++)
            {
                if (signalStatusList[i][0] == 0 || signalStatusList[i][0] == 1)
                {
                    for (int j = i; j <= i + intsectionOrders - 1; j++)
                    {
                        for (int k = j + 1; k <= j + intsectionOrders - 1; k++)
                        {
                            if (k == j + intsectionOrders - 1)
                            {
                                nowSetting[k % intsectionOrders][0] = nextConfig[k % intsectionOrders].Green;
                                nowSetting[k % intsectionOrders][1] = nextConfig[k % intsectionOrders].Yellow;
                            }//if
                            signalConfigList[j % intsectionOrders].TempRed += nowSetting[k % intsectionOrders][0];
                            signalConfigList[j % intsectionOrders].TempRed += nowSetting[k % intsectionOrders][1];
                        }//for
                    }//for
                }//if
            }//for
        }

        public void CalculateRedLight()
        {
            int totalRed = 0;
            for (int i = 0; i < signalConfigList.Count; i++)
            {
                totalRed += (signalConfigList[i].Green + signalConfigList[i].Yellow);
            }

            for (int i = 0; i < signalConfigList.Count; i++)
            {
                signalConfigList[i].Red = (totalRed - (signalConfigList[i].Green + signalConfigList[i].Yellow));
            }

            if(Simulator.TESTMODE)
                OutputSignalSettingToUI();

            Simulator.PrototypeManager.setIntersectionSignalTime(System.Convert.ToInt16(intersectionID));
        }

        public void RenewSignalStatusList()
        {
            signalStatusList.Clear();
            if (Simulator.TESTMODE)
            {
                Simulator.UI.AddMessage("System", "Intersection : " + intersectionID + "renew status ");
            }

            for (int configNo = 0; configNo < signalConfigList.Count; configNo++)
            {

                if (configNo == 0)
                {
                    int[] status_0 = { 0, signalConfigList[0].Green };
                    signalStatusList.Add(status_0);

                    if (Simulator.TESTMODE)
                        Simulator.UI.AddMessage("System", "ConfigNo : " + configNo + " status : " + status_0[0] + " time :" + status_0[1]);
                    
                }
                else
                {
                    int redSecond = 0;
                    for (int b = 0; b < configNo; b++)
                    {
                        redSecond += (signalConfigList[b].Green + signalConfigList[b].Yellow);
                    }
                    int[] status_others = { 2, redSecond };
                    signalStatusList.Add(status_others);

                    if (Simulator.TESTMODE)
                        Simulator.UI.AddMessage("System", "ConfigNo : " + configNo + " status : " + status_others[0] + " time :" + status_others[1]);
                    
                }
            }
        }

        public int GetCycleTime()
        {
            return signalConfigList[0].GetCycleTime();
        }

        public void RefreshSignalGraphic()
        {
            for (int i = 0; i < roadList.Count; i++)
            {
                if (signalStatusList.Count == 0)
                {
                    roadList[i].setSignalState(0,99);
                }
                else
                {
                    int configNo = roadList[i].phaseNo;
                    if (configNo > signalStatusList.Count - 1) //若無設定 則先以設定0代替
                    {
                        roadList[i].setSignalState(signalStatusList[0][0], signalStatusList[0][1]);
                    }
                    else
                    {
                        roadList[i].setSignalState(signalStatusList[configNo][0], signalStatusList[configNo][1]);
                    }
                }
            }
            
        }

        public void OutputSignalSettingToUI()
        {
            for (int i = 0; i < signalConfigList.Count; i++)
            {
                Simulator.UI.AddMessage("System", "ConfigNo : " + i +
                    " G : " + signalConfigList[i].Green +
                    " Y : " + signalConfigList[i].Yellow +
                    " R : " + signalConfigList[i].Red +
                    " TR : " + signalConfigList[i].TempRed);
            }
        }

        public void SaveRoadRecords(int configNo)
        {
            for (int i = 0; i < roadList.Count; i++)
            {
                if (roadList[i].phaseNo == configNo)
                {
                    roadList[i].StoreRecord();
                }
            }
        }

        public void SignalCountDown()
        {
            int allOrders = signalStatusList.Count;

            for (int configNo = 0; configNo < signalStatusList.Count; configNo++)
            {
                signalStatusList[configNo][1]--;

                if (signalStatusList[configNo][1] <= 0)//倒數結束
                {
                    if (signalStatusList[configNo][0] == this.SIGNAL_GREEN)
                        this.ToYellow(configNo);

                    else if (signalStatusList[configNo][0] == this.SIGNAL_YELLOW)
                    {
                        if (signalConfigList[configNo].TempRed > 0)//有TR時執行TR
                            this.ToTempRed(configNo);
                        else
                            this.ToRed(configNo);
                    }
                    else if (signalStatusList[configNo][0] == this.SIGNAL_RED || signalStatusList[configNo][0] == this.SIGNAL_TEMPRED)
                        this.ToGreen(configNo);

                    Simulator.IntersectionManager.callRefreshRequest();
                }
            }

            if (signalStatusList.Count > 0)
                RefreshSignalGraphic();

        }//LightCountDown end

        public void ToGreen(int configNo)
        {
            SaveRoadRecords(configNo);//輸出上一階段的資訊(綠 & 紅)

            if (configNo == 0)
            {
                IntersectionStateAnalysis();
                cycleEneTime.Add(Simulator.getCurrentTime());
                currentCycle++;
            }

            signalStatusList[configNo][0] = this.SIGNAL_GREEN;//紅燈轉綠燈
            signalStatusList[configNo][1] = signalConfigList[configNo].Green;
        }
        public void ToYellow(int configNo)
        {
            signalStatusList[configNo][0] = this.SIGNAL_YELLOW;
            signalStatusList[configNo][1] = signalConfigList[configNo].Yellow;
        }
        public void ToRed(int configNo)
        {
            signalStatusList[configNo][0] = this.SIGNAL_RED;
            signalStatusList[configNo][1] = signalConfigList[configNo].Red;
        }
        public void ToTempRed(int configNo)
        {
            signalStatusList[configNo][0] = this.SIGNAL_TEMPRED;
            signalStatusList[configNo][1] = signalConfigList[configNo].TempRed;
            signalConfigList[configNo].UsedTempRed();

            int renewOrder = (configNo + signalStatusList.Count - 1) % signalStatusList.Count;

            SetSignalConfig(renewOrder, nextConfig[renewOrder]);

            CalculateRedLight();
        }

        public double GetCurrentIAWR()
        {
            return currentIAWR;
        }

        public int GetCurrentTrafficState()
        {
            int state = 0;
            if (currentIAWR > mediumTrafficIAWR)
                state = 2;
            else if (currentIAWR > lowTrafficIAWR)
                state = 1;

            return state;
        }

        public void IntersectionStateAnalysis()
        {
            currentIAWR = Simulator.DataManager.GetIntersectionAvgWaitingRate(this.intersectionID, currentCycle + 1 - optimizationInterval_Cycle, currentCycle) * 100;
            int state = 0;
            if(currentIAWR > mediumTrafficIAWR)
                state = 2;
            else if (currentIAWR > lowTrafficIAWR)
                state = 1;

            if (Simulator.intersectionInformation)
            {
                Simulator.UI.RefreshIntersectionState(intersectionID);
            }

            if (Simulator.AIManager.trafficOptimazation) //有開啟優化
            {
                IntersectionOptimize();
            }

            if (Simulator.AIManager.GetEnableAdaptiveAdjustment()) //有開啟優化
            {
                if(Simulator.AIManager.GetEnableThresholdAdjustment())
                {
                    optimizationThreshold_IAWR = AA.ThresholdAdjustment(currentIAWR,optimizationThreshold_IAWR,stability);
                }
                if (Simulator.AIManager.GetEnableIntervalAdjustment())
                {
                    optimizationInterval_Cycle = AA.IntervalAdjustment(minOptimizationInterval,maxOptimizationInterval,stability,GetAdjacentStability());
                }
            }
        }

        public void IntersectionOptimize()
        {
            if (currentCycle >= latestOptimizationCycle + optimizationInterval_Cycle) //確認是否達到優化週期限制
            {
                OptimizationRecord newOptimizationRecord = new OptimizationRecord(currentCycle,Simulator.getCurrentTime_Format(), currentIAWR, optimizationThreshold_IAWR);

                if (currentIAWR > this.optimizationThreshold_IAWR) //判斷是否需要優化
                {
                    stability = 0;
                    Simulator.UI.AddMessage("AI", "Intersection : " + intersectionID + "  IAWR : " + currentIAWR + "(" + latestOptimizationCycle + "~" + currentCycle + ")");

                    foreach (SignalConfig sc in signalConfigList)
                    {
                        newOptimizationRecord.AddOriginConfiguration(sc.ToString_Short());
                    }

                    TO.CleanRoadList();

                    foreach(Road r in roadList)
                    {
                        double avgAriRate_min = Simulator.DataManager.GetAvgArrivalRate_min(r.roadID, latestOptimizationCycle, currentCycle);
                        double avgDepartureRate_min = Simulator.DataManager.GetAvgDepartureRate_min(r.roadID, latestOptimizationCycle, currentCycle);
                        double avgWaitingVehicle = Simulator.DataManager.GetAvgWaittingVehicles(r.roadID, latestOptimizationCycle, currentCycle);
                        double avgWaitingRate = Simulator.DataManager.GetAvgWaittingRate(r.roadID, latestOptimizationCycle, currentCycle);
                        TO.AddRoad(r.roadID, r.phaseNo, signalConfigList[r.phaseNo].Green, signalConfigList[r.phaseNo].Red, avgAriRate_min, avgDepartureRate_min, avgWaitingVehicle, avgWaitingRate); 
                    }

                    //optimization 
                    Dictionary<int, int> optimizedGreenTime = TO.Optimization();

                    //new signal config
                    List<SignalConfig> optimizedConfig = new List<SignalConfig>();

                    //fill value
                    for (int i = 0; i < signalConfigList.Count; i++)
                    {
                        SignalConfig newConfig = new SignalConfig(optimizedGreenTime[i], 2);
                        optimizedConfig.Add(newConfig);
                    }

                    //apply
                    SetIntersectionSignalConfig(optimizedConfig);


                    foreach (SignalConfig sc in signalConfigList)
                    {
                        newOptimizationRecord.AddOptimizedConfiguration(sc.ToString_Short());
                    }

                }// if (IAWR > this.IAWRThreshold)
                else
                {
                    stability++; 
                }

                latestOptimizationCycle = currentCycle;

                Simulator.DataManager.AddOptimizationRecord(intersectionID, newOptimizationRecord);

            } //if (currentCycle >= latestOptimizeCycle + optimizeInerval)
        }

        public double GetAdjacentStability()
        {
            double stability_avg = 0;
            double allAriRate = 0;

            foreach (Road road in roadList)
            {
                if (road.fromIntersection != null)
                {
                    double avgAriRate_min = Simulator.DataManager.GetAvgArrivalRate_min(road.roadID, latestOptimizationCycle, currentCycle);
                    allAriRate += avgAriRate_min;

                    int stability_adj = road.fromIntersection.stability;

                    stability_avg += (avgAriRate_min * stability_adj);
                }
            }

            stability_avg /= allAriRate;

            return Math.Round(stability_avg, 2, MidpointRounding.AwayFromZero);
        }
    }
}