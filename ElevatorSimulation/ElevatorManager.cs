namespace ElevatorSimulation;
using System;
public class ElevatorManager
{
    public void PromptElevator( )
    {

        do
        {
            Console.WriteLine("Enter current floor number");

            string input = Console.ReadLine();

            if (input == "1")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input, try again!");

            }

        } while (true);
    }

}
