using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using SmartTrafficSimulator.SystemObject;

namespace SmartTrafficSimulator.SystemManagers
{
    class PrototypeManager
    {
        public Boolean PrototypeConnected = false; //Prototype 是否連接上 
        public Boolean WaittingConnection = false;
        
        IPAddress localIP;
        int port = 12000;
        TcpListener TL;

        TcpClient prototypeSocket;
        Thread WaitProConThread;
        Thread ReceMsgThread;

        public void PrototypeManagerStart()
        {
            if (!PrototypeConnected)
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
                            Simulator.UI.AddMessage("Prototype", "Simulator IP : " + ipaddress);
                        }
                    }

                    WaitProConThread = new Thread(new ThreadStart(WaittingConnect));
                    WaitProConThread.Start();
                }
                else
                {
                    WaitProConThread.Interrupt();
                    TL.Stop();
                    WaittingConnection = false;
                    Simulator.UI.RefreshPrototypeStatus();
                    Simulator.UI.AddMessage("Prototype", "Waiting terminate");
                }
            }
            else
            {
                Simulator.UI.AddMessage("Prototype", "Prototype is connected");
            }
        }

        public void WaittingConnect()
        {
            Simulator.UI.AddMessage("Prototype", "Wait for prototype connecting...");
            TL = new TcpListener(localIP,port);
            TL.Start();

            WaittingConnection = true;
            Simulator.UI.RefreshPrototypeStatus();

            try
            {
                prototypeSocket = TL.AcceptTcpClient();
                Simulator.UI.AddMessage("Prototype", "Prototype connect");

                PrototypeConnected = true;
                WaittingConnection = false;

                Simulator.UI.RefreshPrototypeStatus();

                //開始接收訊息
                ReceMsgThread = new Thread(new ThreadStart(ReceiveMessage));
                ReceMsgThread.Start();
            }
            catch (SocketException e)
            {
            }
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
                Simulator.UI.AddMessage("Prototype", "Prototype disconnected");
                PrototypeConnected = false;
                Simulator.UI.RefreshPrototypeStatus();
            }
        }

        public void PrototypeStart()
        {
            Simulator.UI.AddMessage("Prototype", "Prototype start");

            SendToPrototype("set_System_Start");

        }

        public void PrototypeStop()
        {
            Simulator.UI.AddMessage("Prototype", "Prototype stop");

            SendToPrototype("set_System_Stop");
        }

        public void PrototypeSynchronous()
        {
            if (PrototypeConnected)
            {
                int intersections = Simulator.IntersectionManager.GetNumberOfIntersections();

                for (int interNo = 0; interNo < intersections; interNo++)
                {
                    IntersectionSynchronous(interNo);
                }
                Simulator.UI.AddMessage("Prototype", "Prototype synchronous");
            }
            else
            {
                Simulator.UI.AddMessage("System", "Prototype disconnected");
            }

        }

        public void InitialProtype()
        {
            if (PrototypeConnected)
            {
                int intersections = Simulator.IntersectionManager.GetNumberOfIntersections();

                for (int interNo = 0; interNo < intersections; interNo++)
                {
                    setIntersectionConfiguration(interNo);
                    setIntersectionSignalTime(interNo);
                    IntersectionSynchronous(interNo);
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
                for (int roadNo = 0; roadNo < roadList.Count; roadNo++)
                {
                    commandValue += ("," + (roadNo + 1));
                    commandValue += ("," + roadList[roadNo].phaseNo);
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

                for (int configNo = 0; configNo < lightConfigList.Count; configNo++)
                {
                    commandValue += ("," + configNo); //設定編號
                    commandValue += ("," + lightConfigList[configNo].Green); //綠燈
                    commandValue += ("," + lightConfigList[configNo].Yellow); //黃燈
                    commandValue += ("," + lightConfigList[configNo].Red); //紅燈
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

                List<int[]> lightStateList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).signalStatusList;

                for (int stateNo = 0; stateNo < lightStateList.Count; stateNo++)
                {
                    commandValue += ("," + stateNo);
                    commandValue += ("," + lightStateList[stateNo][0]);
                    commandValue += ("," + lightStateList[stateNo][1]);
                }

                string command = commandType + "," + intersectionID + commandValue;

                Simulator.UI.AddMessage("Prototype", command);

                SendToPrototype(command);
            }
        }
    }
}