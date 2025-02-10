using ElevatorProgram.Models;

namespace ElevatorProgram.Interfaces
{
    public interface IInputValidators
    {
        InputResultModel InputValidation(string? line ,int value, bool islower);
        InputResultModel PromptReslut(string prompt, int value, bool islower);
    }
}