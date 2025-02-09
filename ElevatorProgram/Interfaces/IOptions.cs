namespace ElevatorProgram.Interfaces
{
    public interface IOptions
    {
        string BuildingFloorNumberCommand();
        string BuildingOptions();
        string CurrentFloorPrompt();
        string DestinationFloorPrompt();
        string ElevatorNumberCommand();
        string ElevatorOptions();
        string PassangerNumberPrompt();
    }
}