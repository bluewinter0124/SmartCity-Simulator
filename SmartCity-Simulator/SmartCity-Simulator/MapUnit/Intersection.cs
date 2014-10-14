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

        public int intersectionID = -1;
        public string intersectionName = "default";
        public List<Road> roadList;
        public List<int[]> lightSettingList;
        public List<int[]> lightStateList;

        //預存的設定 TR時使用
        public List<int[]> newSetting;

        //優化相關參數
        public int currentCycle = 0; //以order 0 結束紅燈時算一個cycle
        public int latestOptimizeCycle = 0;
        public int optimizeInerval;
        public double IAWRThreshold;


        public Intersection(int intersectionID)
        {
            this.intersectionID = intersectionID;
            roadList = new List<Road>();
        }

        public void Initialize()
        {
            lightSettingList = new List<int[]>();      //存放設定秒數(index : 0 = 綠,1 = 黃,2 = 紅)
            lightStateList = new List<int[]>();        //int[]中，[0]為目前紅綠燈狀態(0紅1綠2黃)；[1]為目前倒數秒數

            optimizeInerval = Simulator.IntersectionManager.defaultOptimizeInerval;
            IAWRThreshold = Simulator.IntersectionManager.defaultIAWR;
            latestOptimizeCycle = 0;
            currentCycle = 0;
        }

        public void AddNewLightSetting(int newGreen,int newYellow) //newSrtting [0] = 新綠燈 [1]= 新黃燈
        {
            int[] newSettingToAdd = { newGreen, newYellow, 0, 0 };

            lightSettingList.Add(newSettingToAdd);

            CalculateRedLight();

            RenewLightStateList();

            RefreshLightGraphicDisplay();
        }

        public void DeleteLightSetting(int order)
        {
            lightSettingList.RemoveAt(order);

            CalculateRedLight();

            RenewLightStateList();

            RefreshLightGraphicDisplay();

        }

        public void SetIntersectionLightSetting(List<int[]> newIntLightSetting)
        {
            newSetting = newIntLightSetting;

            if (!Simulator.simulatorStarted)
            {
                for (int i = 0; i < lightSettingList.Count; i++)
                {
                    SetLightSetting(i, newIntLightSetting[i]);
                }
                CalculateRedLight();
                RenewLightStateList();
                RefreshLightGraphicDisplay();
            }
            else
            {
                if (lightSettingList.Count > 2)
                    CalculateTemporarilyRedLight();
                else
                {
                    for (int i = 0; i < lightSettingList.Count; i++)
                    {
                        SetLightSetting(i, newIntLightSetting[i]);
                    }
                }
                CalculateRedLight();
            }

            //Test code
            if (Simulator.TESTMODE)
            {
                for (int i = 0; i < lightSettingList.Count; i++)
                {
                    for (int j = 0; j < lightSettingList[i].Length; j++)
                        Console.Write("Light Sstting" + i + " : " + lightSettingList[i][j]);
                    Console.WriteLine();
                }
            }
        }

        public void SetLightSetting(int order, int[] newSetting)
        {
            lightSettingList[order][0] = newSetting[0];
            lightSettingList[order][1] = newSetting[1];
        }

        public void CalculateTemporarilyRedLight()
        {
            Simulator.UI.AddMessage("System", "Intersection :" + intersectionID + " Run TR");

            int intsectionDirection = lightSettingList.Count;

            List<int[]> nowSetting = new List<int[]>();

            for (int a = 0; a < lightSettingList.Count; a++)
            {
                int[] setting = { lightSettingList[a][0], lightSettingList[a][1] };
                nowSetting.Add(setting);
            }


            for (int i = 0; i < intsectionDirection; i++)
            {
                if (lightStateList[i][0] == 0 || lightStateList[i][0] == 1)
                {
                    for (int j = i; j <= i + intsectionDirection - 1; j++)
                    {
                        for (int k = j + 1; k <= j + intsectionDirection - 1; k++)
                        {
                            if (k == j + intsectionDirection - 1)
                            {
                                nowSetting[k % intsectionDirection][0] = newSetting[k % intsectionDirection][0];
                                nowSetting[k % intsectionDirection][1] = newSetting[k % intsectionDirection][1];
                            }//if
                            lightSettingList[j % intsectionDirection][3] += nowSetting[k % intsectionDirection][0];
                            lightSettingList[j % intsectionDirection][3] += nowSetting[k % intsectionDirection][1];
                        }//for
                    }//for
                }//if
            }//for
        }

        public void CalculateRedLight()
        {
            int totalRed = 0;
            for (int i = 0; i < lightSettingList.Count; i++)
            {
                totalRed += (lightSettingList[i][0] + lightSettingList[i][1]);
            }

            for (int i = 0; i < lightSettingList.Count; i++)
            {
                lightSettingList[i][2] = (totalRed - (lightSettingList[i][0] + lightSettingList[i][1]));
            }

            OutputLightSettingToUI();

            Simulator.PrototypeManager.setIntersectionSignalTime(System.Convert.ToInt16(intersectionID));
        }

        public void RenewLightStateList()
        {
            lightStateList.Clear();

            for (int a = 0; a < lightSettingList.Count; a++)
            {
                if (a == 0)
                {
                    int[] state = { 0, lightSettingList[a][0] };
                    lightStateList.Add(state);
                }
                else
                {
                    int redSecond = 0;
                    for (int b = 0; b < a; b++)
                    {
                        redSecond += (lightSettingList[b][0] + lightSettingList[b][1]);
                    }
                    int[] state = { 2, redSecond };
                    lightStateList.Add(state);
                }
            }
        }

        public int CycleTime()
        {
            return lightSettingList[0][0] + lightSettingList[0][1] + lightSettingList[0][2];
        }

        public void RefreshLightGraphicDisplay()
        {
            for (int i = 0; i < roadList.Count; i++)
            {
                int lightOrder = roadList[i].order;
                if (lightOrder >= lightStateList.Count)
                {
                    roadList[i].order = 0;
                    lightOrder = 0;
                }
                roadList[i].setLightState(lightStateList[lightOrder][0], lightStateList[lightOrder][1]);
            }
        }

        public void OutputLightSettingToUI()
        {
            for (int i = 0; i < lightSettingList.Count; i++)
            {
                Simulator.UI.AddMessage("System", "Order : " + i +
                    " G : " + lightSettingList[i][0] +
                    " Y : " + lightSettingList[i][1] +
                    " R : " + lightSettingList[i][2] +
                    " TR : " + lightSettingList[i][3]);
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
                        if (lightSettingList[order][3] > 0)//有TR時執行TR
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
                RefreshLightGraphicDisplay();

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
            lightStateList[order][1] = lightSettingList[order][lightStateList[order][0]];
        }
        public void ToYellow(int order)
        {
            lightStateList[order][0] = this.SIGNAL_YELLOW;
            lightStateList[order][1] = lightSettingList[order][lightStateList[order][0]];
        }
        public void ToRed(int order)
        {
            lightStateList[order][0] = this.SIGNAL_RED;
            lightStateList[order][1] = lightSettingList[order][lightStateList[order][0]];
        }
        public void ToTempRed(int order)
        {
            lightStateList[order][0] = this.SIGNAL_TEMPRED;
            lightStateList[order][1] = lightSettingList[order][lightStateList[order][0]];
            lightSettingList[order][3] = 0;//清空TR避免再次執行

            int renewOrder = (order + lightStateList.Count - 1) % lightStateList.Count;

            SetLightSetting(renewOrder, newSetting[renewOrder]);

            CalculateRedLight();
        }

        public void IntersectionStateAnalysis()
        {
            double IAWR = Simulator.DataManager.GetIntersectionAvgWaitingRate(this.intersectionID, latestOptimizeCycle, currentCycle);
            //double IAWR = Simulator.DataManager.GetIntersectionAvgWaitingRate(this.intersectionID, currentCycle + 1 - optimizeInerval, currentCycle);
            int state = 0;
            if(IAWR > 65)
                state = 2;
            else if(IAWR > 50)
                state = 1;

            Simulator.UI.RefreshIntersectionState(intersectionID, IAWR, state);

            if (Simulator.IntersectionManager.AIOptimazation) //有開啟優化
            {
                if (currentCycle >= latestOptimizeCycle + optimizeInerval) //確認是否達到優化週期限制
                {
                    if (IAWR > this.IAWRThreshold) //判斷是否需要優化
                    {
                        Simulator.UI.AddMessage("AI", "Intersection : " + intersectionID + " IAWR : " + IAWR + "(" + latestOptimizeCycle + "~" + currentCycle + ")");
                        IntersectionOptimize();
                    }

                    latestOptimizeCycle = currentCycle;
                }
            }
        }

        public void IntersectionOptimize()
        {

            int intersectionID1 = 5;
            int order1 = 0;
            int intersectionID2 = 5;
            int order2 = 1;

            int curGtA1 = lightSettingList[0][0];
            int curGtB1 = lightSettingList[0][0], curGtC1 = lightSettingList[0][0];
            int curGtA2 = lightSettingList[1][0];
            int curGtB2 = lightSettingList[1][0], curGtC2 = lightSettingList[1][0];

            List<double> Queue1 = new List<double>();
            List<double> Queue2 = new List<double>();

            List<double> ArrivalRate1 = new List<double>();
            List<double> ArrivalRate2 = new List<double>();

            for (int roadIndex = 0; roadIndex < roadList.Count; roadIndex++)
            {
                if (roadList[roadIndex].order == 0)
                {
                    Queue1.Add(Simulator.DataManager.GetAvgWaittingVehicles(roadList[roadIndex].roadID, latestOptimizeCycle, currentCycle));
                    ArrivalRate1.Add(Simulator.DataManager.GetArrivalRate(roadList[roadIndex].roadID, latestOptimizeCycle, currentCycle));
                }
                else if (roadList[roadIndex].order == 1)
                {
                    Queue2.Add(Simulator.DataManager.GetAvgWaittingVehicles(roadList[roadIndex].roadID, latestOptimizeCycle, currentCycle));
                    ArrivalRate2.Add(Simulator.DataManager.GetArrivalRate(roadList[roadIndex].roadID, latestOptimizeCycle, currentCycle));
                }
            }

            if (Queue1.Count < 2)
            {
                Queue1.Add(0.0);
                ArrivalRate1.Add(0.0);
            }

            if (Queue2.Count < 2)
            {
                Queue2.Add(0.0);
                ArrivalRate2.Add(0.0);
            }

            GAOptimization optimization = new GAOptimization();
            List<int> optimizedGreen = optimization.GA(intersectionID1, order1, Queue1[0], Queue1[1], ArrivalRate1[0], ArrivalRate1[1], curGtA1, curGtB1, curGtC1,
                            intersectionID2, order2, Queue2[0], Queue2[1], ArrivalRate2[0], ArrivalRate2[1], curGtA2, curGtB2, curGtC2);

            List<int[]> optimizedSetting = new List<int[]>();

            for (int i = 0; i < lightSettingList.Count; i++)
            {
                int[] setting = {optimizedGreen[i],2};
                optimizedSetting.Add(setting);
            }

            SetIntersectionLightSetting(optimizedSetting);
        }

    }
}