using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toy_Robot_BusinessLogic;

namespace Toy_Robot_MainApplication
{
    class Program
    {
       public static void Main(string[] args)
        {
            //Variable declaration 
            var stopApplication = false;
            RobotCommand robot = new RobotCommand();
            // Details explained
            const string description =
@"  TOY ROBOT
     Details!!!

  1: Place the toy on a 5 x 5 grid
     using the following command:

     PLACE X,Y,F (Where X and Y are integers and F 
     must be either NORTH, SOUTH, EAST or WEST)

  2: When the toy is placed, have at go at using
     the following commands.
                
     REPORT – Shows the current status of the toy. 
     LEFT   – turns the toy 90 degrees left.
     RIGHT  – turns the toy 90 degrees right.
     MOVE   – Moves the toy 1 unit in the facing direction.
     X   – Closes the toy Simulator.
";

      
            Console.WriteLine(description);
            //Loop until Program End or close
            do
            {
                //Taking input from user
                var command = Console.ReadLine();
                if (command == null) continue;
                // Condition check to close Programe
                if (command.Equals("X"))
                    stopApplication = true;
                else
                {
                    try
                    {
                        //Main function call for business logic
                        var output = robot.command(command);
                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            } while (!stopApplication);
        }
    }
}
