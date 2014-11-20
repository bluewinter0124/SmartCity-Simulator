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

namespace SmartCitySimulator.SystemObject
{
    class PrototypeManager
    {
        public Boolean PrototypeConnected = false; //Prototype 是否連接上 
        public Boolean WaittingConnection = false;
        
        IPAddress localIP;
        TcpClient prototypeSocket;

        public void PrototypeManagerStart()
        {
            if (!WaittingConnection)
            {
                String strHostName = Dns.GetHostName();
                IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);

                foreach (IPAddress ipaddress in iphostentry.AddressList)
                {
                    if (ipaddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        localIP = ipaddress;
                        Simulator.UI.AddMessage("Prototype", "連接IP : " + ipaddress);
                    }
                }

                WaitPrototypeConnect();
            }
            else 
            {
                Simulator.UI.AddMessage("Prototype", "等待連接中...");
            }
        }

        public void WaitPrototypeConnect() 
        {
            Thread WPCthread = new Thread(new ThreadStart(Waitting));
            WPCthread.Start();
        }

        public void Waitting()
        {

            Simulator.UI.AddMessage("Prototype", "等待Prototype連接...");
            TcpListener TL = new TcpListener(localIP, 12000);
            TL.Start();
            WaittingConnection = true;
            Simulator.UI.RefreshPrototypeStatus();

            prototypeSocket = TL.AcceptTcpClient();
            Simulator.UI.AddMessage("Prototype", "Prototype已連上");

            PrototypeConnected = true;
            WaittingConnection = false;

            Simulator.UI.RefreshPrototypeStatus();

            //開始接收訊息
            Thread RMthread = new Thread(new ThreadStart(ReceiveMessage));
            RMthread.Start();
        
        }

        public void SendToPrototype(string message)
        {
            if (PrototypeConnected)
            {
                byte[] sendmessage = Encoding.UTF8.GetBytes(message+"\n");
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
                    Simulator.UI.AddMessage("Prototype", receive);
                }
            }
            catch (IOException e)
            {
                Simulator.UI.AddMessage("Prototype", "Prototype已斷線");
                PrototypeConnected = false;
                Simulator.UI.RefreshPrototypeStatus();

                WaitPrototypeConnect();
            }
        }

        public void PrototypeStart()
        {
            Simulator.UI.AddMessage("Prototype", "Prototype Start");

            SendToPrototype("set_System_Start");

        }

        public void PrototypeStop()
        {
            Simulator.UI.AddMessage("Prototype", "Prototype Stop");

            SendToPrototype("set_System_Stop");
        }


        public void ProtypeInitialize()
        {
            if (PrototypeConnected)
            {
                int intersections = Simulator.IntersectionManager.CountIntersections();

                for (int i = 0; i < intersections; i++)
                {
                    setIntersectionConfiguration(i);
                    setIntersectionSignalTime(i);
                    IntersectionSynchronous(i);
                }
            }
        }

        public void setIntersectionConfiguration(int intersectionID)
        {
            if (PrototypeConnected)
            {
                string commandType = "set_Intersection_Configuration";
                string commandValue = "";

                List<Road> roadList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).roadList;
                for (int r = 0; r < roadList.Count; r++)
                {
                    commandValue += ("," + (r + 1) + "," + roadList[r].order);
                }

                string command = commandType + "," + intersectionID + commandValue;

                Simulator.UI.AddMessage("Prototype", command);

                SendToPrototype(command);
            }
        }

        public void setIntersectionSignalTime(int intersectionID)
        {
            if (PrototypeConnected)
            {
                string commandType = "set_Intersection_SignalTime";
                string commandValue = "";

                List<SignalConfig> lightConfigList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).signalConfigList;

                for (int r = 0; r < lightConfigList.Count; r++)
                {
                    commandValue += ("," + (r + 1)); //設定編號
                    commandValue += ("," + lightConfigList[r].Green); //綠燈
                    commandValue += ("," + lightConfigList[r].Yellow); //黃燈
                    commandValue += ("," + lightConfigList[r].Red); //紅燈
                }

                string command = commandType + "," + intersectionID + commandValue;

                Simulator.UI.AddMessage("Prototype", command);

                SendToPrototype(command);
            }
        }


        public void IntersectionSynchronous(int intersectionID)
        {
            if (PrototypeConnected)
            {
                string commandType = "set_Intersection_SignalSync";
                string commandValue = "";

                List<int[]> lightStateList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).signalStateList;

                for (int r = 0; r < lightStateList.Count; r++)
                {
                    commandValue += ("," + (r + 1) + "," + lightStateList[r][0] + "," + lightStateList[r][1]);
                }

                string command = commandType + "," + intersectionID + commandValue;

                Simulator.UI.AddMessage("Prototype", command);

                SendToPrototype(command);
            }
        }
    }
}
