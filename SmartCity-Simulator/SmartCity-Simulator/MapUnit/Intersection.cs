using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SmartCitySimulator.GraphicUnit;
using SmartCitySimulator.SystemUnit;
using System.Windows.Forms;
using System.Collections;
using signalAI;

namespace SmartCitySimulator.Unit
{
    public class Intersection
    {
        int GREEN = 0, Yellow = 1, RED = 2, TEMPRED = 3;

        public int intersectionID;
        public string intersectionName;
        public List<Road> roadList;
        public List<int[]> LightSettingList;
        public List<int[]> LightStateList;

        //預存的設定 TR時使用
        public List<int[]> newSetting;

        //優化相關參數
        public int currentCycle = 0; //以order 0 結束紅燈時算一個cycle
        public int latestOptimizeCycle = 0;
        public int optimizeInerval = 5;
        public double IWARThreshold = 55.0;


        public Intersection(int intersectionID)
        {
            this.intersectionID = intersectionID;
            this.intersectionName = "default";
            this.roadList = new List<Road>();
            this.LightSettingList = new List<int[]>();      //存放設定秒數(index : 0 = 綠,1 = 黃,2 = 紅)
            this.LightStateList = new List<int[]>();        //int[]中，[0]為目前紅綠燈狀態(0紅1綠2黃)；[1]為目前倒數秒數
        }

        public void AddNewLightSetting(int[] newSetting) //newSrtting [0] = 新綠燈 [1]= 新黃燈
        {
            int[] newSettingToAdd = { newSetting[0], newSetting[1], 0, 0 };

            LightSettingList.Add(newSettingToAdd);

            CalculateRedLight();

            RenewLightStateList();

            RefreshLightGraphicDisplay();
        }

        public void DeleteLightSetting(int order)
        {
            LightSettingList.RemoveAt(order);

            CalculateRedLight();

            RenewLightStateList();

            RefreshLightGraphicDisplay();

        }

        public void ModifyLightSetting(List<int[]> newSettingToApply)
        {
            newSetting = newSettingToApply;

            if (!Simulator.simulatorStarted)
            {
                for (int i = 0; i < LightSettingList.Count; i++)
                {
                    OverwriteLightSetting(i, newSettingToApply[i]);
                }
                CalculateRedLight();
                RenewLightStateList();
                RefreshLightGraphicDisplay();
            }
            else
            {
                if (LightSettingList.Count > 2)
                    CalculateTemporarilyRedLight();
                else
                {
                    for (int i = 0; i < LightSettingList.Count; i++)
                    {
                        OverwriteLightSetting(i, newSettingToApply[i]);
                    }
                }
                CalculateRedLight();
            }

            //Test code
            if (Simulator.TESTMODE)
            {
                for (int i = 0; i < LightSettingList.Count; i++)
                {
                    for (int j = 0; j < LightSettingList[i].Length; j++)
                        Console.Write("Light Sstting" + i + " : " + LightSettingList[i][j]);
                    Console.WriteLine();
                }
            }
        }

        public void OverwriteLightSetting(int order, int[] newSetting)
        {
            LightSettingList[order][0] = newSetting[0];
            LightSettingList[order][1] = newSetting[1];
        }

