using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartTrafficSimulator.SystemManagers;
using Models;

class RoadInfo
{
    public int roadID;
    public int phaseNo;
    public int currentGreen;
    public int currentRed;
    public double avgArrivalRate_min;
    public double avgDepartureRate_min;
    public double avgQueue;
    public double avgWaitingRate;

    public int reservationTime;


    public RoadInfo(int roadID, int phaseNo, int currentGreen, int currentRed, double avgArrivalRate_min, double avgDepartureRate_min,double avgQueue, double avgWaitingRate)
    {
        this.roadID = roadID;
        this.phaseNo = phaseNo;
        this.currentGreen = currentGreen;
        this.currentRed = currentRed;
        this.avgArrivalRate_min = avgArrivalRate_min;
        this.avgDepartureRate_min = avgDepartureRate_min;
        this.avgQueue = avgQueue;
        this.avgWaitingRate = avgWaitingRate / 100;

        reservationTime = 0;
    }

    public double GetEstimatedWaitingRate(int green,int red)
    {
        double greenVehicle = green * (avgArrivalRate_min / 60);
        double redVehicle = red * (avgArrivalRate_min / 60);

        double allVehicle = greenVehicle + redVehicle;

        int rst = System.Convert.ToInt16(Math.Round(redVehicle * 3 + 1, 0, MidpointRounding.AwayFromZero));

        double noPassedVehicle = rst * (avgArrivalRate_min / 60);

        double estimatedWaitingRate = (redVehicle + noPassedVehicle) / allVehicle;
        
        if (estimatedWaitingRate > 1)
        { 
            estimatedWaitingRate = 100;
        }

        return estimatedWaitingRate;
    }

    public int GetReservationTime()
    {
        return System.Convert.ToInt16(Math.Round((avgQueue * 3) + 1, 2, MidpointRounding.AwayFromZero));
    }

    public void UsePredictionArrivalRate(int interval_sec, int number)
    {

        int intersectionID = Simulator.RoadManager.GetRoadByID(roadID).belongsIntersection.intersectionID;
        Dictionary<int, Dictionary<int, double>> data = Simulator.DataManager.GetArrivalRateData_Interval(intersectionID, interval_sec);
        int currentZone = Simulator.getCurrentTime() / interval_sec;

        List<int> pastAvgArrivalRate_intervalSec = new List<int>();

        int lastData = 0;

        for (int i = 0; i < number; i++)
        {
            int wantZone = currentZone - i - 1;
            if (data.ContainsKey(wantZone))
            {
                lastData = (int)data[wantZone][roadID];
            }
            pastAvgArrivalRate_intervalSec.Add(lastData);
        }

        //Simulator.UI.AddMessage("AI","Road" + roadID + " use data : " + pastAvgArrivalRate_intervalSec[0] + " " + pastAvgArrivalRate_intervalSec[1] + " " + pastAvgArrivalRate_intervalSec[2] + " " + pastAvgArrivalRate_intervalSec[3] + " ");

        TrafficVolumePrediction pred = new TrafficVolumePrediction();

        double predAvgArrivalRate_intervalSec = 0;
        int totalWeight = 0;

        for (int i = 0; i < number; i++)
        {
            int predArrival = pred.PRmain(pastAvgArrivalRate_intervalSec);
            predAvgArrivalRate_intervalSec += predArrival * (number - i);
            totalWeight += (i + 1);

            pastAvgArrivalRate_intervalSec[0] = pastAvgArrivalRate_intervalSec[1];
            pastAvgArrivalRate_intervalSec[1] = pastAvgArrivalRate_intervalSec[2];
            pastAvgArrivalRate_intervalSec[2] = pastAvgArrivalRate_intervalSec[3];
            pastAvgArrivalRate_intervalSec[3] = predArrival;
        }

        predAvgArrivalRate_intervalSec /= totalWeight;
        predAvgArrivalRate_intervalSec /= interval_sec;

        avgArrivalRate_min = (predAvgArrivalRate_intervalSec * 60);

        //Simulator.UI.AddMessage("AI", "Prediction result : " + avgArrivalRate_min);
    }
}

