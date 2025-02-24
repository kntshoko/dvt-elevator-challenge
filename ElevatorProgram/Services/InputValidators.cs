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
    public class InputValidators : IInputValidators
    {

        public InputResultModel InputValidation(string? line, int value, InputType inputType)
        {
            int number;
            if (int.TryParse(line, out number))
            {
                if (number < 0 )
                {
                    return new InputResultModel("Input Value can't be Nagative", 0, false, false);
                }else
                if (InputType.building == inputType &&( number > value || number < 2))
                {
                    return new InputResultModel(InputValidatorMessages.invalidBuildingMessage + value.ToString(), 0, false, false);
                }
                else if (InputType.currentFloor == inputType &&( number > value || number < 0))
                {
                    return new InputResultModel(InputValidatorMessages.invalidFloorMessage + value.ToString(), 0, false, false);
                }
                else if (InputType.destination == inputType && (number > value || number < 0))
                {
                    return new InputResultModel(InputValidatorMessages.invalidDestinationMessage + value.ToString(), 0, false, false);
                }
                else
                if (InputType.passangers == inputType && (number > 11 || number < 1))
                {
                    return new InputResultModel(InputValidatorMessages.invalidPassangerMessage, 0, false, false);
                }
                else if (InputType.elevator == inputType && (number > value || value < 2))
                {
                    return new InputResultModel(InputValidatorMessages.invalidElevatorsMessage, 0, false, false);
                }
                else if (InputType.elevatorPrompt == inputType && number != value)
                {
                    return new InputResultModel(InputValidatorMessages.invalidPromptMessage + value.ToString(), 0, false, false);
                }
                else if (InputType.simulationOptions == inputType && number != 1)
                {
                    return new InputResultModel(InputValidatorMessages.invalidSimulationOptions, 0, false, false);
                }
                return new InputResultModel("", number, true, false);
            }
            else if (line != null && line.Equals("Q", StringComparison.CurrentCultureIgnoreCase))
            {
                return new InputResultModel("Exit", 0, false, true);
            }
            else 
            
                return new InputResultModel(InputValidatorMessages.invalidIntMessage, 0, true, false);
        }

        public InputResultModel PromptReslut(string prompt, int value, InputType inputType)
        {
            InputResultModel res;
            do
            {
                Console.WriteLine(prompt);
                res = InputValidation(Console.ReadLine(), value, inputType);
                if (res.valid)
                {
                    break;
                }else
                if (res.exit)
                {
                    break;
                }
                else if(res.valid == false)
                {
                    Console.WriteLine("\t" + new string('\'',60));
                    Console.WriteLine("{0,20}", res.message);
                    Console.WriteLine("\t" + new string('\'', 60));
                }
            } while (true);
            return res;
        }
    }
}
