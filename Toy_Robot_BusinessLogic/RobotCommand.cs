using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toy_Robot_BusinessLogic
{
    public class RobotCommand
    {
        // Variable Declaration

        private const int xLowerEdge = 0;
        private const int yLowerEdge = 0;

        private int xUpperEdge = -1;
        private int yUpperEdge = -1;
        public int xPosition = -1;
        public int yPosition = -1;
        private string direction = string.Empty;
        private bool isPlaced = false;

        // Constant Decalartion
        public const string INVALID_POSITION_MESSAGE = "Position is not valid";
        public const string NOT_PLACED_YET_MESSAGE = "Need to place robot first, as robot is not placed";
        public const string INVALID_COMMAND = "Command is not valid";
        public const string VALID_COMMANDS_MESSAGE = "Valid commands are:\nPLACE X,Y,Z\nMOVE\nLEFT\nRIGHT\nREPORT";

        //Constructor
        public RobotCommand()
        {
            // If nthg specified default value
            xUpperEdge = 5;
            yUpperEdge = 5;
        }
        public RobotCommand(int MaxSizeX, int MaxSizeY)
        {
            xUpperEdge = MaxSizeX;
            yUpperEdge = MaxSizeY;
        }

        // Valid Position Check
        private bool isValidatePosition()
        {
            if ((xPosition < xLowerEdge) || (yPosition < yLowerEdge))
                return false;
            else if ((xPosition > xUpperEdge) || (yPosition > yUpperEdge))
                return false;
            else
                return true;
        }
        
        //Robot Commands Like Place, Move, Right, Left, Report
        private string Place(string command)
        {
            string result = string.Empty;
            char[] delimiterChars = { ',', ' ' };
            string[] Commandstr = command.Split(delimiterChars);

            this.xPosition = Int32.Parse(Commandstr[1]);
            this.yPosition = Int32.Parse(Commandstr[2]);
            direction = Commandstr[3];

            if (!isValidatePosition())
                result = INVALID_POSITION_MESSAGE;
            else
                isPlaced = true;

            return result;
        }

        private string Report()
        {
            return this.xPosition + "," + this.yPosition + "," + this.direction;
        }

        private string Move()
        {
            string result = string.Empty;
            int X = this.xPosition;
            int Y = this.yPosition;
            string dir = this.direction;
            switch (dir.ToUpper())
            {
                case "NORTH":
                case "N":
                    this.yPosition = yPosition + 1;
                    break;
                case "WEST":
                case "W":
                    this.xPosition = xPosition - 1;
                    break;
                case "SOUTH":
                case "S":
                    this.yPosition= yPosition-1;
                    break;
                case "EAST":
                case "E":
                    this.xPosition = xPosition +1;
                    break;
            }
            if (!isValidatePosition())
            {
                xPosition = X;
                yPosition = Y;
                result = INVALID_POSITION_MESSAGE;
            }
            
            return result;
        }

        private void Left()
        {
            switch (direction)
            {
                case "NORTH":
                case "N":
                    direction = "WEST"; break;
                case "WEST":
                case "W":
                    direction = "SOUTH"; break;
                case "SOUTH":
                case "S":
                    direction = "EAST"; break;
                case "EAST":
                case "E":
                    direction = "NORTH"; break;
            }
        }

        private void Right()
        {
            switch (direction)
            {
                case "NORTH":
                case "N":
                    direction = "EAST"; break;
                case "E":
                case "EAST":
                    direction = "SOUTH"; break;
                case "S":
                case "SOUTH":
                    direction = "WEST"; break;
                case "W":
                case "WEST":
                    direction = "NORTH"; break;
            }
        }

        // main command to call other functions
        public string command(string input)
           {
            string commandUpperStr = input.ToUpper();
            string result = string.Empty;

            try
            {
                if (commandUpperStr.Contains("PLACE"))
                    result = Place(input);

                else if (!isPlaced)
                    result = NOT_PLACED_YET_MESSAGE;

                else if (commandUpperStr.Contains("REPORT"))
                    result = Report();

                else if (commandUpperStr.Contains("MOVE"))
                    result = Move();

                else if (commandUpperStr.Contains("LEFT"))
                    Left();

                else if (commandUpperStr.Contains("RIGHT"))
                    Right();

                else
                    result = INVALID_COMMAND;
            }
            catch (Exception e)
            {
                result = VALID_COMMANDS_MESSAGE;
            }

            return result;
        }

    }
}
