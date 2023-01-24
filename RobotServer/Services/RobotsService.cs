﻿using Grpc.Core;
using RobotServer.Entities;
using RobotServer.Repo;

namespace RobotServer.Services
{
    public class RobotsService : Robots.RobotsBase
    {

        private IRobotRepo _robotRepo;

        public RobotsService(IRobotRepo robotRepo)
        {
            _robotRepo = robotRepo;
        }

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
                var duplicateUserIndex = _robotRepo.GetRobotIndexByName(request.Name);

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

                // Adding to the DB: currently not a persistence DB
                _robotRepo.CreateRobot(_robot);

                // Return the successful response
                return await Task.FromResult(new Reply
                {
                    Result = $"Welcome {request.Name}. You're one of our Robots now!!",
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
                var existingRobot = _robotRepo.GetRobot(request.Id);

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

        #region Getting All Robots
        public override async Task<RobotList> GetRobotList(Empty request, ServerCallContext context)
        {
            RobotList protoRobotList = new();
            try
            {
                List<RobotModel> robotModelList = new();

                List<Robot> robotList = _robotRepo.GetRobots();
                // If there is data to return
                if (robotList != null && robotList.Count != 0)
                {
                    foreach (Robot robot in robotList)
                    {
                        RobotModel robotModel = new()
                        {
                            Id = robot.Id.ToString(),
                            Name = robot.Name,
                            Description = robot.Description
                        };
                        robotModelList.Add(robotModel);
                    }
                    protoRobotList.Items.AddRange(robotModelList);
                }
                else
                {
                    protoRobotList.Error = new Reply
                    {
                        Result = "No Record Found",
                        IsOk = false
                    };
                    return await Task.FromResult(protoRobotList);
                }
            }
            catch (Exception ex)
            {
                protoRobotList.Error = new Reply
                {
                    Result = ex.Message,
                    IsOk = false
                };

                return await Task.FromResult(protoRobotList);
            }
            return await Task.FromResult(protoRobotList);
        }
        #endregion

        #region Updating Robot Info
        public override async Task<Reply> UpdateRobot(RobotUpdateRequest request, ServerCallContext context)
        {
            try
            {
                var existingRobot = _robotRepo.GetRobot(request.Id);
                if (existingRobot == null)
                {
                    return await Task.FromResult(new Reply()
                    {
                        Result = $"I cannot find {request.Name} in Robot List",
                        IsOk = false
                    });
                }


                if (request.Name.Length == 0)
                {
                    return await Task.FromResult(new Reply
                    {
                        Result = "Name should be Filled",
                        IsOk = false
                    });
                }

                // Checking robot with same name is already existed in DB
                var duplicateUserIndex = _robotRepo.GetRobotIndexByName(request.Id, request.Name);
                if (duplicateUserIndex != -1)
                {
                    return await Task.FromResult(new Reply
                    {
                        Result = "Duplicate Record Existed",
                        IsOk = false
                    });
                }

                existingRobot.Id = Guid.Parse(request.Id);
                existingRobot.Name = request.Name;
                existingRobot.Description = request.Description;

                // Updating the Data
                var _index = _robotRepo.GetRobotIndexById(request.Id);
                _robotRepo.UpdateRobot(existingRobot);
       

                return await Task.FromResult(new Reply
                {
                    Result = $"{request.Name} : the robot is updated",
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

        #region Deleting Robot Info
        public override async Task<Reply> DeleteRobot(RobotLookUpRequest request, ServerCallContext context)
        {
            try
            {
                var existingRobotIndex = _robotRepo.GetRobotIndexById(request.Id);
                if (existingRobotIndex == -1)
                {
                    return await Task.FromResult(new Reply()
                    {
                        Result = "No record Found to delete",
                        IsOk = false
                    });
                }
                _robotRepo.DeleteRobot(existingRobotIndex);

                return await Task.FromResult(new Reply
                {
                    Result = "Your Robot Record is deleted",
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

        #region Testing Connection
        public override async Task<Reply> TestConnection(Empty request, ServerCallContext context)
        {
            return await Task.FromResult(new Reply
            {
                Result = $"Connection is Ok",
                IsOk = true
            });
        }
        #endregion
    }
}
