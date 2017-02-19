using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Core;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCommand = String.Empty;
            string commandResult = String.Empty;
            Robot robot = new Robot();

            Console.WriteLine("Robot created. Enter commands to send to Robot. (X at any time to quit)");

            while (true)
            {
                Console.WriteLine("Enter command for Robot:");
                inputCommand = Console.ReadLine();

                if (inputCommand.ToUpper().Equals("X"))
                    break;

                commandResult = robot.command(inputCommand);
                Console.WriteLine(commandResult);
            }
            Console.WriteLine("Exited - press any key to close");
            Console.ReadLine();
        }
    }
}
