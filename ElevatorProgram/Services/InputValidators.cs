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
                if (InputType.building == inputType && number > value)
                {
                    return new InputResultModel(InputValidatorMessages.invalidMaxValue + value.ToString(), 0, false, false);
                }
                else if (InputType.currentFloor == inputType && (number < value || number < 0))
                {
                    return new InputResultModel(InputValidatorMessages.invalidMinValue + value.ToString(), 0, false, false);
                }
                else
                if (InputType.passangers == inputType && number > value)
                {
                    return new InputResultModel(InputValidatorMessages.invalidMaxValue + value.ToString(), 0, false, false);
                }
                else if (InputType.elevator == inputType && number > value)
                {
                    return new InputResultModel(InputValidatorMessages.invalidMinValue + value.ToString(), 0, false, false);
                }
                else if (InputType.elevatorPrompt == inputType && number != value)
                {
                    return new InputResultModel(InputValidatorMessages.invalidMinValue + value.ToString(), 0, false, false);
                }
                return new InputResultModel("", number, true, false);
            }
            else if (line != null && line.Equals("Q", StringComparison.CurrentCultureIgnoreCase))
            {
                return new InputResultModel("", 0, false, true);
            }
            else 
            
                return new InputResultModel(InputValidatorMessages.invalidIntMessage, 0, false, false);
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
                }
                if (res.exit)
                {
                    break;
                }
            } while (true);
            return res;
        }
    }
}
