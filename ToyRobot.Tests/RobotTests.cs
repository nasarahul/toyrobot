using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Core;

namespace ToyRobot.Tests
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void Robot_CommandReturnFalse_WhenNotPlacedYet()
        {
            //arrange
            Robot robot = new Robot();
            //act
            bool success = robot.command("REPORT");
            //assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void Robot_CommandReturnTrue_AfterBeingPlaced()
        {
            //arrange
            Robot robot = new Robot();
            //act
            bool success = robot.command("PLACE 0,0,N");
            //assert
            Assert.IsTrue(success);
        }
    }
}
