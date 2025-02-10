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

        public InputResultModel InputValidation(string? line, int value, bool islower)
        {
            int number;
            if (int.TryParse(line, out number))
            {
                if (number < 0 )
                {
                    return new InputResultModel("Input Value can't be Nagativ", 0, false, false);
                }
                if (islower && number > value)
                {
                    return new InputResultModel(InputValidatorMessages.invalidMaxValue + value.ToString(), 0, false, false);
                }
                else if (!islower && number < value)
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

        public InputResultModel PromptReslut(string prompt, int value, bool islower)
        {
            InputResultModel res;
            do
            {
                Console.WriteLine(prompt);
                res = InputValidation(Console.ReadLine(), value, islower);
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
