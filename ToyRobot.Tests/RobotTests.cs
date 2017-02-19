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
            string result = robot.command("REPORT");
            //assert
            Assert.AreEqual("<Command ignored - robot not placed yet>", result);
        }

        [TestMethod]
        public void Robot_CommandReturnTrue_AfterBeingPlaced()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,N");
            //assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Robot_Report_AfterBeingPlaced()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,N");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,N", result);
        }
    }
}
