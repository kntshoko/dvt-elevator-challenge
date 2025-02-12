using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                        prompt = _optionsService.DestinationFloorPrompt();
                        res = _inputValidatorService.PromptReslut(prompt, buildingFloorNumber, InputType.destination);


                        if (res.valid)
                        {

                            int destination = res.value;

                            prompt = _optionsService.PassangerNumberPrompt();
                            res = _inputValidatorService.PromptReslut(prompt, 10, InputType.passangers);


                            if (res.valid)
                            {
                                int passangers = res.value;
                                var arr = occupidFloors.ToArray();
                                bool isOccupid = _elevatorService.IsCurrentFloorOccupied(currentFloor, arr);

                                if (isOccupid)
                                {

                                    int elevatorIndex = elevators.FindIndex(s => s.currentFloor == currentFloor);

                                    elevators[elevatorIndex].currentFloor = destination;
                                    occupidFloors[destination] = occupidFloors[destination] + 1;
                                    occupidFloors[currentFloor] = occupidFloors[currentFloor] - 1;

                                }
                                else
                                {

                                    int upper = _elevatorService.GetUpperFlow(arr.Skip(currentFloor).ToArray());
                                    if (upper != -1)
                                    {
                                        upper += currentFloor;
                                    }
                                    int lower = _elevatorService.GetLowerFlow(arr.Take(currentFloor).ToArray());

                                    int closest = _elevatorService.ClosestFloor(currentFloor, lower, upper);

                                    int elevatorIndex = elevators.FindIndex(s => s.currentFloor == closest);

                                    elevators[elevatorIndex].currentFloor = destination;
                                    occupidFloors[destination] = occupidFloors[destination] + 1;
                                    occupidFloors[closest] = occupidFloors[closest] - 1;




                                }

                                Console.WriteLine("Elevators Status ");

                                foreach (var elevator in elevators)
                                {
                                    Console.WriteLine($"ID :  {elevator.id,10}  Current Floor : {elevator.currentFloor,10}");
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
                res = _inputValidatorService.PromptReslut(prompt, 10, InputType.simulationOptions);
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
