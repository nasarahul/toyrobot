using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Core;

namespace ToyRobot.Tests
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void Robot_CommandIgnored_WhenNotPlacedYet()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("REPORT");
            //assert
            Assert.AreEqual(Robot.NOT_PLACED_YET_MESSAGE, result);
        }

        [TestMethod]
        public void Robot_CommandReturnEmptyString_AfterBeingPlaced()
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

        // ************** Test cardinal directions ********************************************
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

        // ************** Test left direction ********************************************
        [TestMethod]
        public void Robot_Report_0_0_W_AfterPlaced_0_0_N_AndLeftCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,N");
            result = robot.command("LEFT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,W", result);
        }

        [TestMethod]
        public void Robot_Report_0_0_S_AfterPlaced_0_0_W_AndLeftCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,W");
            result = robot.command("LEFT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,S", result);
        }

        [TestMethod]
        public void Robot_Report_0_0_E_AfterPlaced_0_0_S_AndLeftCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,S");
            result = robot.command("LEFT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,E", result);
        }

        [TestMethod]
        public void Robot_Report_0_0_N_AfterPlaced_0_0_E_AndLeftCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,E");
            result = robot.command("LEFT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,N", result);
        }

        // ************** Test right direction ********************************************
        [TestMethod]
        public void Robot_Report_0_0_E_AfterPlaced_0_0_N_AndRightCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,N");
            result = robot.command("RIGHT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,E", result);
        }
        [TestMethod]
        public void Robot_Report_0_0_S_AfterPlaced_0_0_E_AndRightCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,E");
            result = robot.command("RIGHT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,S", result);
        }
        [TestMethod]
        public void Robot_Report_0_0_W_AfterPlaced_0_0_S_AndRightCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,S");
            result = robot.command("RIGHT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,W", result);
        }
        [TestMethod]
        public void Robot_Report_0_0_N_AfterPlaced_0_0_W_AndRightCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,W");
            result = robot.command("RIGHT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,N", result);
        }

        // ************** Test robot environment boundaries on placement ******************************
        [TestMethod]
        public void Robot_IgnoreCommand_AfterPlace_NegativeXCoordinate()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE -1,0,W");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDS_MESSAGE, result);
        }
        [TestMethod]
        public void Robot_IgnoreCommand_AfterPlace_NegativeYCoordinate()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,-1,W");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDS_MESSAGE, result);
        }
        [TestMethod]
        public void Robot_IgnoreCommand_AfterPlace_UpperBoundX()
        {
            //arrange
            Robot robot = new Robot(5, 5);
            //act
            string result = robot.command("PLACE 6,5,W");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDS_MESSAGE, result);
        }
        [TestMethod]
        public void Robot_IgnoreCommand_AfterPlace_UpperBoundY()
        {
            //arrange
            Robot robot = new Robot(5, 5);
            //act
            string result = robot.command("PLACE 5,6,W");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDS_MESSAGE, result);
        }

        // ************** Test robot environment boundaries on movement ************************
        [TestMethod]
        public void Robot_IgnoreCommand_AfterMove_NegativeXCoordinate()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,W");
            result = robot.command("MOVE");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDS_MESSAGE, result);
        }
        [TestMethod]
        public void Robot_IgnoreCommand_AfterMove_NegativeYCoordinate()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,S");
            result = robot.command("MOVE");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDS_MESSAGE, result);
        }
        [TestMethod]
        public void Robot_IgnoreCommand_AfterMove_UpperBoundXCoordinate()
        {
            //arrange
            Robot robot = new Robot(1,1);
            //act
            string result = robot.command("PLACE 0,0,E");
            result = robot.command("MOVE");
            result = robot.command("MOVE");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDS_MESSAGE, result);
        }
        [TestMethod]
        public void Robot_IgnoreCommand_AfterMove_UpperBoundYCoordinate()
        {
            //arrange
            Robot robot = new Robot(1,1);
            //act
            string result = robot.command("PLACE 0,0,N");
            result = robot.command("MOVE");
            result = robot.command("MOVE");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDS_MESSAGE, result);
        }

        // ************** Sample tests provided ************************
        [TestMethod]
        public void ProvidedTest_A()
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
        public void ProvidedTest_B()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,N");
            result = robot.command("LEFT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,W", result);
        }
        [TestMethod]
        public void ProvidedTest_C()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 1,2,E");
            result = robot.command("MOVE");
            result = robot.command("MOVE");
            result = robot.command("LEFT");
            result = robot.command("MOVE");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("3,3,N", result);
        }
    }
}
