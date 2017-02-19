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

        public string command(string input)
        {
            string output = string.Empty;

            if (!isPlaced)
                output = "<Command ignored, not yet placed>";

            return output;
        }
    }
}
