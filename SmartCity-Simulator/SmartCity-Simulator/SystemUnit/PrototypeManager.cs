using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using SmartCitySimulator.GraphicUnit;
using System.IO;
using SmartCitySimulator.Unit;

namespace SmartCitySimulator.SystemUnit
{
    class PrototypeManager
    {
        public Boolean PrototypeConnected = false; //Prototype 是否連接上 
        IPAddress localIP;
        TcpClient prototypeSocket;

        public void start()
        {
            String strHostName = Dns.GetHostName();
            IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);
            localIP = iphostentry.AddressList[0];

            WaitPrototypeConnect();
        }

        public void WaitPrototypeConnect() 
        {
            Thread WPCthread = new Thread(new ThreadStart(Waitting));
            WPCthread.Start();
        }

        public void Waitting()
        {
            TcpListener TL = new TcpListener(localIP, 12000);
            TL.Start();
            prototypeSocket = TL.AcceptTcpClient();

            SimulatorConfiguration.UI.AddMessage("Prototype", "Protype已連上");
            PrototypeConnected = true;

            //開始接收訊息
            Thread RMthread = new Thread(new ThreadStart(ReceiveMessage));
            RMthread.Start();
        }

        public void SendToPrototype(string message)
        {
            if (PrototypeConnected)
            {
                byte[] sendmessage = Encoding.UTF8.GetBytes(message);
                prototypeSocket.GetStream().Write(sendmessage, 0, sendmessage.Length);
            }
        }

        public void ReceiveMessage()
        {
            String receive;
            byte[] receive_b = new byte[8192];
            int Receivelength;

            try
            {
                while (true)
                {
                    Receivelength = prototypeSocket.GetStream().Read(receive_b, 0, prototypeSocket.ReceiveBufferSize);
                    receive = Encoding.UTF8.GetString(receive_b, 0, Receivelength);
                    SimulatorConfiguration.UI.AddMessage("Prototype", receive);
                }
            }
            catch (IOException e)
            {
                SimulatorConfiguration.UI.AddMessage("Prototype", "Prototype已斷線");
                PrototypeConnected = false;
                SimulatorConfiguration.UI.ChangePrototypeStatus(false);

                WaitPrototypeConnect();
            }
        }

        public void PrototypeStart()
        {
            SimulatorConfiguration.UI.AddMessage("Prototype", "Prototype Start");

            SendToPrototype("set_System_Start");

        }

        public void PrototypeStop()
        {
            SimulatorConfiguration.UI.AddMessage("Prototype", "Prototype Stop");

            SendToPrototype("set_System_Stop");
        }


        public void ProtypeInitialize()
        {
            int intersections = SimulatorConfiguration.IntersectionManager.IntersectionList.Count - 1; //路口數  去掉999號路口

            for (int i = 0; i < intersections; i++)
            {
                setIntersectionConfiguration(i);
                setIntersectionSignalTime(i);
                IntersectionSynchronous(i);
            }
        }

        public void setIntersectionConfiguration(int intersectionNo)
        {
            string commandType = "set_Intersection_Configuration";
            string commandValue = "";

            List<Road> roadList = SimulatorConfiguration.IntersectionManager.IntersectionList[intersectionNo].roadList;
            for (int r = 0; r < roadList.Count; r++)
            {
                commandValue += ("," + (r + 1) + "," + roadList[r].order);
            }

            string command = commandType + "," + intersectionNo + commandValue;

            SimulatorConfiguration.UI.AddMessage("Prototype", command);

            SendToPrototype(command);
        }

        public void setIntersectionSignalTime(int intersectionNo)
        {
            string commandType = "set_Intersection_SignalTime";
            string commandValue = "";

            List<int[]> lightSettingList = SimulatorConfiguration.IntersectionManager.IntersectionList[intersectionNo].LightSettingList;

            for (int r = 0; r < lightSettingList.Count; r++)
            {
                commandValue += ("," + (r + 1)); //路口編號
                commandValue += ("," + lightSettingList[r][0]); //綠燈
                commandValue += ("," + lightSettingList[r][1]); //黃燈
                commandValue += ("," + lightSettingList[r][2]); //紅燈
            }

            string command = commandType + "," + intersectionNo + commandValue;

            SimulatorConfiguration.UI.AddMessage("Prototype", command);

            SendToPrototype(command);
        }


        public void IntersectionSynchronous(int intersectionNo)
        {
            string commandType = "set_Intersection_SignalSync";
            string commandValue = "";

            List<int[]> lightStateList = SimulatorConfiguration.IntersectionManager.IntersectionList[intersectionNo].LightStateList;

            for (int r = 0; r < lightStateList.Count; r++)
            {
                commandValue += ("," + (r + 1)); //路口編號

                if (lightStateList[r][0] == 0)
                {
                    commandValue += ("," + lightStateList[r][1] + ",0,0"); //綠燈
                }
                else if (lightStateList[r][0] == 1)
                {
                    commandValue += (",0," + lightStateList[r][1] + ",0"); //綠燈
                }
                else if (lightStateList[r][0] == 2 || lightStateList[r][0] == 3)
                {
                    commandValue += (",0,0," + lightStateList[r][1]); //綠燈
                }
            }

            string command = commandType + "," + intersectionNo + commandValue;

            SimulatorConfiguration.UI.AddMessage("Prototype", command);

            SendToPrototype(command);


        }

       



    }
}
