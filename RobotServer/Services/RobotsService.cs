using Grpc.Core;
using RobotServer.Entities;

namespace RobotServer.Services
{
    public class RobotsService : Robots.RobotsBase
    {
        /// <summary>
        /// List for storing Robot Data
        /// </summary>
        static List<Robot> robotList = new();
  
        #region Robot Creation
        public override async Task<Reply> CreateRobot(RobotCreateRequest request, ServerCallContext context)
        {
            try
            {
                // Empty string Check : Client side will also check
                if (request.Name.Length == 0)
                {
                    return await Task.FromResult(new Reply
                    {
                        Result = "Name should be filled",
                        IsOk = false
                    });
                }

                // Robot with same name is not allowed to create 
                var duplicateUserIndex = robotList.FindIndex(robot => robot.Name == request.Name);

                // If duplicate data exists, terminate
                if (duplicateUserIndex != -1)
                {
                    return await Task.FromResult(new Reply
                    {
                        Result = "Duplicate Robot existed",
                        IsOk = false
                    });
                }

                Robot _robot = new()
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Description = request.Description
                };

                // Avoiding null Error
                robotList ??= new List<Robot>();

                // Adding to the DB: currently not a persistence DB
                robotList.Add(_robot);

                // Return the successful response
                return await Task.FromResult(new Reply
                {
                    Result = $"Welcome {request.Name}. You're one of our Robots now!! {robotList.Count}",
                    IsOk = true
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new Reply
                {
                    Result = $"Internal Error. {ex}.",
                    IsOk = false
                });
            }

        }
        #endregion

        #region Getting Robot By Id
        public override async Task<RobotModel> GetRobotById(RobotLookUpRequest request, ServerCallContext context)
        {

            RobotModel robotModel = new();

            try
            {
                var existingRobot = robotList.Find(robot => robot.Id == Guid.Parse(request.Id));
                
                // If there is no robot with given Id
                if (existingRobot == null)
                {
                    robotModel.Error = new Reply
                    {
                        Result = "No record Found",
                        IsOk = false
                    };
                    return await Task.FromResult(robotModel);
                }

                // Parsing GUID to string
                robotModel.Id = existingRobot?.Id.ToString();
                robotModel.Name = existingRobot?.Name;
                robotModel.Description = existingRobot?.Description;

                return await Task.FromResult(robotModel);
            }
            catch (Exception)
            {
                robotModel.Error = new Reply
                {
                    Result = "No record Found",
                    IsOk = false
                };
                return await Task.FromResult(robotModel);
            }

        }
        #endregion
    }
}
