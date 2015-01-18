using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SmartCitySimulator.GraphicUnit;
using SmartCitySimulator.SystemObject;
using System.Windows.Forms;
using System.Collections;
using signalAI;

namespace SmartCitySimulator.Unit
{
    public class Intersection
    {
        int SIGNAL_GREEN = 0, SIGNAL_YELLOW = 1, SIGNAL_RED = 2, SIGNAL_TEMPRED = 3;

        //intersection profile
        public int intersectionID = -1;
        public string intersectionName = "default";

        //list of roads in the intersection 
        public List<Road> roadList;

        //signal config and state
        public List<SignalConfig> signalConfigList;
        public List<int[]> signalStateList;

        //config for next ues
        public List<SignalConfig> nextConfig;

        //Optimization 
        double currentIAWR = 0;
        public int currentCycle = 0; //以order 0 結束紅燈時算一個cycle
        public int latestOptimizationCycle = 0;
        public int optimizationInterval;
        public double IAWRThreshold;
        double lowTrafficIAWR = 50;
        double mediumTrafficIAWR = 70;

        //Adaptive Optimization Adjustment 
        int unOptimizedeCounter = 0;
        Boolean dynamicIAWR;
        Boolean dynamicInterval = true;


        public Intersection(int intersectionID)
        {
            this.intersectionID = intersectionID;
            roadList = new List<Road>();
        }

        public void Initialize()
        {
            signalConfigList = new List<SignalConfig>();
            signalStateList = new List<int[]>();        //int[]中，[0]為目前紅綠燈狀態(0紅1綠2黃)；[1]為目前倒數秒數

            optimizationInterval = Simulator.IntersectionManager.defaultOptimizeInterval;
            IAWRThreshold = Simulator.IntersectionManager.defaultIAWR;
            dynamicIAWR = Simulator.IntersectionManager.dynamicIAWR;

            latestOptimizationCycle = 0;
            currentCycle = 0;
            unOptimizedeCounter = 0;

            Simulator.DataManager.RegisterIntersection(intersectionID);
        }

        public void AddNewLightSetting(SignalConfig newConfig) //newSrtting [0] = 新綠燈 [1]= 新黃燈
        {
            signalConfigList.Add(newConfig);

            CalculateRedLight();

            RenewLightStateList();

            RefreshLightGraphic();
        }

        public void DeleteLightSetting(int order)
        {
            for (int r = 0; r < roadList.Count;r++)
            {
                if (roadList[r].order == order)
                {
                    roadList[r].order = 0;
                }
                else
                {
                    if (roadList[r].order > order)
                    {
                        roadList[r].order--;
                    }
                }
            }

            signalConfigList.RemoveAt(order);

            CalculateRedLight();

            RenewLightStateList();

            RefreshLightGraphic();

        }

        public void SetIntersectionLightConfig(List<SignalConfig> newLightConfig)
        {
            nextConfig = newLightConfig;

            if (!Simulator.simulatorStarted)
            {
                for (int i = 0; i < newLightConfig.Count; i++)
                {
                    SetLightConfig(i, newLightConfig[i]);
                }
                CalculateRedLight();
                RenewLightStateList();
                RefreshLightGraphic();
            }
            else
            {
                if (newLightConfig.Count > 2)
                    CalculateTemporarilyRedLight();
                else
                {
                    for (int i = 0; i < newLightConfig.Count; i++)
                    {
                        SetLightConfig(i, newLightConfig[i]);
                    }
                }
                CalculateRedLight();
            }

            //Test code
            if (Simulator.TESTMODE)
            {

            }
        }

        public void SetLightConfig(int order, SignalConfig lightConfig)
        {
            signalConfigList[order] = lightConfig;
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
                OutputLightSettingToUI();

            Simulator.PrototypeManager.setIntersectionSignalTime(System.Convert.ToInt16(intersectionID));
        }

        public void RenewLightStateList()
        {
            signalStateList.Clear();
            if (Simulator.TESTMODE)
            {
                Simulator.UI.AddMessage("System", "Intersection : " + intersectionID + "renew state ");
            }

            for (int order = 0; order < signalConfigList.Count; order++)
            {

                if (order == 0)
                {
                    int[] state_0 = { 0, signalConfigList[0].Green };
                    signalStateList.Add(state_0);

                    if (Simulator.TESTMODE)
                    {
                        Simulator.UI.AddMessage("System", "Order : " + order + " state : " + state_0[0] + " time :" + state_0[1]);
                    }
                }
                else
                {
                    int redSecond = 0;
                    for (int b = 0; b < order; b++)
                    {
                        redSecond += (signalConfigList[b].Green + signalConfigList[b].Yellow);
                    }
                    int[] state_others = { 2, redSecond };
                    signalStateList.Add(state_others);

                    if (Simulator.TESTMODE)
                    {
                        Simulator.UI.AddMessage("System", "Order : " + order + " state : " + state_others[0] + " time :" + state_others[1]);
                    }
                }
            }
        }

        public int CycleTime()
        {
            return signalConfigList[0].GetCycleTime();
        }

