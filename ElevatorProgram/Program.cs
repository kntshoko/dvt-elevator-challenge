using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

class CommandConstants
{
    public const string headerCommand = "Please choose from one of the following options...";
    public const string toBuldingNumberCommand = "1.To START simulation";
    public const string exitCommand = " (Q) to Exit";
    public const string buldingNumberPrompt = "Enter Building number of floors";
    public const string elevatorNumberPrompt = "Enter number of Elevators";
    public const string toRequestElevatorCommand = "1. request Elevator";
    public const string currentFloorPrompt = "Enter current floor number";
    public const string destinationFloorPrompt = "Enter destinatin floor number";
    public const string passangerNumberPrompt = "Enter Building number of passangers";
}
class InputValidatorMessages
{
    public const string invalidIntMessage = "Input is not valid, Please enter a number ex{1,2,3...}";
    public const string invalidFloorMessage = "Input is not valid, Floor not avilable";
}

class InputResultModel
{
    public string message ;
    public int value ;
    public bool valid ;
    public bool exit;

    public InputResultModel( string message, int value, bool valid, bool exit )
    {
        this.message = message;
        this.value = value;
        this.valid = valid;
        this.exit = exit;
    }
}
class ElevatorMovement
{
    string? direction;
    int currentFloor;
    int destinationFloor;
    int passanger;
}

class ElevatorModel
{
    public int id;
    public int currentFloor;
    public ElevatorModel( int id, int currentFloor )
    {
        this.id = id;
        this.currentFloor = currentFloor;
    }
}
public static class Elevator
{
    static void buildingOptions( )
    {
        Console.WriteLine(CommandConstants.headerCommand);
        Console.WriteLine(CommandConstants.toBuldingNumberCommand);
        Console.WriteLine(CommandConstants.exitCommand);
    }
    static void ElevatorOptions( )
    {
        Console.WriteLine(CommandConstants.headerCommand);
        Console.WriteLine(CommandConstants.toRequestElevatorCommand);
        Console.WriteLine(CommandConstants.exitCommand);
    }
    static void BuildingFloorNumberCommand( )
    {
        Console.WriteLine(CommandConstants.buldingNumberPrompt);
        Console.WriteLine(CommandConstants.exitCommand);
    }

    static void ElevatorNumberCommand( )
    {
        Console.WriteLine(CommandConstants.elevatorNumberPrompt);
        Console.WriteLine(CommandConstants.exitCommand);
    }

    static void CurrentFloorPrompt( )
    {
        Console.WriteLine(CommandConstants.elevatorNumberPrompt);
        Console.WriteLine(CommandConstants.exitCommand);
    }

    static void PassangerNumberPrompt( )
    {
        Console.WriteLine(CommandConstants.elevatorNumberPrompt);
        Console.WriteLine(CommandConstants.exitCommand);
    }

    static InputResultModel InputValidation( string? line )
    {
        int number;
        if (int.TryParse(line, out number))
        {
            return new InputResultModel("", number, true, false);
        }
        else if (line != null && line.Equals("Q", StringComparison.CurrentCultureIgnoreCase))
        {
            return new InputResultModel("", 0, false, true);
        }
        return new InputResultModel(InputValidatorMessages.invalidIntMessage, 0, false, false);
    }
    static bool isCurrentFloorOccupied( int currentFloor, int[] occupidFloors )
    {
        if (occupidFloors[currentFloor] > 0)
        {
            return true;
        }
        return false;
    }
    static bool inputFloorValidation( int currentFloorNumber, int buildingFloorNumber )
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
    static int getUpperFlow( int[] occupiedFloors )
    {
        int upperFlow = Array.FindLastIndex(occupiedFloors, x => x > 0);
        return upperFlow;
    }
    static int getLowerFlow( int[] occupiedFloors )
    {
        int upperFlow = Array.FindIndex(occupiedFloors, x => x > 0);
        return upperFlow;
    }

