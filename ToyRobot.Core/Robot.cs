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

        int xLowerBoundary = 0;
        int yLowerBoundary = 0;
        int xUpperBoundary = -1;
        int yUpperBoundary = -1;

        int xPosition = -1;
        int yPosition = -1;
        string direction = string.Empty;

        // Default table size 5,5 if not supplied
        public Robot()
        {
            xUpperBoundary = 5;
            yUpperBoundary = 5;
        }

        // Custom table size if required
        public Robot(int tableSizeX, int tableSizeY)
        {
            xUpperBoundary = tableSizeX;
            yUpperBoundary = tableSizeY;
        }

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

                if ((xPosition < xLowerBoundary) || (yPosition < yLowerBoundary))
                    result = "<Command ignored - out of bounds>";
                else if ((xPosition > xUpperBoundary) || (yPosition > yUpperBoundary))
                    result = "<Command ignored - out of bounds>";
                else
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
                else if (command.Equals("MOVE"))
                {
                    if (direction.Equals("N"))
                        yPosition++;
                    else if (direction.Equals("E"))
                        xPosition++;
                    else if (direction.Equals("W"))
                        xPosition--;
                    else if (direction.Equals("S"))
                        yPosition--;
                }
                else if (command.Equals("LEFT"))
                {
                    if (direction.Equals("N"))
                        direction = "W";
                    else if (direction.Equals("W"))
                        direction = "S";
                    else if (direction.Equals("S"))
                        direction = "E";
                    else if (direction.Equals("E"))
                        direction = "N";
                }
                else if (command.Equals("RIGHT"))
                {
                    if (direction.Equals("N"))
                        direction = "E";
                    else if (direction.Equals("E"))
                        direction = "S";
                    else if (direction.Equals("S"))
                        direction = "W";
                    else if (direction.Equals("W"))
                        direction = "N";
                }
            }

            return result;
        }
    }
}
