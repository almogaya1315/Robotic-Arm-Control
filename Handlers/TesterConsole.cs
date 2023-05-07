using Robotic_Arm_Control.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robotic_Arm_Control.Handlers
{
    public class TesterConsole
    {
        static void Main(string[] args)
        {
            var tracker = new RobotController();

            string[] instructions = new string[] { "right 10", "up 50", "left 30", "down 10" };
            int[] finalPosition = tracker.TrackRobot(instructions);
            RobotTracker.Output(finalPosition);

            instructions = new string[0];
            finalPosition = tracker.TrackRobot(instructions);
            RobotTracker.Output(finalPosition);

            instructions = new string[] { "right 100", "right 100", "up 500", "up 10000" };
            finalPosition = tracker.TrackRobot(instructions);
            RobotTracker.Output(finalPosition);

            tracker = new RobotController(100000);
            finalPosition = tracker.TrackRobot(instructions);
            RobotTracker.Output(finalPosition);
        }
    }
}
