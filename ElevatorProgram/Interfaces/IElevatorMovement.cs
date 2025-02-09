namespace ElevatorProgram.Interfaces
{
    public interface IElevatorMovement
    {
        int closestFloor(int currentFloor, int lowFloor, int upperFloor);
        int getLowerFlow(int[] occupiedFloors);
        int getUpperFlow(int[] occupiedFloors);
        bool inputFloorValidation(int currentFloorNumber, int buildingFloorNumber);
        bool isCurrentFloorOccupied(int currentFloor, int[] floors);
    }
}