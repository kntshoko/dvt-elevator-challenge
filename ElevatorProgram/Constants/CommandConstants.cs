using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProgram.Constants
{
    public class CommandConstants
    {
        public const string headerCommand = "\t************************************** \n\tWelcome to DVT Elevator Challenge \n\t**************************************";
        public const string startCommand = "\tInput ( 1 ) To START simulation";
        public const string exitCommand = "\tInput (Q) to Exit ";
        public const string buldingNumberPrompt = "\n\t----------------- SetUp Building info -----------------\n\tInput number to represent Building floors (2 - 50)";
        public const string elevatorNumberPrompt = "\n\t----------------- SetUp Elevators info -----------------\n\tInput number to represent Elevators  (2 - 10)";
        public const string toRequestElevatorCommand = "\n\t>>>>>>>>>>>>>>>>>  Elevator Oparation  <<<<<<<<<<<<<<<<\n\tInput ( 1 ) To request Elevator";
        public const string currentFloorPrompt = "\tInput number to represent Current floor";
        public const string destinationFloorPrompt = "\tInput number to represent destinatin floor";
        public const string passangerNumberPrompt = "\tInput number to represent passangers (1 - 10)";
    }
}
