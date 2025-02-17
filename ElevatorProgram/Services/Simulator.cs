using ElevatorProgram.Constants;
using ElevatorProgram.Interfaces;
using ElevatorProgram.Models;

namespace ElevatorProgram.Services
{
    public class Simulator(IElevatorMovement elevatorService, IOptions optionsService, IInputValidators inputValidatorService) : ISimulator
    {

        private IElevatorMovement _elevatorService = elevatorService;
        private IOptions _optionsService = optionsService;
        private IInputValidators _inputValidatorService = inputValidatorService;

        private List<ElevatorModel> elevators { get; } = new List<ElevatorModel>();
        private List<int> occupidFloors { get; } = new List<int>();

        private InputResultModel res = new InputResultModel("", 0, false, false);
        private InputResultModel Res { get { return this.res; } set { this.res = value; } }

        private string prompt = "";
        public string Prompt { get { return this.prompt; } set { this.prompt = value; } }

        private int buildingFloorNumber = 5;
        public int BuildingFloorNumber { get { return this.buildingFloorNumber; } set { this.buildingFloorNumber = value; } }


        private void SetBuilding()
        {
            prompt = _optionsService.BuildingFloorNumberCommand();
            res = _inputValidatorService.PromptReslut(prompt, 50, InputType.building);
            buildingFloorNumber = res.value;
            for (int i = 0; i < res.value; i++)
                occupidFloors.Add(0);
        }

        private void SetElevator()
        {
            prompt = _optionsService.ElevatorNumberCommand();
            res = _inputValidatorService.PromptReslut(prompt, 10, InputType.elevator);

            for (int i = 0; i < res.value; i++)
            {
                elevators.Add(new ElevatorModel(i, 0));

            }
            occupidFloors[0] = res.value;
        }

        private void ElevatorRun()
        {
            do
            {
                prompt = _optionsService.ElevatorOptions();
                res = _inputValidatorService.PromptReslut(prompt, 1, InputType.elevatorPrompt);

                if (!res.exit)
                {


                    prompt = _optionsService.CurrentFloorPrompt();
                    res = _inputValidatorService.PromptReslut(prompt, buildingFloorNumber, InputType.currentFloor);


                    if (!res.exit)
                    {
                        int currentFloor = res.value;


                        var arr = occupidFloors.ToArray();

                        int upper = _elevatorService.GetUpperFlow(arr.Skip(currentFloor).ToArray());
                        if (upper != -1)
                        {
                            upper += currentFloor;
                        }
                        int lower = _elevatorService.GetLowerFlow(arr.Take(currentFloor).ToArray());

                        int closest = _elevatorService.ClosestFloor(currentFloor, lower, upper);

                        int elevatorIndex;


                        bool isOccupid = _elevatorService.IsCurrentFloorOccupied(currentFloor, arr);

                        if (isOccupid)
                        {

                            elevatorIndex = elevators.FindIndex(s => s.currentFloor == currentFloor);
                            Console.WriteLine($"\tElevator {elevators[elevatorIndex].id}  doors opend...");


                        }
                        else
                        {
                            elevatorIndex = elevators.FindIndex(s => s.currentFloor == closest);
                            Console.WriteLine($"\tElevator {elevators[elevatorIndex].id} from floor number {elevators[elevatorIndex].currentFloor} to Floor {currentFloor} ");
                            Console.WriteLine($"\tElevator {elevators[elevatorIndex].id}  doors opend...");
                        }




                        prompt = _optionsService.PassangerNumberPrompt();
                        res = _inputValidatorService.PromptReslut(prompt, 10, InputType.passangers);


                        if (res.valid)
                        {
                            int passangers = res.value;

                            Console.WriteLine($"\tElevator {elevators[elevatorIndex].id}  {passangers} pasangers bording...\n\tDoors closed");


                            prompt = _optionsService.DestinationFloorPrompt();
                            res = _inputValidatorService.PromptReslut(prompt, buildingFloorNumber, InputType.destination);


                            if (res.valid)
                            {

                                int destination = res.value;

                                Console.WriteLine($"\tElevator {elevators[elevatorIndex].id} moving from floor number {elevators[elevatorIndex].currentFloor} to Floor {destination} ");
                                Console.WriteLine($"\tElevator {elevators[elevatorIndex].id}  doors opend...");
                                Console.WriteLine($"\tElevator {elevators[elevatorIndex].id}  {passangers} pasangers disembarking...\n\tDoors closed");

                                arr = occupidFloors.ToArray();

                                elevators[elevatorIndex].currentFloor = destination;
                                occupidFloors[destination] = occupidFloors[destination] + 1;
                                occupidFloors[currentFloor] = occupidFloors[currentFloor] - 1;

                                Console.WriteLine("\tElevators Status ");
                                Console.WriteLine("\n{0,20} {1,20} {2,20}","Elevator ID","Current Floor", "Direction");
                                foreach (var elevator in elevators)
                                {
                                    Console.WriteLine("{0,20} {1,20} {2,20}", elevator.id,  elevator.currentFloor, elevator.direction);
                                    Console.WriteLine(new string('-',80));
                                }
                            }
                        }
                    }
                }

                if (res.exit)
                {
                    break;
                }
            } while (true);
        }

        public void StartSimulation()
        {

            do
            {
                prompt = _optionsService.SimulationsStartOptions();
                res = _inputValidatorService.PromptReslut(prompt, 1, InputType.simulationOptions);
                if (res.valid && !res.exit)
                {
                    if (res.value == 1)
                    {
                        SetBuilding();
                        if (!res.exit)
                        {
                            SetElevator();
                        }
                        if (!res.exit)
                        {
                            ElevatorRun();
                        }
                    }


                }
                if (res.exit)
                {
                    break;
                }
            } while (true);

        }
    }
}
