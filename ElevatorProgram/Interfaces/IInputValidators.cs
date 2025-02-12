using ElevatorProgram.Constants;
using ElevatorProgram.Models;

namespace ElevatorProgram.Interfaces
{
    public interface IInputValidators
    {
        InputResultModel InputValidation(string? line ,int value, InputType inputType);
        InputResultModel PromptReslut(string prompt, int value, InputType inputType);
    }
}