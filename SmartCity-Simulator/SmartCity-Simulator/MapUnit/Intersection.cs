using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SmartCitySimulator.GraphicUnit;
using SmartCitySimulator.SystemUnit;
using System.Windows.Forms;
using System.Collections;

namespace SmartCitySimulator.Unit
{
    public class Intersection
    {
        public string intersectionName;
        public List<Road> roadList;
        public List<int[]> LightSettingList;
        public List<int[]> LightStateList;

        public List<int[]> newSetting;

        public Intersection()
        {
            this.intersectionName = "";
            this.roadList = new List<Road>();
            this.LightSettingList = new List<int[]>();      //存放設定秒數(index : 0 = 綠,1 = 黃,2 = 紅)
            this.LightStateList = new List<int[]>();        //int[]中，[0]為目前紅綠燈狀態(0紅1綠2黃)；[1]為目前倒數秒數
        }

        public void AddLightSetting(int[] newSetting) //newSrtting [0] = 新綠燈 [1]= 新黃燈
        {
            int[] newSettingToAdd = { newSetting[0], newSetting[1], 0, 0 };

            LightSettingList.Add(newSettingToAdd);

            CalculateRedLight();

            RenewLightStateList();

            RefreshIntersectionLightDisplay();
        }

        public void DeleteLightSetting(int order)
        {
            LightSettingList.RemoveAt(order);

            CalculateRedLight();
                
            RenewLightStateList();
               
            RefreshIntersectionLightDisplay();

        }

        public void ModifyLightSetting(List<int[]> newSettingToModify)
        {
            newSetting = newSettingToModify;
            
            if (!Simulator.simulatorStarted)
            {
                for (int i = 0; i < LightSettingList.Count; i++)
                {
                    RewriteLightSetting(i, newSettingToModify[i]);
                }
                    CalculateRedLight();
                    RenewLightStateList();
                    RefreshIntersectionLightDisplay();
            }
            else
            {
                if (LightSettingList.Count > 2)
                    CalculateTemporarilyRedLight();
                else 
                {
                    for (int i = 0; i < LightSettingList.Count; i++)
                    {
                        RewriteLightSetting(i, newSettingToModify[i]);
                    }
                }
                CalculateRedLight();
            }

            /* Test Code
            for (int i = 0; i < LightSettingList.Count; i++)
            {
                for (int j = 0; j < LightSettingList[i].Length;j++)
                    Console.Write("LS"+ i +" : " + LightSettingList[i][j]);
                Console.WriteLine();
            }*/


        }

        public void RewriteLightSetting(int order,int[] newSetting)
        {
            LightSettingList[order][0] = newSetting[0];
            LightSettingList[order][1] = newSetting[1];
        }

        public void CalculateTemporarilyRedLight()
        {
            Simulator.UI.AddMessage("System", "Intersection :" + intersectionName + " Run TR");

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

            Simulator.PrototypeManager.setIntersectionSignalTime(System.Convert.ToInt16(intersectionName));
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
                    int[] state = { 2, redSecond};
                    LightStateList.Add(state);
                }
            }
        }

        public void RefreshIntersectionLightDisplay()
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


        public void OutputAllRoadStatistics(int order) 
        {
            for (int i = 0; i < roadList.Count; i++)
            {
                if (roadList[i].order == order)
                {
                    roadList[i].SaveData(true);
                }
            }
        }

        public void IntersectionCountDown()
        {
            //SimulatorConfiguration.UI.AddMessage("System", "Count");
            int orders = LightStateList.Count;

            for (int i = 0; i < LightStateList.Count; i++)
            {
                LightStateList[i][1] --;

                if (LightStateList[i][1] <= 0)//倒數結束
                {
                    if (LightStateList[i][0] == 0)
                    {
                        LightStateList[i][0] = 1;
                        LightStateList[i][1] = LightSettingList[i][LightStateList[i][0]];
                    }

                    else if (LightStateList[i][0] == 1)
                    {
                        if (LightSettingList[i][3] > 0)//有TR時執行TR
                        {
                            LightStateList[i][0] = 3;
                            LightStateList[i][1] = LightSettingList[i][3];
                            LightSettingList[i][3] = 0;
                            int renew = (i + orders - 1) % orders;
                            RewriteLightSetting(renew, newSetting[renew]);
                            CalculateRedLight();
                        }
                        else
                        {
                            LightStateList[i][0] = 2;
                            LightStateList[i][1] = LightSettingList[i][LightStateList[i][0]];
                        }
                    }

                    else if (LightStateList[i][0] == 2 || LightStateList[i][0] == 3)
                    {
                        LightStateList[i][0] = 0;//紅燈轉綠燈
                        LightStateList[i][1] = LightSettingList[i][LightStateList[i][0]];

                        OutputAllRoadStatistics(i);//輸出上一階段的資訊(綠 & 紅)
                    }

                    Simulator.IntersectionManager.callRefreshRequest();
                }
            }

            if (LightStateList.Count > 0)
                RefreshIntersectionLightDisplay();
        }
    }
}
