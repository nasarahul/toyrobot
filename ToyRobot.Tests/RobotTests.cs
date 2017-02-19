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

        [TestMethod]
        public void Robot_Report_0_1_N_AfterPlaced_0_0_N_AndSingleMove()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,N");
            result = robot.command("MOVE");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,1,N", result);
        }

        [TestMethod]
        public void Robot_Report_1_0_E_AfterPlaced_0_0_E_AndSingleMove()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,E");
            result = robot.command("MOVE");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("1,0,E", result);
        }

        [TestMethod]
        public void Robot_Report_1_0_S_AfterPlaced_1_1_S_AndSingleMove()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 1,1,S");
            result = robot.command("MOVE");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("1,0,S", result);
        }
        [TestMethod]
        public void Robot_Report_0_1_W_AfterPlaced_1_1_W_AndSingleMove()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 1,1,W");
            result = robot.command("MOVE");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,1,W", result);
        }
    }
}
