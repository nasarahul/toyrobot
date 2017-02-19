using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Core;

namespace UnitTestProject2
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void Robot_WillIgnoreCommand_WhenNotPlacedYet()
        {
            //arrange
            Robot robot = new Robot();

            //act
            string output = robot.command("REPORT");

            //assert
            Assert.AreEqual(output, "<Command ignored, not yet placed>");
        }
    }
}
