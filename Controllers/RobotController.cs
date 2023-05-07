using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Robotic_Arm_Control.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robotic_Arm_Control.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotController : ControllerBase
    {
        private readonly ILogger<RobotController> _logger;
        private readonly int _gridSize;

        public RobotController(int gridSize = 100)
        {
            _gridSize = gridSize;
        }

        [HttpGet]
        public int[] TrackRobot(string[] instructions)
        {
            int[] currentPosition = new int[] { 0, 0 };

            try
            {
                currentPosition = RobotTracker.Track(instructions, _gridSize);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in TrackRobot. " + e.Message);
            }

            return currentPosition;
        }
    }
}
