using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Core
{
    public class Robot
    {
        bool isPlaced = false;

        int xPosition = -1;
        int yPosition = -1;
        string direction = string.Empty;

        public string command(string input)
        {
            string command = input.ToUpper();
            string result = string.Empty;

            if (command.Contains("PLACE"))
            {
                char[] delimiterChars = { ',', ' ' };
                string[] wordsInCommand = command.Split(delimiterChars);

                xPosition = Int32.Parse(wordsInCommand[1]);
                yPosition = Int32.Parse(wordsInCommand[2]);
                direction = wordsInCommand[3];

                isPlaced = true;
            }
            else
            {
                if (!isPlaced)
                    result = "<Command ignored - robot not placed yet>";
                else if (command.Equals("REPORT"))
                {
                    result = xPosition + "," + yPosition + "," + direction;
                }
            }

            return result;
        }
    }
}
