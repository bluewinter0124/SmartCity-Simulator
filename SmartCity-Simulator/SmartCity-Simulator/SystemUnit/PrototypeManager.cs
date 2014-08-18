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

        public void PrototypeManagerStart()
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
            prototypeSocket = TL.AcceptTcpClient();
            Simulator.UI.AddMessage("Prototype", "Prototype已連上");
            PrototypeConnected = true;
            Simulator.UI.ChangePrototypeStatus(PrototypeConnected);

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
                Simulator.UI.ChangePrototypeStatus(PrototypeConnected);

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
            int intersections = Simulator.IntersectionManager.GetTotalIntersections();

            for (int i = 0; i < intersections; i++)
            {
                setIntersectionConfiguration(i);
                setIntersectionSignalTime(i);
                IntersectionSynchronous(i);
            }
        }

        public void setIntersectionConfiguration(int intersectionID)
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

        public void setIntersectionSignalTime(int intersectionID)
        {
            string commandType = "set_Intersection_SignalTime";
            string commandValue = "";

            List<int[]> lightSettingList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).LightSettingList;

            for (int r = 0; r < lightSettingList.Count; r++)
            {
                commandValue += ("," + (r + 1)); //路口編號
                commandValue += ("," + lightSettingList[r][0]); //綠燈
                commandValue += ("," + lightSettingList[r][1]); //黃燈
                commandValue += ("," + lightSettingList[r][2]); //紅燈
            }

            string command = commandType + "," + intersectionID + commandValue;

            Simulator.UI.AddMessage("Prototype", command);

            SendToPrototype(command);
        }


        public void IntersectionSynchronous(int intersectionID)
        {
            string commandType = "set_Intersection_SignalSync";
            string commandValue = "";

            List<int[]> lightStateList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).LightStateList;

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

            string command = commandType + "," + intersectionID + commandValue;

            Simulator.UI.AddMessage("Prototype", command);

            SendToPrototype(command);


        }

       



    }
}