    static int closestFloor( int currentFloor, int lowFloor, int upperFloor )
    {
        int favorLowFloor  = currentFloor - lowFloor ;
        int favorUpperFloor  = upperFloor - currentFloor  ;
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
    static InputResultModel getFloorsNumber( )
    {
        InputResultModel res;
        do
        {
            Elevator.BuildingFloorNumberCommand();
            res = Elevator.InputValidation(Console.ReadLine());
            if (res.valid)
            {
                break;
            }
            if (res.exit)
            {
                break;
            }
        } while (true);
        return res;
    }
    static InputResultModel getElevatorNumber( )
    {
        InputResultModel res;
        do
        {
            Elevator.ElevatorNumberCommand();
            res = Elevator.InputValidation(Console.ReadLine());
            if (res.valid)
            {
                break;
            }
            if (res.exit)
            {
                break;
            }
        } while (true);
        return res;
    }
    static InputResultModel requestElevator( )
    {
        InputResultModel res;
        do
        {
            Elevator.ElevatorOptions();
            res = Elevator.InputValidation(Console.ReadLine());
            if (res.valid && res.value ==1)
            {
                break;
            }
            if (res.exit)
            {
                break;
            }
        } while (true);
        return res;
    }

    static InputResultModel currentElevatorFloor( )
    {
        InputResultModel res;
        do
        {
            Elevator.currentElevator();
            res = Elevator.InputValidation(Console.ReadLine());
            if (res.valid && res.value == 1)
            {
                break;
            }
            if (res.exit)
            {
                break;
            }
        } while (true);
        return res;
    }

    static InputResultModel numberOfPassangers( )
    {
        InputResultModel res;
        do
        {
            Elevator.numberOfPassangers();
            res = Elevator.InputValidation(Console.ReadLine());
            if (res.valid && res.value == 1)
            {
                break;
            }
            if (res.exit)
            {
                break;
            }
        } while (true);
        return res;
    }

    static InputResultModel getCurrentFloor(string command )
    {
        InputResultModel res;
        do
        {
            Elevator.getCurrentFloor();
            res = Elevator.InputValidation(Console.ReadLine());
            if (res.valid && res.value == 1)
            {
                break;
            }
            if (res.exit)
            {
                break;
            }
        } while (true);
        return res;
    }

    public static void Main( String[] args )
    {
        List<ElevatorModel>elevators = new List<ElevatorModel>();
        int[] occupidFloors;
        int buildingFloorNumber;
        InputResultModel res;
        do
        {
            Elevator.buildingOptions();
            res = Elevator.InputValidation(Console.ReadLine());
            if (res.valid && !res.exit)
            {
                if (res.value == 1)
                {
                    res = getFloorsNumber();
                    buildingFloorNumber = res.value;
                }
                if (!res.exit)
                {
                    res = getElevatorNumber();
                    int[] arr = new int[res.value];
                    occupidFloors = arr;
                    for (int i = 0; i < res.value; i++)
                    {
                        elevators.Add(new ElevatorModel(i, 0));
                    }
                }
                if (!res.exit)
                {
                    do
                    {
                        res = requestElevator();

                        if (res.valid && !res.exit)
                        {


                        }

                        if (res.exit)
                        {
                            break;
                        }
                    } while (true);
                }
            }
            if (res.exit)
            {
                break;
            }
        } while (true);


        //int[] arr = new int[17];

        //var j = arr.Take(7).ToArray();
        //var i = arr.Skip(7).ToArray();

        //foreach (var x in j)
        //{
        //    Console.Write(" " + x + " ");
        //}
        //Console.WriteLine("\nthen");
        elevators[2].currentFloor = 5;
        foreach (var x in elevators)
        {
            Console.WriteLine(" " + x.id.ToString() + " " + x.currentFloor.ToString());
        }

        //Console.WriteLine("\n********");

        //var n = Array.FindLastIndex(j, x => x > 0);
        //var m = Array.FindIndex(i, x => x > 0);

        ////var m = i.Select(( val, index ) => new { Val = val, Index = index })
        ////       .Where(l => l.Val > 0)
        ////       .First()
        ////       .Index;
        //Console.WriteLine(n);
        //Console.WriteLine(m);


        //Console.WriteLine("then");
        //Console.WriteLine(i.ToString());
        //ElevatorManager elevatorManager = new ElevatorManager();
        //do
        //{


        //    elevatorManager.PromptElevator();
        //    Console.WriteLine("Enter (Q) to exit");

        //    if (Console.ReadLine().ToUpper() == "Q")
        //    {

        //        break;


        //    }

        //} while (true);

    }
}
public class ElevatorManager
{
    public void PromptElevator( )
    {

        do
        {
            Console.WriteLine("Enter current floor number");

            string input = Console.ReadLine();

            if (input == "1")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input, try again!");

            }

        } while (true);
    }

}