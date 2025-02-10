using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorProgram.Interfaces;
using ElevatorProgram.Models;

namespace ElevatorProgram.Services
{
    public class ElevatorMovement : IElevatorMovement
    {

        public string MoveToCurrentFloor (){


            return "";
        }


        
        public bool IsCurrentFloorOccupied(int currentFloor, int[] floors)
        {
            if (floors[currentFloor] > 0)
            {
                return true;
            }
            return false;
        }
        public bool InputFloorValidation(int currentFloorNumber, int buildingFloorNumber)
        {
            if (currentFloorNumber > buildingFloorNumber)
            {
                return false;
            }
            else if (currentFloorNumber < 0)
            {
                return false;
            }
            return true;
        }
        public int GetUpperFlow(int[] occupiedFloors)
        {
            int upperFlow = Array.FindLastIndex(occupiedFloors, x => x > 0);
            return upperFlow;
        }
        public int GetLowerFlow(int[] occupiedFloors)
        {
            int upperFlow = Array.FindIndex(occupiedFloors, x => x > 0);
            return upperFlow;
        }

        public int ClosestFloor(int currentFloor, int lowFloor, int upperFloor)
        {
            if (lowFloor == -1)
            {
                return upperFloor;
            }
            if (upperFloor == -1)
            {
                return lowFloor;
            }
            int favorLowFloor = currentFloor - lowFloor;
            int favorUpperFloor = upperFloor - currentFloor;
            if (favorLowFloor < favorUpperFloor)
            {
                return lowFloor;
            }
            else if (favorLowFloor > favorUpperFloor)
            {
                return upperFloor;
            }
            return lowFloor;
        }
    }
}
