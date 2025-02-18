using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProgram.Constants
{
    public class InputValidatorMessages
    {
        public const string invalidIntMessage = "Input is not valid, Please enter a number ex {1,2,3...}";
        public const string invalidFloorMessage = "Floor number invalid, Floor not avilable 0 and ";
        public const string invalidDestinationMessage = "Destination Floor number invalid, Floor not avilable 0 and ";
        public const string invalidBuildingMessage = "Number of Floors invalid, Input must be Between 2 and 50";
        public const string invalidElevatorsMessage = "Number of Elevators is invalid, Input must be Between 2 and 10";
        public const string invalidPassangerMessage = "Number of Passangers must be between 1 and 10";
        public const string invalidPromptMessage = "Input is not valid, ";
    }

}
