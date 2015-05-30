using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SmartTrafficSimulator.GraphicUnit;
using SmartTrafficSimulator.SystemObject;
using System.Windows.Forms;
using System.Collections;
using Optimization;
using SmartTrafficSimulator.SystemManagers;

namespace SmartTrafficSimulator.Unit
{
    public class Intersection
    {
        int SIGNAL_GREEN = 0, SIGNAL_YELLOW = 1, SIGNAL_RED = 2, SIGNAL_TEMPRED = 3;
        TrafficOptimization TO;

        //intersection profile
        public int intersectionID = -1;
        public string intersectionName = "default";
        Boolean cycleLengthFixed = false;
        int minGreen = 30;
        int maxGreen = 90;
        public int currentCycle = 0; //以ConfigNo 0 結束紅燈時算一個cycle


        //List of roads
        public List<Road> roadList = new List<Road>();

        //List of adjacent intersections
        public List<Intersection> adjacentIntersections = new List<Intersection>();

        //Signal config and state
        public List<SignalConfig> signalConfigList;
        public List<int[]> signalStateList; //[0] = state , [1] = current second
       
        //Signal config for next ues
        public List<SignalConfig> nextConfig;

        //
        public List<int> cycleEneTime;

        //Optimization info
        double currentIAWR = 0;
        public int latestOptimizationCycle;
        public int optimizationInterval;
        public double IAWRThreshold;

        double lowTrafficIAWR = 50;
        double mediumTrafficIAWR = 70;

        //Optimization para
        int optimizationMethod = 0; //0 = GA, 1 = GT

        //Adaptive Optimization
        int stability;
        double stability_adj;
        //Boolean dynamicIAWR;
        //Boolean dynamicInterval = true;


        public Intersection(int intersectionID)
        {
            this.intersectionID = intersectionID;
        }

