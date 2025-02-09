using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorProgram.Constants;
using ElevatorProgram.Interfaces;

namespace ElevatorProgram.Services
{
    public class Options : IOptions
    {
        public string BuildingOptions()
        {

            string prompt = CommandConstants.headerCommand + "\n"
                + CommandConstants.toBuldingNumberCommand +
                " \n" + CommandConstants.exitCommand;

            return prompt;
        }
        public string ElevatorOptions()
        {
            string prompt = CommandConstants.headerCommand + " \n"
                + CommandConstants.toRequestElevatorCommand +
                " \n" + CommandConstants.exitCommand;

            return prompt;
        }
        public string BuildingFloorNumberCommand()
        {

            string prompt = CommandConstants.buldingNumberPrompt +
                " \n" + CommandConstants.exitCommand;

            return prompt;
        }

        public string ElevatorNumberCommand()
        {


            string prompt = CommandConstants.elevatorNumberPrompt +
                " \n" + CommandConstants.exitCommand;

            return prompt;
        }

        public string CurrentFloorPrompt()
        {
            string prompt = CommandConstants.currentFloorPrompt +
                " \n" + CommandConstants.exitCommand;

            return prompt;
        }

        public string DestinationFloorPrompt()
        {

            string prompt = CommandConstants.destinationFloorPrompt +
                " \n" + CommandConstants.exitCommand;

            return prompt;
        }

        public string PassangerNumberPrompt()
        {

            string prompt = CommandConstants.passangerNumberPrompt + " \n"
                 + CommandConstants.exitCommand;

            return prompt;
        }
    }
}
