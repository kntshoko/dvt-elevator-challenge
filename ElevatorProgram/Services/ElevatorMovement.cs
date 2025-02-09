using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorProgram.Interfaces;

namespace ElevatorProgram.Services
{
    public class ElevatorMovement : IElevatorMovement
    {
        public bool isCurrentFloorOccupied(int currentFloor, int[] floors)
        {
            if (floors[currentFloor] > 0)
            {
                return true;
            }
            return false;
        }
        public bool inputFloorValidation(int currentFloorNumber, int buildingFloorNumber)
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
        public int getUpperFlow(int[] occupiedFloors)
        {
            int upperFlow = Array.FindLastIndex(occupiedFloors, x => x > 0);
            return upperFlow;
        }
        public int getLowerFlow(int[] occupiedFloors)
        {
            int upperFlow = Array.FindIndex(occupiedFloors, x => x > 0);
            return upperFlow;
        }

        public int closestFloor(int currentFloor, int lowFloor, int upperFloor)
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
