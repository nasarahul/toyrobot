using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Core
{
    public class Robot
    {
        public const string OUT_OF_BOUNDS_MESSAGE = "<Command ignored - out of bounds>";
        public const string NOT_PLACED_YET_MESSAGE = "<Command ignored - robot not placed yet>";
        private const int xLowerBoundary = 0;
        private const int yLowerBoundary = 0;

        private int xUpperBoundary = -1;
        private int yUpperBoundary = -1;
        private int xPosition = -1;
        private int yPosition = -1;
        private string direction = string.Empty;
        private bool isPlaced = false;

        // Default table size 5,5 if not supplied
        public Robot()
        {
            xUpperBoundary = 5;
            yUpperBoundary = 5;
        }

        // Custom table size if supplied
        public Robot(int tableSizeX, int tableSizeY)
        {
            xUpperBoundary = tableSizeX;
            yUpperBoundary = tableSizeY;
        }

        private bool validatePosition()
        {
            if ((xPosition < xLowerBoundary) || (yPosition < yLowerBoundary))
                return false;
            else if ((xPosition > xUpperBoundary) || (yPosition > yUpperBoundary))
                return false;
            else
                return true;
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

                if (!validatePosition())
                    result = OUT_OF_BOUNDS_MESSAGE;
                else
                    isPlaced = true;
            }
            else
            {
                if (!isPlaced)
                    result = NOT_PLACED_YET_MESSAGE;
                else if (command.Equals("REPORT"))
                {
                    result = xPosition + "," + yPosition + "," + direction;
                }
                else if (command.Equals("MOVE"))
                {
                    int originalX = this.xPosition;
                    int originalY = this.yPosition;

                    if (direction.Equals("N"))
                        yPosition++;
                    else if (direction.Equals("E"))
                        xPosition++;
                    else if (direction.Equals("W"))
                        xPosition--;
                    else if (direction.Equals("S"))
                        yPosition--;

                    if (!validatePosition())
                    {
                        xPosition = originalX;
                        yPosition = originalY;
                        result = OUT_OF_BOUNDS_MESSAGE;
                    }
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
