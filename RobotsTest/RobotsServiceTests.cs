using EntityFrameworkCoreMock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using RobotServer;
using RobotServer.Entities;
using RobotServer.Services;

namespace RobotsTest
{
    public class RobotsServiceTests
    {
        private RobotsService RobotsServiceInit(DbContextMock<RobotContext> dbContextMock)
        {
            return new RobotsService(dbContextMock.Object);
        }

        private List<Robot> getInitialDbEntities()
        {
            return new List<Robot>
             {
                new Robot {Id = Guid.Parse("e194976b-451a-4878-90f6-47071a5ef05f"), Name="Robot 1", Description="This is Robot 1"},
                new Robot {Id =  Guid.Parse("e0ef817f-b414-408e-8fb9-c70150a35ee8"), Name="Robot 2", Description="This is Robot 2"},
                new Robot {Id =  Guid.Parse("5ed3bf64-9514-4e32-9ae6-2ae2351fc7c4"), Name="Robot 3", Description="This is Robot 3"},
            };
        }

        public DbContextMock<RobotContext> getDbContext(List<Robot> initialEntities)
        {
            var opt = new DbContextOptionsBuilder<RobotContext>();
            //opt.UseInMemoryDatabase("RobotTestList");
            DbContextMock<RobotContext> dbContextMock = new DbContextMock<RobotContext>(opt.Options);

            dbContextMock.CreateDbSetMock(x => x.RobotItems, initialEntities);
            return dbContextMock;
        }
        [Fact]
        public async void GetAllRobotsTest()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = getDbContext(getInitialDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            //act
            Empty emp = new Empty();
            var result = await robotsService.GetRobotList(emp, TestServerCallContext.Create());

            //assert
            Assert.Equal(3, result.Items.Count);
        }

        [Fact]
        public async void GetRobotByIdTest()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = getDbContext(getInitialDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);


            //act
            RobotLookUpRequest req = new RobotLookUpRequest() { Id = "e194976b-451a-4878-90f6-47071a5ef05f" };
            var result = await robotsService.GetRobotById(req, TestServerCallContext.Create());

            //assert
            Assert.IsType<RobotModel>(result);
            Assert.Equal("e194976b-451a-4878-90f6-47071a5ef05f", result.Id);
        }

        [Fact]
        public async void GetRobotsWithInvalidId()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = getDbContext(getInitialDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            //act
            // invalid id
            RobotLookUpRequest req = new RobotLookUpRequest() { Id = "104071a8-eea5-4faf-abd9-373c51ec5dd3" };
            var result = await robotsService.GetRobotById(req, TestServerCallContext.Create());


            //assert
            Assert.Equal("No record Found", result.Error.Result);
            Assert.False(result.Error.IsOk);
        }

        [Fact]
        public async void GetRobotsWithBrokenId()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = getDbContext(getInitialDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            //act
            // invalid id
            RobotLookUpRequest req = new RobotLookUpRequest() { Id = "xxxxx" };
            var result = await robotsService.GetRobotById(req, TestServerCallContext.Create());


            //assert
            Assert.NotEmpty(result.Error.Result);
            Assert.False(result.Error.IsOk);
        }


        [Fact]
        public async void UpdateRobotTest()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = getDbContext(getInitialDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            Robot tobeUpdated = getInitialDbEntities()[2];
            tobeUpdated.Name = "new name";


            //act
            RobotUpdateRequest req = new RobotUpdateRequest()
            {
                Id = tobeUpdated.Id.ToString(),
                Name = tobeUpdated.Name,
                Description = tobeUpdated.Description
            };
            var result = await robotsService.UpdateRobot(req, TestServerCallContext.Create());
            Robot? updatedItem = dbContextMock.Object.RobotItems.Find(tobeUpdated.Id);

            //assert
            Assert.Equal(tobeUpdated.Name, updatedItem.Name);
            Assert.Equal(tobeUpdated.Description, updatedItem.Description);
        }

        [Fact]
        public async Task UpdateRobotWithInvalidIdTestAsync()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = getDbContext(getInitialDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            Robot tobeUpdated = getInitialDbEntities()[2];

            //act
            RobotUpdateRequest req = new RobotUpdateRequest()
            {
                // invalid id
                Id = "29d2a981-ca26-4ad5-868f-52a8c9894c41",
                Name = tobeUpdated.Name,
                Description = tobeUpdated.Description
            };
            var result = await robotsService.UpdateRobot(req, TestServerCallContext.Create());

            //assert

            Assert.False(result.IsOk);
            Assert.Equal($"I cannot find {tobeUpdated.Name} in Robot List", result.Result);

        }

        [Fact]
        public async Task UpdateRobotWithEmptyNameTestAsync()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = getDbContext(getInitialDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            Robot tobeUpdated = getInitialDbEntities()[2];

            //act
            RobotUpdateRequest req = new RobotUpdateRequest()
            {
                Id = tobeUpdated.Id.ToString(),
                Name = "",
                Description = tobeUpdated.Description
            };
            var result = await robotsService.UpdateRobot(req, TestServerCallContext.Create());

            //assert

            Assert.False(result.IsOk);
            Assert.Equal("Name should be Filled", result.Result);

        }

        [Fact]
        public async Task UpdateRobotWithDuplicateNameTestAsync()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = getDbContext(getInitialDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            Robot tobeUpdated = getInitialDbEntities()[2];

            //act
            RobotUpdateRequest req = new RobotUpdateRequest()
            {
                Id = tobeUpdated.Id.ToString(),
                Name = "Robot 1",
                Description = tobeUpdated.Description
            };
            var result = await robotsService.UpdateRobot(req, TestServerCallContext.Create());

            //assert

            Assert.False(result.IsOk);
            Assert.Equal("Duplicate Record Existed", result.Result);

        }


        [Fact]
        public async void DeleteRobotTest()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = getDbContext(getInitialDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);
            long id = 3;

            //act
            RobotLookUpRequest req = new RobotLookUpRequest()
            {
                Id = "e194976b-451a-4878-90f6-47071a5ef05f"
            };
            var result = await robotsService.DeleteRobot(req, TestServerCallContext.Create());

            //assert
            Assert.True(result.IsOk);
            Assert.Null(dbContextMock.Object.RobotItems.Find(id));
        }

        [Fact]
        public async void DeleteRobotWithInvaliIdTest()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = getDbContext(getInitialDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);
            long id = 3;

            //act
            RobotLookUpRequest req = new RobotLookUpRequest()
            {
                // invalid id
                Id = "e194976b-451a-4878-90f6-47071a5ef12f"
            };
            var result = await robotsService.DeleteRobot(req, TestServerCallContext.Create());

            //assert
            Assert.False(result.IsOk);
        }
    }
}
