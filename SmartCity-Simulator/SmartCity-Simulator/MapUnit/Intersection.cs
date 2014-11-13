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

        //Light config and state
        public List<LightConfig> lightConfigList;
        public List<int[]> lightStateList;

        //config for next ues
        public List<LightConfig> nextConfig;

        //Optimization 
        public int currentCycle = 0; //以order 0 結束紅燈時算一個cycle
        public int latestOptimizationCycle = 0;
        public int optimizationInerval;
        public double IAWRThreshold;
        double lowTrafficIAWR = 50;
        double mediumTrafficIAWR = 70;

        //Dynamic IAWR 
        Boolean dynamicIAWR;
        int unOptimizedeCounter = 0;

        public Intersection(int intersectionID)
        {
            this.intersectionID = intersectionID;
            roadList = new List<Road>();
        }

        public void Initialize()
        {
            lightConfigList = new List<LightConfig>();
            lightStateList = new List<int[]>();        //int[]中，[0]為目前紅綠燈狀態(0紅1綠2黃)；[1]為目前倒數秒數

            optimizationInerval = Simulator.IntersectionManager.defaultOptimizeInerval;
            IAWRThreshold = Simulator.IntersectionManager.defaultIAWR;
            dynamicIAWR = Simulator.IntersectionManager.dynamicIAWR;

            latestOptimizationCycle = 0;
            currentCycle = 0;
            unOptimizedeCounter = 0;

            Simulator.DataManager.RegisterIntersection(intersectionID);
        }

        public void AddNewLightSetting(LightConfig newConfig) //newSrtting [0] = 新綠燈 [1]= 新黃燈
        {
            lightConfigList.Add(newConfig);

            CalculateRedLight();

            RenewLightStateList();

            RefreshLightGraphic();
        }

        public void DeleteLightSetting(int order)
        {
            lightConfigList.RemoveAt(order);

            CalculateRedLight();

            RenewLightStateList();

            RefreshLightGraphic();

        }

        public void SetIntersectionLightConfig(List<LightConfig> newLightConfig)
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

        public void SetLightConfig(int order, LightConfig lightConfig)
        {
            lightConfigList[order] = lightConfig;
        }

        public void CalculateTemporarilyRedLight()
        {
            if (Simulator.TESTMODE)
            {
                Simulator.UI.AddMessage("System", "Intersection :" + intersectionID + " calculate t emporarily red light");
            }

            int intsectionOrders = lightConfigList.Count;

            List<int[]> nowSetting = new List<int[]>();

            for (int a = 0; a < lightConfigList.Count; a++)
            {
                int[] setting = { lightConfigList[a].Green, lightConfigList[a].Yellow };
                nowSetting.Add(setting);
            }


            for (int i = 0; i < intsectionOrders; i++)
            {
                if (lightStateList[i][0] == 0 || lightStateList[i][0] == 1)
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
                            lightConfigList[j % intsectionOrders].TempRed += nowSetting[k % intsectionOrders][0];
                            lightConfigList[j % intsectionOrders].TempRed += nowSetting[k % intsectionOrders][1];
                        }//for
                    }//for
                }//if
            }//for
        }

        public void CalculateRedLight()
        {
            int totalRed = 0;
            for (int i = 0; i < lightConfigList.Count; i++)
            {
                totalRed += (lightConfigList[i].Green + lightConfigList[i].Yellow);
            }

            for (int i = 0; i < lightConfigList.Count; i++)
            {
                lightConfigList[i].Red = (totalRed - (lightConfigList[i].Green + lightConfigList[i].Yellow));
            }

            if(Simulator.TESTMODE)
                OutputLightSettingToUI();

            Simulator.PrototypeManager.setIntersectionSignalTime(System.Convert.ToInt16(intersectionID));
        }

        public void RenewLightStateList()
        {
            lightStateList.Clear();
            if (Simulator.TESTMODE)
            {
                Simulator.UI.AddMessage("System", "Intersection : " + intersectionID + "renew state ");
            }

            for (int order = 0; order < lightConfigList.Count; order++)
            {

                if (order == 0)
                {
                    int[] state_0 = { 0, lightConfigList[0].Green };
                    lightStateList.Add(state_0);

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
                        redSecond += (lightConfigList[b].Green + lightConfigList[b].Yellow);
                    }
                    int[] state_others = { 2, redSecond };
                    lightStateList.Add(state_others);

                    if (Simulator.TESTMODE)
                    {
                        Simulator.UI.AddMessage("System", "Order : " + order + " state : " + state_others[0] + " time :" + state_others[1]);
                    }
                }
            }
        }

        public int CycleTime()
        {
            return lightConfigList[0].GetCycleTime();
        }

        public void RefreshLightGraphic()
        {
            for (int i = 0; i < roadList.Count; i++)
            {
                int lightOrder = roadList[i].order;
                if (lightOrder >= lightStateList.Count) //若無設定 則先以設定0代替
                {
                    roadList[i].setLightState(lightStateList[0][0], lightStateList[0][1]);
                }
                else
                {
                    roadList[i].setLightState(lightStateList[lightOrder][0], lightStateList[lightOrder][1]);
                }
            }
        }

        public void OutputLightSettingToUI()
        {
            for (int i = 0; i < lightConfigList.Count; i++)
            {
                Simulator.UI.AddMessage("System", "Order : " + i +
                    " G : " + lightConfigList[i].Green +
                    " Y : " + lightConfigList[i].Yellow +
                    " R : " + lightConfigList[i].Red +
                    " TR : " + lightConfigList[i].TempRed);
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
            int allOrders = lightStateList.Count;

            for (int order = 0; order < lightStateList.Count; order++)
            {
                lightStateList[order][1]--;

                if (lightStateList[order][1] <= 0)//倒數結束
                {
                    if (lightStateList[order][0] == this.SIGNAL_GREEN)
                        this.ToYellow(order);

                    else if (lightStateList[order][0] == this.SIGNAL_YELLOW)
                    {
                        if (lightConfigList[order].TempRed > 0)//有TR時執行TR
                            this.ToTempRed(order);
                        else
                            this.ToRed(order);
                    }
                    else if (lightStateList[order][0] == this.SIGNAL_RED || lightStateList[order][0] == this.SIGNAL_TEMPRED)
                        this.ToGreen(order);

                    Simulator.IntersectionManager.callRefreshRequest();
                }
            }

            if (lightStateList.Count > 0)
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

            lightStateList[order][0] = this.SIGNAL_GREEN;//紅燈轉綠燈
            lightStateList[order][1] = lightConfigList[order].Green;
        }
        public void ToYellow(int order)
        {
            lightStateList[order][0] = this.SIGNAL_YELLOW;
            lightStateList[order][1] = lightConfigList[order].Yellow;
        }
        public void ToRed(int order)
        {
            lightStateList[order][0] = this.SIGNAL_RED;
            lightStateList[order][1] = lightConfigList[order].Red;
        }
        public void ToTempRed(int order)
        {
            lightStateList[order][0] = this.SIGNAL_TEMPRED;
            lightStateList[order][1] = lightConfigList[order].TempRed;
            lightConfigList[order].UsedTempRed();

            int renewOrder = (order + lightStateList.Count - 1) % lightStateList.Count;

            SetLightConfig(renewOrder, nextConfig[renewOrder]);

            CalculateRedLight();
        }

        public void IntersectionStateAnalysis()
        {
            //double currentIAWR = Simulator.DataManager.GetIntersectionAvgWaitingRate(this.intersectionID, latestOptimizeCycle, currentCycle);
            double currentIAWR = Simulator.DataManager.GetIntersectionAvgWaitingRate(this.intersectionID, currentCycle + 1 - optimizationInerval, currentCycle);
            int state = 0;
            if(currentIAWR > mediumTrafficIAWR)
                state = 2;
            else if (currentIAWR > lowTrafficIAWR)
                state = 1;

            Simulator.UI.RefreshIntersectionState(intersectionID, currentIAWR, state);

            if (Simulator.IntersectionManager.AIOptimazation) //有開啟優化
            {
                IntersectionOptimize(currentIAWR);
            }
        }

        public void IntersectionOptimize(double currentIAWR)
        {
            if (currentCycle >= latestOptimizationCycle + optimizationInerval) //確認是否達到優化週期限制
            {
                OptimizationRecord newOptimizationRecord = new OptimizationRecord(currentCycle,Simulator.getCurrentTime(), currentIAWR, IAWRThreshold);

                if (currentIAWR > this.IAWRThreshold) //判斷是否需要優化
                {
                    Simulator.UI.AddMessage("AI", "Intersection : " + intersectionID + " IAWR : " + currentIAWR + "(" + latestOptimizationCycle + "~" + currentCycle + ")");

                    for (int i = 0; i < this.lightConfigList.Count; i++)
                    {
                        LightConfig config = new LightConfig(lightConfigList[i].Green, lightConfigList[i].Yellow);
                        config.Red = lightConfigList[i].Red;
                        config.TempRed = lightConfigList[i].TempRed;

                        newOptimizationRecord.AddOriginConfiguration(config);
                    }

                    //GA 
                    int curGtA1 = lightConfigList[0].Green;
                    int curGtB1 = lightConfigList[0].Green, curGtC1 = lightConfigList[0].Green;
                    int curGtA2 = lightConfigList[1].Green;
                    int curGtB2 = lightConfigList[1].Green, curGtC2 = lightConfigList[1].Green;

                    List<double> Queue0 = new List<double>();
                    List<double> Queue1 = new List<double>();

                    List<double> ArrivalRate0 = new List<double>();
                    List<double> ArrivalRate1 = new List<double>();

                    for (int roadIndex = 0; roadIndex < roadList.Count; roadIndex++)
                    {
                        if (roadList[roadIndex].order == 0)
                        {
                            Queue0.Add(Simulator.DataManager.GetAvgWaittingVehicles(roadList[roadIndex].roadID, latestOptimizationCycle, currentCycle));
                            ArrivalRate0.Add(Simulator.DataManager.GetArrivalRate(roadList[roadIndex].roadID, latestOptimizationCycle, currentCycle));
                        }
                        else if (roadList[roadIndex].order == 1)
                        {
                            Queue1.Add(Simulator.DataManager.GetAvgWaittingVehicles(roadList[roadIndex].roadID, latestOptimizationCycle, currentCycle));
                            ArrivalRate1.Add(Simulator.DataManager.GetArrivalRate(roadList[roadIndex].roadID, latestOptimizationCycle, currentCycle));
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

                    double[] road1 = new double[6] { 5, 0, lightConfigList[0].Green, lightConfigList[0].Green, Queue0[0], ArrivalRate0[0] };
                    double[] road2 = new double[6] { 5, 0, lightConfigList[0].Green, lightConfigList[0].Green, Queue0[1], ArrivalRate0[1] };
                    double[] road3 = new double[6] { 5, 1, lightConfigList[1].Green, lightConfigList[1].Green, Queue1[0], ArrivalRate1[0] };
                    double[] road4 = new double[6] { 5, 1, lightConfigList[1].Green, lightConfigList[1].Green, Queue1[1], ArrivalRate1[1] };

                    List<double[]> roadsData = new List<double[]>();
                    roadsData.Add(road1);
                    roadsData.Add(road2);
                    roadsData.Add(road3);
                    roadsData.Add(road4);

                    GA_Optimization optimization = new GA_Optimization();
                    List<int> optimizedGreen = optimization.GAOptimize(roadsData);
                    //GA end

                    List<LightConfig> optimizedConfig = new List<LightConfig>();

                    for (int i = 0; i < lightConfigList.Count; i++)
                    {
                        LightConfig newConfig = new LightConfig(optimizedGreen[i], 2);
                        optimizedConfig.Add(newConfig);
                    }

                    SetIntersectionLightConfig(optimizedConfig);

                    for (int i = 0; i < this.lightConfigList.Count; i++)
                    {
                        LightConfig config = new LightConfig(lightConfigList[i].Green, lightConfigList[i].Yellow);
                        config.Red = lightConfigList[i].Red;
                        config.TempRed = lightConfigList[i].TempRed;

                        newOptimizationRecord.AddOptimizedConfiguration(config);
                    }

                }// if (IAWR > this.IAWRThreshold)

                latestOptimizationCycle = currentCycle;

                Simulator.DataManager.StoreOptimizationRecord(intersectionID, newOptimizationRecord);

                DynamicIAWR(currentIAWR);

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

        public void DynamicIAWR(double currentIAWR)
        {
            double increaseRate = 0.03;

            if(dynamicIAWR) 
            {
                double newIAWRThreshold;

                if (currentIAWR > IAWRThreshold) //optimize
                {
                    newIAWRThreshold = currentIAWR * (1 + increaseRate);
                    unOptimizedeCounter = 0;
                }
                else //no optimize
                {
                    if (unOptimizedeCounter < 5) //max of  unOptimizedeCounter is 5
                        unOptimizedeCounter++; 

                    newIAWRThreshold = (IAWRThreshold * (10 - unOptimizedeCounter) + (currentIAWR * unOptimizedeCounter)) / 10;
                }

                IAWRThreshold = Math.Round(newIAWRThreshold, 2, MidpointRounding.AwayFromZero);
            }


        }

    }
}