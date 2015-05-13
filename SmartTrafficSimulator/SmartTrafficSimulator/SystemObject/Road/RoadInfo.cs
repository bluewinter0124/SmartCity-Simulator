using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RoadInfo
{
    public int roadID;
    public int phaseNo;
    public int currentGreen;
    public int currentRed;
    public double avgArrivalVehicles_min;
    public double avgQueue;
    public double avgWaitingRate;

    public int reservationTime;


    public RoadInfo(int roadID, int phaseNo, int currentGreen, int currentRed, double avgArrivalVehicles_min, double avgQueue, double avgWaitingRate)
    {
        this.roadID = roadID;
        this.phaseNo = phaseNo;
        this.currentGreen = currentGreen;
        this.currentRed = currentRed;
        this.avgArrivalVehicles_min = avgArrivalVehicles_min;
        this.avgQueue = avgQueue;
        this.avgWaitingRate = avgWaitingRate / 100;

        reservationTime = 0;
    }

    public double GetEstimatedWaitingRate(int green,int red)
    {
        double greenVehicle = green * (avgArrivalVehicles_min / 60);
        double redVehicle = red * (avgArrivalVehicles_min / 60);

        double allVehicle = greenVehicle + redVehicle;

        int rst = System.Convert.ToInt16(Math.Round(redVehicle * 3 + 1, 0, MidpointRounding.AwayFromZero));

        double noPassedVehicle = rst * (avgArrivalVehicles_min / 60);

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
}