        public void CalculateTemporarilyRedLight()
        {
            Simulator.UI.AddMessage("System", "Intersection :" + intersectionID + " Run TR");

            int intsectionDirection = LightSettingList.Count;

            List<int[]> nowSetting = new List<int[]>();

            for (int a = 0; a < LightSettingList.Count; a++)
            {
                int[] setting = { LightSettingList[a][0], LightSettingList[a][1] };
                nowSetting.Add(setting);
            }


            for (int i = 0; i < intsectionDirection; i++)
            {
                if (LightStateList[i][0] == 0 || LightStateList[i][0] == 1)
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
                            LightSettingList[j % intsectionDirection][3] += nowSetting[k % intsectionDirection][0];
                            LightSettingList[j % intsectionDirection][3] += nowSetting[k % intsectionDirection][1];
                        }//for
                    }//for
                }//if
            }//for
        }

        public void CalculateRedLight()
        {
            int totalRed = 0;
            for (int i = 0; i < LightSettingList.Count; i++)
            {
                totalRed += (LightSettingList[i][0] + LightSettingList[i][1]);
            }

            for (int i = 0; i < LightSettingList.Count; i++)
            {
                LightSettingList[i][2] = (totalRed - (LightSettingList[i][0] + LightSettingList[i][1]));
            }

            OutputLightSettingToUI();

            Simulator.PrototypeManager.setIntersectionSignalTime(System.Convert.ToInt16(intersectionID));
        }

        public void RenewLightStateList()
        {
            LightStateList.Clear();

            for (int a = 0; a < LightSettingList.Count; a++)
            {
                if (a == 0)
                {
                    int[] state = { 0, LightSettingList[a][0] };
                    LightStateList.Add(state);
                }
                else
                {
                    int redSecond = 0;
                    for (int b = 0; b < a; b++)
                    {
                        redSecond += (LightSettingList[b][0] + LightSettingList[b][1]);
                    }
                    int[] state = { 2, redSecond };
                    LightStateList.Add(state);
                }
            }
        }

        public void RefreshLightGraphicDisplay()
        {
            for (int i = 0; i < roadList.Count; i++)
            {
                int lightOrder = roadList[i].order;
                if (lightOrder >= LightStateList.Count)
                {
                    roadList[i].order = 0;
                    lightOrder = 0;
                }
                roadList[i].setLightState(LightStateList[lightOrder][0], LightStateList[lightOrder][1]);
            }
        }

        public void OutputLightSettingToUI()
        {
            for (int i = 0; i < LightSettingList.Count; i++)
            {
                Simulator.UI.AddMessage("System", "Order : " + i +
                    " G : " + LightSettingList[i][0] +
                    " Y : " + LightSettingList[i][1] +
                    " R : " + LightSettingList[i][2] +
                    " TR : " + LightSettingList[i][3]);
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
            int allOrders = LightStateList.Count;

            for (int order = 0; order < LightStateList.Count; order++)
            {
                LightStateList[order][1]--;

                if (LightStateList[order][1] <= 0)//倒數結束
                {
                    if (LightStateList[order][0] == this.GREEN)
                        this.ToYellow(order);

                    else if (LightStateList[order][0] == this.Yellow)
                    {
                        if (LightSettingList[order][3] > 0)//有TR時執行TR
                            this.ToTempRed(order);
                        else
                            this.ToRed(order);
                    }
                    else if (LightStateList[order][0] == this.RED || LightStateList[order][0] == this.TEMPRED)
                        this.ToGreen(order);

                    Simulator.IntersectionManager.callRefreshRequest();
                }
            }

            if (LightStateList.Count > 0)
                RefreshLightGraphicDisplay();

        }//LightCountDown end

        public void ToGreen(int order)
        {
            SaveRoadRecords(order);//輸出上一階段的資訊(綠 & 紅)

            if (order == 0)
            {
                if (currentCycle >= latestOptimizeCycle + optimizeInerval && intersectionID ==4)
                {
                    IntersectionOptimize();
                }
                currentCycle++;
            }

            LightStateList[order][0] = this.GREEN;//紅燈轉綠燈
            LightStateList[order][1] = LightSettingList[order][LightStateList[order][0]];
        }
        public void ToYellow(int order)
        {
            LightStateList[order][0] = this.Yellow;
            LightStateList[order][1] = LightSettingList[order][LightStateList[order][0]];
        }
        public void ToRed(int order)
        {
            LightStateList[order][0] = this.RED;
            LightStateList[order][1] = LightSettingList[order][LightStateList[order][0]];
        }
        public void ToTempRed(int order)
        {
            LightStateList[order][0] = this.TEMPRED;
            LightStateList[order][1] = LightSettingList[order][LightStateList[order][0]];
            LightSettingList[order][3] = 0;//清空TR避免再次執行

            int renewOrder = (order + LightStateList.Count - 1) % LightStateList.Count;

            OverwriteLightSetting(renewOrder, newSetting[renewOrder]);

            CalculateRedLight();
        }

        public void IntersectionOptimize()
        {
            double IWAR = Simulator.DataManager.GetIntersectionAvgWaitingRate(this.intersectionID, latestOptimizeCycle, currentCycle);
            if (IWAR > this.IWARThreshold)
            {
                Simulator.UI.AddMessage("AI", "Intersection : " + intersectionID + " IWAR : " + IWAR + "(" + latestOptimizeCycle + "~" + currentCycle + ")");

                int curGtA1 = LightSettingList[0][0];
                int curGtB1 = 30, curGtC1 = 30;
                int curGtA2 = LightSettingList[1][0];
                int curGtB2 = 30, curGtC2 = 30;
                int intersectionID1 = 5;
                int vector1 = 0;
                int intersectionID2 = 5;
                int vector2 = 1;

                List<double> Queue1 = new List<double>();
                List<double> Queue2 = new List<double>();

                List<double> ArrivalRate1 = new List<double>();
                List<double> ArrivalRate2 = new List<double>();

                for (int roadIndex = 0; roadIndex < roadList.Count; roadIndex++)
                {
                    if (roadList[roadIndex].order == 0)
                    {
                        Queue1.Add(Simulator.DataManager.GetAvgWaittingCars(roadList[roadIndex].roadID, latestOptimizeCycle, currentCycle));
                        ArrivalRate1.Add(Simulator.DataManager.GetArrivalRate(roadList[roadIndex].roadID, latestOptimizeCycle, currentCycle));
                    }
                    else if (roadList[roadIndex].order == 1)
                    {
                        Queue2.Add(Simulator.DataManager.GetAvgWaittingCars(roadList[roadIndex].roadID, latestOptimizeCycle, currentCycle));
                        ArrivalRate2.Add(Simulator.DataManager.GetArrivalRate(roadList[roadIndex].roadID, latestOptimizeCycle, currentCycle));
                    }
                }

                Optimization optimization = new Optimization();
                List<int> optimizedGreen = optimization.GA(intersectionID1, vector1, Queue1[0], Queue1[1], ArrivalRate1[0], ArrivalRate1[1], curGtA1, curGtB1, curGtC1,
                              intersectionID2, vector2, Queue2[0], Queue2[1], ArrivalRate2[0], ArrivalRate2[1], curGtA2, curGtB2, curGtC2);

                List<int[]> optimizedSetting = new List<int[]>();

                for (int i = 0; i < LightSettingList.Count; i++)
                {
                    int[] setting = {optimizedGreen[i],2};
                    optimizedSetting.Add(setting);
                }

                ModifyLightSetting(optimizedSetting);
            }

            latestOptimizeCycle = currentCycle;
        }

        public void setOptimizeInterval(int interval)
        {
            optimizeInerval = interval;
        }

    }
}