        public void RefreshLightGraphic()
        {
            for (int i = 0; i < roadList.Count; i++)
            {
                int lightOrder = roadList[i].order;
                if (lightOrder >= signalStateList.Count) //若無設定 則先以設定0代替
                {
                    roadList[i].setLightState(signalStateList[0][0], signalStateList[0][1]);
                }
                else
                {
                    roadList[i].setLightState(signalStateList[lightOrder][0], signalStateList[lightOrder][1]);
                }
            }
            
        }

        public void OutputLightSettingToUI()
        {
            for (int i = 0; i < signalConfigList.Count; i++)
            {
                Simulator.UI.AddMessage("System", "Order : " + i +
                    " G : " + signalConfigList[i].Green +
                    " Y : " + signalConfigList[i].Yellow +
                    " R : " + signalConfigList[i].Red +
                    " TR : " + signalConfigList[i].TempRed);
            }
        }

        public void SaveRoadRecords(int order)
        {
            for (int i = 0; i < roadList.Count; i++)
            {
                if (roadList[i].order == order)
                {
                    roadList[i].StoreToDataManager();
                }
            }
        }

        public void LightCountDown()
        {
            int allOrders = signalStateList.Count;

            for (int order = 0; order < signalStateList.Count; order++)
            {
                signalStateList[order][1]--;

                if (signalStateList[order][1] <= 0)//倒數結束
                {
                    if (signalStateList[order][0] == this.SIGNAL_GREEN)
                        this.ToYellow(order);

                    else if (signalStateList[order][0] == this.SIGNAL_YELLOW)
                    {
                        if (signalConfigList[order].TempRed > 0)//有TR時執行TR
                            this.ToTempRed(order);
                        else
                            this.ToRed(order);
                    }
                    else if (signalStateList[order][0] == this.SIGNAL_RED || signalStateList[order][0] == this.SIGNAL_TEMPRED)
                        this.ToGreen(order);

                    Simulator.IntersectionManager.callRefreshRequest();
                }
            }

            if (signalStateList.Count > 0)
                RefreshLightGraphic();

        }//LightCountDown end

        public void ToGreen(int order)
        {
            SaveRoadRecords(order);//輸出上一階段的資訊(綠 & 紅)

            if (order == 0)
            {
                IntersectionStateAnalysis();
                currentCycle++;
            }

            signalStateList[order][0] = this.SIGNAL_GREEN;//紅燈轉綠燈
            signalStateList[order][1] = signalConfigList[order].Green;
        }
        public void ToYellow(int order)
        {
            signalStateList[order][0] = this.SIGNAL_YELLOW;
            signalStateList[order][1] = signalConfigList[order].Yellow;
        }
        public void ToRed(int order)
        {
            signalStateList[order][0] = this.SIGNAL_RED;
            signalStateList[order][1] = signalConfigList[order].Red;
        }
        public void ToTempRed(int order)
        {
            signalStateList[order][0] = this.SIGNAL_TEMPRED;
            signalStateList[order][1] = signalConfigList[order].TempRed;
            signalConfigList[order].UsedTempRed();

            int renewOrder = (order + signalStateList.Count - 1) % signalStateList.Count;

            SetLightConfig(renewOrder, nextConfig[renewOrder]);

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
            //double currentIAWR = Simulator.DataManager.GetIntersectionAvgWaitingRate(this.intersectionID, latestOptimizeCycle, currentCycle);
            currentIAWR = Simulator.DataManager.GetIntersectionAvgWaitingRate(this.intersectionID, currentCycle + 1 - optimizationInterval, currentCycle);
            int state = 0;
            if(currentIAWR > mediumTrafficIAWR)
                state = 2;
            else if (currentIAWR > lowTrafficIAWR)
                state = 1;

            if (Simulator.intersectionInformation)
            {
                Simulator.UI.RefreshIntersectionState(intersectionID);
            }

            if (Simulator.IntersectionManager.AIOptimazation) //有開啟優化
            {
                IntersectionOptimize();
            }
        }

