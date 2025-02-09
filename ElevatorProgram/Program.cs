using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using ElevatorProgram.Constants;
using ElevatorProgram.Interfaces;
using ElevatorProgram.Models;
using ElevatorProgram.Services;
using Microsoft.Extensions.DependencyInjection;








public class Elevator
{
   

    static InputResultModel InputValidation(string? line)
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

    


    static InputResultModel PromptReslut(string prompt)
    {
        InputResultModel res;
        do
        {
            Console.WriteLine(prompt);
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

    public static void Main(String[] args)
    {

        var serviceProvider = new ServiceCollection()
               .AddSingleton<IElevatorMovement, ElevatorMovement>()
               .AddSingleton<IOptions, Options>()
               .BuildServiceProvider();

        var elevatorService = serviceProvider.GetService<IElevatorMovement>();
        var optionsService = serviceProvider.GetService<IOptions>();
        List<ElevatorModel> elevators = new List<ElevatorModel>();
        List<int> occupidFloors = new List<int>();
        int buildingFloorNumber;
        InputResultModel res;
        string prompt;
        do
        {
            prompt = optionsService.BuildingOptions();
            res = PromptReslut(prompt);
            if (res.valid && !res.exit)
            {
                if (res.value == 1)
                {
                    prompt = optionsService.BuildingFloorNumberCommand();
                    res = PromptReslut(prompt);
                    buildingFloorNumber = res.value;
                    for (int i = 0; i < res.value; i++)
                    {
                        occupidFloors.Add(0);
                    }

                }
                if (!res.exit)
                {
                    prompt = optionsService.ElevatorNumberCommand();
                    res = PromptReslut(prompt);
                  
                    for (int i = 0; i < res.value; i++)
                    {
                        elevators.Add(new ElevatorModel(i, 0));
                       
                    }
                    occupidFloors[0] = res.value;
                }
                if (!res.exit)
                {
                    do
                    {
                        prompt = optionsService.ElevatorOptions();
                        res = PromptReslut(prompt);

                        if (!res.exit)
                        {
                            prompt = optionsService.CurrentFloorPrompt();
                            res = PromptReslut(prompt);
                            

                            if (!res.exit)
                            {
                                int currentFloor = res.value;

                                prompt = optionsService.DestinationFloorPrompt();
                                res = PromptReslut(prompt);
                                

                                if (res.valid)
                                {

                                    int destination = res.value;

                                    prompt = optionsService.PassangerNumberPrompt();
                                    res = PromptReslut(prompt);
                                    

                                    if (res.valid)
                                    {
                                        int passangers = res.value;
                                        var arr = occupidFloors.ToArray();
                                        bool isOccupid = elevatorService.isCurrentFloorOccupied(currentFloor, arr);

                                        if (isOccupid)
                                        {
                                            Console.WriteLine("the current floor is occupide " + currentFloor.ToString());
                                            int elevatorIndex = elevators.FindIndex(s => s.currentFloor == currentFloor);
                                            occupidFloors[destination] = occupidFloors[destination] + 1;
                                            occupidFloors[currentFloor] = occupidFloors[currentFloor] - 1;

                                        }
                                        else
                                        {

                                            int upper = elevatorService.getUpperFlow(arr.Skip(currentFloor).ToArray());
                                            if (upper != -1)
                                            {
                                                upper += currentFloor;
                                            }
                                            int lower = elevatorService.getLowerFlow(arr.Take(currentFloor).ToArray());

                                            int closest = elevatorService.closestFloor(currentFloor, lower, upper);

                                            int elevatorIndex = elevators.FindIndex(s => s.currentFloor == closest);
                                            //.Where(s => s.currentFloor == closest).FirstOrDefault();
                                            //Find(a => a.currentFloor == closestFloor).fist;  

                                            elevators[elevatorIndex].currentFloor = destination;
                                            occupidFloors[destination] = occupidFloors[destination] + 1;
                                            occupidFloors[closest] = occupidFloors[closest] - 1;
                                            Console.WriteLine("closest elvator " + closest.ToString());

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
            }
            if (res.exit)
            {
                break;
            }
        } while (true);



    }
}