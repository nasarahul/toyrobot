using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Core;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCommand = String.Empty;
            string robotOutput = String.Empty;
            Robot robot = new Robot();

            Console.WriteLine("Robot created. Enter commands to send to Robot. (X at any time to quit)");

            while (true)
            {
                Console.WriteLine("Enter command for Robot:");
                inputCommand = Console.ReadLine();

                if (inputCommand.ToUpper().Equals("X"))
                    break;

                robotOutput = robot.command(inputCommand);
                Console.WriteLine(robotOutput);
            }
            Console.WriteLine("Exited - press any key to close");
            Console.ReadLine();
        }
    }
}