        public void IntersectionOptimize()
        {
            if (currentCycle >= latestOptimizationCycle + optimizationInterval) //確認是否達到優化週期限制
            {
                OptimizationRecord newOptimizationRecord = new OptimizationRecord(currentCycle,Simulator.getCurrentTime(), currentIAWR, IAWRThreshold);

                if (currentIAWR > this.IAWRThreshold) //判斷是否需要優化
                {
                    unOptimizedeCounter = 0;
                    Simulator.UI.AddMessage("AI", "Intersection : " + intersectionID + " IAWR : " + currentIAWR + "(" + latestOptimizationCycle + "~" + currentCycle + ")");

                    for (int i = 0; i < this.signalConfigList.Count; i++)
                    {
                        SignalConfig config = new SignalConfig(signalConfigList[i].Green, signalConfigList[i].Yellow);
                        config.Red = signalConfigList[i].Red;
                        config.TempRed = signalConfigList[i].TempRed;

                        newOptimizationRecord.AddOriginConfiguration(config);
                    }

                    //GA 
                    int curGtA1 = signalConfigList[0].Green;
                    int curGtB1 = signalConfigList[0].Green, curGtC1 = signalConfigList[0].Green;
                    int curGtA2 = signalConfigList[1].Green;
                    int curGtB2 = signalConfigList[1].Green, curGtC2 = signalConfigList[1].Green;

                    List<double> Queue0 = new List<double>();
                    List<double> Queue1 = new List<double>();

                    List<double> ArrivalRate0 = new List<double>();
                    List<double> ArrivalRate1 = new List<double>();

                    for (int roadIndex = 0; roadIndex < roadList.Count; roadIndex++)
                    {
                        if (roadList[roadIndex].order == 0)
                        {
                            Queue0.Add(Simulator.DataManager.GetAvgWaittingVehicles(roadList[roadIndex].roadID, latestOptimizationCycle, currentCycle));
                            ArrivalRate0.Add(Simulator.DataManager.GetArrivalVehicles(roadList[roadIndex].roadID, latestOptimizationCycle, currentCycle));
                        }
                        else if (roadList[roadIndex].order == 1)
                        {
                            Queue1.Add(Simulator.DataManager.GetAvgWaittingVehicles(roadList[roadIndex].roadID, latestOptimizationCycle, currentCycle));
                            ArrivalRate1.Add(Simulator.DataManager.GetArrivalVehicles(roadList[roadIndex].roadID, latestOptimizationCycle, currentCycle));
                        }
                    }

                    if (Queue0.Count < 2)
                    {
                        Queue0.Add(-1);
                        ArrivalRate0.Add(-1);
                    }
                    if (Queue1.Count < 2)
                    {
                        Queue1.Add(-1);
                        ArrivalRate1.Add(-1);
                    }

                    double[] road1 = new double[6] { 5, 0, signalConfigList[0].Green, signalConfigList[0].Green, Queue0[0], ArrivalRate0[0] };
                    double[] road2 = new double[6] { 5, 0, signalConfigList[0].Green, signalConfigList[0].Green, Queue0[1], ArrivalRate0[1] };
                    double[] road3 = new double[6] { 5, 1, signalConfigList[1].Green, signalConfigList[1].Green, Queue1[0], ArrivalRate1[0] };
                    double[] road4 = new double[6] { 5, 1, signalConfigList[1].Green, signalConfigList[1].Green, Queue1[1], ArrivalRate1[1] };

                    List<double[]> roadsData = new List<double[]>();
                    roadsData.Add(road1);
                    roadsData.Add(road2);
                    roadsData.Add(road3);
                    roadsData.Add(road4);

                    GA_Optimization optimization = new GA_Optimization();
                    List<int> optimizedGreen = optimization.GAOptimize(roadsData);
                    //GA end

                    List<SignalConfig> optimizedConfig = new List<SignalConfig>();

                    for (int i = 0; i < signalConfigList.Count; i++)
                    {
                        SignalConfig newConfig = new SignalConfig(optimizedGreen[i], 2);
                        optimizedConfig.Add(newConfig);
                    }

                    SetIntersectionLightConfig(optimizedConfig);

                    for (int i = 0; i < this.signalConfigList.Count; i++)
                    {
                        SignalConfig config = new SignalConfig(signalConfigList[i].Green, signalConfigList[i].Yellow);
                        config.Red = signalConfigList[i].Red;
                        config.TempRed = signalConfigList[i].TempRed;

                        newOptimizationRecord.AddOptimizedConfiguration(config);
                    }
                }// if (IAWR > this.IAWRThreshold)
                else
                {
                        unOptimizedeCounter++; 
                }

                latestOptimizationCycle = currentCycle;

                Simulator.DataManager.PutOptimizationRecord(intersectionID, newOptimizationRecord);

                DynamicIAWR();
                DynamicInterval();

            } //if (currentCycle >= latestOptimizeCycle + optimizeInerval)
        }

        public void EnableDynamicIAWR(Boolean available)
        {
            this.dynamicIAWR = available;
            if (Simulator.TESTMODE)
            {
                Simulator.UI.AddMessage("AI", "Intersection : " + intersectionID + " dynamic IAWR : " + available);
            }
        }

        public void DynamicIAWR()
        {
            if(dynamicIAWR) 
            {
                double increaseRate = 0.05;
                double newIAWRThreshold;

                if (unOptimizedeCounter == 0) //optimize
                {
                    newIAWRThreshold = currentIAWR * (1 + increaseRate);
                }
                else //no optimize
                {
                    if (unOptimizedeCounter <= 5)
                    {
                        newIAWRThreshold = (IAWRThreshold * (10 - unOptimizedeCounter) + (currentIAWR * unOptimizedeCounter)) / 10;
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
            if (dynamicInterval)
            {
                double minOptInterval = 10;
                double maximumIntervalTimes = 4;
                double factor = 6;

                double newInterval = ((factor + unOptimizedeCounter * maximumIntervalTimes) / (factor + unOptimizedeCounter)) * minOptInterval;   
                
                optimizationInterval = (int)Math.Round(newInterval, 0, MidpointRounding.AwayFromZero);

                Simulator.UI.AddMessage("AI", "Intersection : " + intersectionID + " dynamic Interval : " + unOptimizedeCounter);
            }
        }

    }
}