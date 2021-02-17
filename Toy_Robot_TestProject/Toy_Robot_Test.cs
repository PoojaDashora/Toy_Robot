using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toy_Robot_BusinessLogic;

namespace Toy_Robot_TestProject
{
    [TestClass]
    public class Toy_Robot_Test
    {
       
        
        [TestMethod]
        public void BasicTest()
        {
           
            RobotCommand Robot = new RobotCommand();
            string result = Robot.command("PLACE 0,0,NORTH");
            result = Robot.command("MOVE");
            result = Robot.command("REPORT");
            //assert
            Assert.AreEqual("0,1,NORTH", result);
        }

        [TestMethod]
        public void ReturnsErrorMessage()
        {

            RobotCommand Robot = new RobotCommand();
            string result = Robot.command("PLACE 1,2,EAST");
            result = Robot.command("TEST");
            Assert.AreEqual(RobotCommand.INVALID_COMMAND, result);
        }
        [TestMethod]
        public void ValidCommandsMessage()
        {
            RobotCommand Robot = new RobotCommand();
            string result = Robot.command("PLACE %,2,EAST");
            Assert.AreEqual(RobotCommand.VALID_COMMANDS_MESSAGE, result);
        }


        [TestMethod]
        public void WhenNotPlaced()
        {
            RobotCommand robot = new RobotCommand();
            string result = robot.command("REPORT");
            Assert.AreEqual(RobotCommand.NOT_PLACED_YET_MESSAGE, result);
        }
    }
}
