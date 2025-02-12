using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProgram.Constants
{
    public class CommandConstants
    {
        public const string headerCommand = "**************************************\n   Welcome to DVT Elevator Challenge \n**************************************";
        public const string startCommand = " Input ( 1 ) To START simulation";
        public const string exitCommand = " Input (Q) to Exit ";
        public const string buldingNumberPrompt = "\n----------------- SetUp Building info -----------------\n Input number to represent Building floors (2 - 50)";
        public const string elevatorNumberPrompt = "\n----------------- SetUp Elevators info -----------------\n Input number to represent Elevators  (2 - 10)";
        public const string toRequestElevatorCommand = "\n>>>>>>>>>>>>>>>>>  Elevator Oparation  <<<<<<<<<<<<<<<<\n Input ( 1 ) To request Elevator";
        public const string currentFloorPrompt = " Input number to represent Current floor";
        public const string destinationFloorPrompt = " Input number to represent destinatin floor";
        public const string passangerNumberPrompt = " Input number to represent passangers (1 - 10)";
    }
}
