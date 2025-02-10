using ElevatorProgram.Models;

namespace ElevatorProgram.Interfaces
{
    public interface IElevatorMovement
    {
        int ClosestFloor(int currentFloor, int lowFloor, int upperFloor);
        int GetLowerFlow(int[] occupiedFloors);
        int GetUpperFlow(int[] occupiedFloors);
        bool InputFloorValidation(int currentFloorNumber, int buildingFloorNumber);
        bool IsCurrentFloorOccupied(int currentFloor, int[] floors);
    }
}