        public void Initialize()
        {
            //Initial signal config
            signalConfigList = new List<SignalConfig>();
            signalStateList = new List<int[]>();

            //Initial optimization setting
            optimizationInterval = Simulator.IntersectionManager.defaultOptimizeInterval;
            IAWRThreshold = Simulator.IntersectionManager.defaultIAWR;

            latestOptimizationCycle = 0;
            currentCycle = 0;
            stability = 0;
            stability_adj = 0;

            TO = new TrafficOptimization(minGreen, maxGreen, cycleLengthFixed);

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
                    if (adjInte != null && !adjacentIntersections.Contains(adjInte))
                    { 
                        adjacentIntersections.Add(adjInte);
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

            RenewSignalStateList();

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

            RenewSignalStateList();

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
                RenewSignalStateList();
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
                if (signalStateList[i][0] == 0 || signalStateList[i][0] == 1)
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

        public void RenewSignalStateList()
        {
            signalStateList.Clear();
            if (Simulator.TESTMODE)
            {
                Simulator.UI.AddMessage("System", "Intersection : " + intersectionID + "renew state ");
            }

            for (int configNo = 0; configNo < signalConfigList.Count; configNo++)
            {

                if (configNo == 0)
                {
                    int[] state_0 = { 0, signalConfigList[0].Green };
                    signalStateList.Add(state_0);

                    if (Simulator.TESTMODE)
                        Simulator.UI.AddMessage("System", "ConfigNo : " + configNo + " state : " + state_0[0] + " time :" + state_0[1]);
                    
                }
                else
                {
                    int redSecond = 0;
                    for (int b = 0; b < configNo; b++)
                    {
                        redSecond += (signalConfigList[b].Green + signalConfigList[b].Yellow);
                    }
                    int[] state_others = { 2, redSecond };
                    signalStateList.Add(state_others);

                    if (Simulator.TESTMODE)
                        Simulator.UI.AddMessage("System", "ConfigNo : " + configNo + " state : " + state_others[0] + " time :" + state_others[1]);
                    
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
                if (signalStateList.Count == 0)
                {
                    roadList[i].setSignalState(0,99);
                }
                else
                {
                    int configNo = roadList[i].phaseNo;
                    if (configNo > signalStateList.Count - 1) //若無設定 則先以設定0代替
                    {
                        roadList[i].setSignalState(signalStateList[0][0], signalStateList[0][1]);
                    }
                    else
                    {
                        roadList[i].setSignalState(signalStateList[configNo][0], signalStateList[configNo][1]);
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
            int allOrders = signalStateList.Count;

            for (int configNo = 0; configNo < signalStateList.Count; configNo++)
            {
                signalStateList[configNo][1]--;

                if (signalStateList[configNo][1] <= 0)//倒數結束
                {
                    if (signalStateList[configNo][0] == this.SIGNAL_GREEN)
                        this.ToYellow(configNo);

                    else if (signalStateList[configNo][0] == this.SIGNAL_YELLOW)
                    {
                        if (signalConfigList[configNo].TempRed > 0)//有TR時執行TR
                            this.ToTempRed(configNo);
                        else
                            this.ToRed(configNo);
                    }
                    else if (signalStateList[configNo][0] == this.SIGNAL_RED || signalStateList[configNo][0] == this.SIGNAL_TEMPRED)
                        this.ToGreen(configNo);

                    Simulator.IntersectionManager.callRefreshRequest();
                }
            }

            if (signalStateList.Count > 0)
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

            signalStateList[configNo][0] = this.SIGNAL_GREEN;//紅燈轉綠燈
            signalStateList[configNo][1] = signalConfigList[configNo].Green;
        }
        public void ToYellow(int configNo)
        {
            signalStateList[configNo][0] = this.SIGNAL_YELLOW;
            signalStateList[configNo][1] = signalConfigList[configNo].Yellow;
        }
        public void ToRed(int configNo)
        {
            signalStateList[configNo][0] = this.SIGNAL_RED;
            signalStateList[configNo][1] = signalConfigList[configNo].Red;
        }
        public void ToTempRed(int configNo)
        {
            signalStateList[configNo][0] = this.SIGNAL_TEMPRED;
            signalStateList[configNo][1] = signalConfigList[configNo].TempRed;
            signalConfigList[configNo].UsedTempRed();

            int renewOrder = (configNo + signalStateList.Count - 1) % signalStateList.Count;

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
            //currentIAWR = Simulator.DataManager.GetIntersectionAvgWaitingRate(this.intersectionID, latestOptimizeCycle, currentCycle);
            currentIAWR = Simulator.DataManager.GetIntersectionAvgWaitingRate(this.intersectionID, currentCycle + 1 - optimizationInterval, currentCycle) * 100;
            int state = 0;
            if(currentIAWR > mediumTrafficIAWR)
                state = 2;
            else if (currentIAWR > lowTrafficIAWR)
                state = 1;

            if (Simulator.intersectionInformation)
            {
                Simulator.UI.RefreshIntersectionState(intersectionID);
            }

            if (Simulator.AIManager.AIOptimazation) //有開啟優化
            {
                IntersectionOptimize();
            }
        }

        public void IntersectionOptimize()
        {
            if (currentCycle >= latestOptimizationCycle + optimizationInterval) //確認是否達到優化週期限制
            {
                OptimizationRecord newOptimizationRecord = new OptimizationRecord(currentCycle,Simulator.getCurrentTime_Format(), currentIAWR, IAWRThreshold);

               // Simulator.UI.AddMessage("System","ADJS : " + GetAdjacentStability());
                stability_adj = GetAdjacentStability();

                if (currentIAWR > this.IAWRThreshold) //判斷是否需要優化
                {
                    stability = 0;
                    Simulator.UI.AddMessage("AI", "Intersection : " + intersectionID + " IAWR : " + currentIAWR + "(" + latestOptimizationCycle + "~" + currentCycle + ")");

                    foreach (SignalConfig sc in signalConfigList)
                    {
                        newOptimizationRecord.AddOriginConfiguration(sc.ToString_Short());
                    }

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

                DynamicIAWR();
                DynamicInterval();

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

        /*public void EnableDynamicIAWR(Boolean available)
        {
            this.dynamicIAWR = available;
            if (Simulator.TESTMODE)
            {
                Simulator.UI.AddMessage("AI", "Intersection : " + intersectionID + " dynamic IAWR : " + available);
            }
        }*/

        public void DynamicIAWR()
        {
            if (Simulator.AIManager.EnableAdaptiveAdjustment() && Simulator.AIManager.EnableThresholdAdjustment()) 
            {
                double increaseRate = 0.05;
                double newIAWRThreshold;

                if (stability == 0) //optimize
                {
                    newIAWRThreshold = currentIAWR * (1 + increaseRate);
                }
                else //no optimize
                {
                    if (stability <= 5)
                    {
                        newIAWRThreshold = (IAWRThreshold * (10 - stability) + (currentIAWR * stability)) / 10;
                    }
                    else
                    {
                        newIAWRThreshold = (IAWRThreshold + currentIAWR) / 2;
                    }
                }

                IAWRThreshold = Math.Round(newIAWRThreshold, 2, MidpointRounding.AwayFromZero);
            }
        }

        public void DynamicInterval()
        {
            if (Simulator.AIManager.EnableAdaptiveAdjustment() && Simulator.AIManager.EnableIntervalAdjustment())
            {
                double minOptInterval = 5;
                double maximumIntervalTimes = 3;
                double factor = 6;

                //double newInterval = ((factor + stability * maximumIntervalTimes) / (factor + stability)) * minOptInterval;

                double newInterval = ((factor + (stability+1) * (stability_adj+1)) / (factor + (stability+1))) * minOptInterval;   
                
                optimizationInterval = (int)Math.Round(newInterval, 0, MidpointRounding.AwayFromZero);

                Simulator.UI.AddMessage("AI", "Intersection : " + intersectionID + " Stability : " + stability);
            }
        }

    }
}