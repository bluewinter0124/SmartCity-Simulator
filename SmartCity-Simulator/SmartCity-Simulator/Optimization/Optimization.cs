using SmartCitySimulator.SystemObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCitySimulator.Optimization
{
    class Optimization
    {
        List<int> greenLightConfigs;
        List<int> roadOrder;
        List<double> roadAvgVehicles;
        List<double> roadAvgQueues;
        int constrain = 10;

        public void AddRoad(int greenLightConfig, int order, double avgVehicle, double avgQueue)
        {
            this.roadOrder.Add(order);
            this.greenLightConfigs.Add(greenLightConfig);
            this.roadAvgVehicles.Add(avgVehicle);
            this.roadAvgQueues.Add(avgQueue);
        }

        /*public List<int> Optimize()
        {
            Dictionary<int,double> orderAvgVehicles = new Dictionary<int,double>();
            Dictionary<int,double> orderAvgQueues = new Dictionary<int,double>();
            Dictionary<int, int> orderGreenConfig = new Dictionary<int,int>();

            for (int road = 0; road < roadOrder.Count; road++)
            {
                if (!orderGreenConfig.ContainsKey(roadOrder[road]))
                    orderGreenConfig.Add(roadOrder[road], greenLightConfigs[road]);
            }

            int[] orders = orderGreenConfig.Keys.ToArray();
            int CycleTime = 0;
            double totalVehicles = 0;

            for (int i = 0; i < orders.Length; i++)
            {
                int order = orders[i];

                double vehicles = 0;
                double vehicleWithWeight = 0;
                double queueWithWeight = 0;

                for (int road = 0; road < roadOrder.Count; road++)
                {
                    if (roadOrder[road] == order)
                    {
                        vehicles += roadAvgVehicles[road];
                        vehicleWithWeight += (roadAvgVehicles[road] * roadAvgVehicles[road]);
                        queueWithWeight += (roadAvgVehicles[road] * roadAvgQueues[road]);
                    }
                }

                vehicleWithWeight /= vehicles;
                queueWithWeight /= vehicles;

                orderAvgVehicles.Add(order, vehicleWithWeight);
                orderAvgQueues.Add(order, queueWithWeight);

                CycleTime += orderGreenConfig[order];
                totalVehicles += vehicleWithWeight;
            }

            List<int> optimizedGreenConfig = new List<int>();

            for (int i = 0; i < orders.Length; i++)
            {
                int newGreen;
                if (i == orders.Length - 1)
                {
                    newGreen = CycleTime;
                }
                else
                {
                    newGreen = Convert.ToInt16((orderAvgVehicles[i] / totalVehicles) * CycleTime);
                    int diff = newGreen - orderGreenConfig[i];
                    if (diff > constrain)
                    {
                        newGreen -= (diff - constrain);
                    }
                    else if (diff < (constrain * -1))
                    {
                        newGreen += ((diff * -1) - constrain);
                    }
                }
                CycleTime -= newGreen;
                optimizedGreenConfig.Add(newGreen);

                
            }

        }*/

        
    }
}
