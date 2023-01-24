using Moq;
using RobotServer;
using RobotServer.Repo;
using RobotServer.Services;
using RobotServer.Tests;

namespace RobotTest
{
    public class RobotServiceTest
    {
        [Fact]
        public async Task CreateRobotTest()
        {
            // Arrange
            var mockRobotRepo = new Mock<IRobotRepo>();
           
            //mockRobotRepo.Setup(
            //     m => m.InitStorage(new List<RobotServer.Entities.Robot>()));
            var service = new RobotsService(mockRobotRepo.Object);

            // Act
            //RobotCreateRequest req = new RobotCreateRequest()
            //{
              
            //    Description = "robot 1 Description"
            //};
            //var response = await service.CreateRobot(
            //    req, TestServerCallContext.Create());
            Empty empty = new Empty();
            var response = await service.GetRobotList(empty,TestServerCallContext.Create());
            // Assert
            //mockRobotRepo.Verify(v => v.Greet("Joe"));
            Assert.Equal("Hello Joe", response.Error.ToString());
        }
    }
}
