using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robotic_Arm_Control.Handlers
{
    public static class RobotTracker
    {
        public static int[] Track(string[] instructions, int gridSize)
        {
            int[] currentPosition = new int[] { 0, 0 };

            foreach (var inst in instructions)
            {
                var parts = inst.Split(' ');
                var direction = parts[0];
                int distance = int.Parse(parts[1]);

                switch (direction)
                {
                    case "right":
                        currentPosition[0] = Math.Min(currentPosition[0] + distance, gridSize);
                        break;
                    case "left":
                        currentPosition[0] = Math.Max(currentPosition[0] - distance, -gridSize);
                        break;
                    case "up":
                        currentPosition[1] = Math.Min(currentPosition[1] + distance, gridSize);
                        break;
                    case "down":
                        currentPosition[1] = Math.Max(currentPosition[1] - distance, -gridSize);
                        break;
                    default:
                        throw new ArgumentException("Invalid instruction: " + inst);
                }
            }

            return currentPosition;
        }

        public static void Output(int[] finalPosition)
        {
            Console.WriteLine("Final Position: ({0}, {1})", finalPosition[0], finalPosition[1]);
        }
    }
}
