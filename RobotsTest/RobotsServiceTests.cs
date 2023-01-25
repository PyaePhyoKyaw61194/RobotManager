using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using RobotServer;
using RobotServer.Entities;
using RobotServer.Services;

namespace RobotsTest
{
    public class RobotsServiceTests
    {
        private static RobotsService RobotsServiceInit(DbContextMock<RobotContext> dbContextMock)
        {
            return new RobotsService(dbContextMock.Object);
        }

        private static List<Robot> GetMockDbEntities()
        {
            return new List<Robot>
             {
                new Robot {Id = Guid.Parse("e194976b-451a-4878-90f6-47071a5ef05f"), Name="Robot 1", Description="This is Robot 1"},
                new Robot {Id =  Guid.Parse("e0ef817f-b414-408e-8fb9-c70150a35ee8"), Name="Robot 2", Description="This is Robot 2"},
                new Robot {Id =  Guid.Parse("5ed3bf64-9514-4e32-9ae6-2ae2351fc7c4"), Name="Robot 3", Description="This is Robot 3"},
            };
        }

        public static DbContextMock<RobotContext> GetDbContext(List<Robot> initialEntities)
        {
            var opt = new DbContextOptionsBuilder<RobotContext>();
            DbContextMock<RobotContext> dbContextMock = new(opt.Options);

            dbContextMock.CreateDbSetMock(x => x.RobotItems, initialEntities);
            return dbContextMock;
        }
       
        [Fact]
        public async void GetAllRobotsTest()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = GetDbContext(GetMockDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            //act
            Empty emp = new();
            var result = await robotsService.GetRobotList(emp, TestServerCallContext.Create());

            //assert
            Assert.Equal(3, result.Items.Count);
        }

        [Fact]
        public async void GetRobotByIdTest()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = GetDbContext(GetMockDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);


            //act
            RobotLookUpRequest req = new () { Id = "e194976b-451a-4878-90f6-47071a5ef05f" };
            var result = await robotsService.GetRobotById(req, TestServerCallContext.Create());

            //assert
            Assert.IsType<RobotModel>(result);
            Assert.Equal("e194976b-451a-4878-90f6-47071a5ef05f", result.Id);
        }

        [Fact]
        public async void GetRobotWithInvalidId()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = GetDbContext(GetMockDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            //act
            // invalid id
            RobotLookUpRequest req = new () { Id = "104071a8-eea5-4faf-abd9-373c51ec5dd3" };
            var result = await robotsService.GetRobotById(req, TestServerCallContext.Create());


            //assert
            Assert.Equal("No record Found", result.Error.Result);
            Assert.False(result.Error.IsOk);
        }

        [Fact]
        public async void GetRobotWithBrokenId()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = GetDbContext(GetMockDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            //act
            // invalid id
            RobotLookUpRequest req = new() { Id = "xxxxx" };
            var result = await robotsService.GetRobotById(req, TestServerCallContext.Create());


            //assert
            Assert.NotEmpty(result.Error.Result);
            Assert.False(result.Error.IsOk);
        }

        [Fact]
        public async void UpdateRobotTest()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = GetDbContext(GetMockDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            Robot tobeUpdated = GetMockDbEntities()[2];
            tobeUpdated.Name = "new name";


            //act
            RobotUpdateRequest req = new ()
            {
                Id = tobeUpdated.Id.ToString(),
                Name = tobeUpdated.Name,
                Description = tobeUpdated.Description
            };
            await robotsService.UpdateRobot(req, TestServerCallContext.Create());
            Robot? updatedItem = dbContextMock.Object.RobotItems.Find(tobeUpdated.Id);

            //assert
            Assert.NotNull(updatedItem?.Name);
            Assert.Equal(tobeUpdated.Name, updatedItem.Name);
            Assert.Equal(tobeUpdated.Description, updatedItem.Description);
        }

        [Fact]
        public async Task UpdateRobotWithInvalidIdTestAsync()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = GetDbContext(GetMockDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            Robot tobeUpdated = GetMockDbEntities()[2];

            //act
            RobotUpdateRequest req = new ()
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
        public async Task UpdateRobotWithBrokenIdTestAsync()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = GetDbContext(GetMockDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            Robot tobeUpdated = GetMockDbEntities()[2];

            //act
            RobotUpdateRequest req = new()
            {
                // broken id
                Id = "####",
                Name = tobeUpdated.Name,
                Description = tobeUpdated.Description
            };
            var result = await robotsService.UpdateRobot(req, TestServerCallContext.Create());

            //assert

            Assert.False(result.IsOk);

        }

        [Fact]
        public async Task UpdateRobotWithEmptyNameTestAsync()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = GetDbContext(GetMockDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            Robot tobeUpdated = GetMockDbEntities()[2];

            //act
            RobotUpdateRequest req = new ()
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
            DbContextMock<RobotContext> dbContextMock = GetDbContext(GetMockDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            Robot tobeUpdated = GetMockDbEntities()[2];

            //act
            RobotUpdateRequest req = new ()
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
            DbContextMock<RobotContext> dbContextMock = GetDbContext(GetMockDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);
            long id = 3;

            //act
            RobotLookUpRequest req = new ()
            {
                Id = "e194976b-451a-4878-90f6-47071a5ef05f"
            };
            var result = await robotsService.DeleteRobot(req, TestServerCallContext.Create());

            //assert
            Assert.True(result.IsOk);
            Assert.Null(dbContextMock.Object.RobotItems.Find(id));
        }

        [Fact]
        public async void DeleteRobotWithInvalidIdTest()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = GetDbContext(GetMockDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);


            //act
            RobotLookUpRequest req = new ()
            {
                // invalid id
                Id = "e194976b-451a-4878-90f6-47071a5ef12f"
            };
            var result = await robotsService.DeleteRobot(req, TestServerCallContext.Create());

            //assert
            Assert.False(result.IsOk);
        }

        [Fact]
        public async void DeleteRobotWithBrokenIdTest()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = GetDbContext(GetMockDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);


            //act
            RobotLookUpRequest req = new()
            {
                // broken id
                Id = "###"
            };
            var result = await robotsService.DeleteRobot(req, TestServerCallContext.Create());

            //assert
            Assert.False(result.IsOk);
        }

        [Fact]
        public async void CreateRobotTest()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = GetDbContext(GetMockDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            Robot toBeAdded = new () { Name = "Robot 4", Description = "This is Robot 4" };

            //act
            RobotCreateRequest req = new ()
            {
                Name = toBeAdded.Name,
                Description = toBeAdded.Description
            };
            var result = await robotsService.CreateRobot(req, TestServerCallContext.Create());


            //assert
            Assert.Equal(toBeAdded.Name, dbContextMock.Object.RobotItems.First(item => item.Name == toBeAdded.Name).Name);
            Assert.True(result.IsOk);
        }

        [Fact]
        public async void CreateRobotWithEmptyNameTest()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = GetDbContext(GetMockDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            Robot toBeAdded = new () { Name = "", Description = "This is Robot 4" };

            //act
            RobotCreateRequest req = new ()
            {
                Name = toBeAdded.Name,
                Description = toBeAdded.Description
            };
            var result = await robotsService.CreateRobot(req, TestServerCallContext.Create());


            //assert
            Assert.Equal("Name should be filled", result.Result);
            Assert.False(result.IsOk);
        }

        [Fact]
        public async void CreateRobotWithDuplicateNameTest()
        {
            //arrange
            DbContextMock<RobotContext> dbContextMock = GetDbContext(GetMockDbEntities());
            RobotsService robotsService = RobotsServiceInit(dbContextMock);

            Robot toBeAdded = new () { Name = "Robot 1", Description = "This is Robot 4" };

            //act
            RobotCreateRequest req = new ()
            {
                Name = toBeAdded.Name,
                Description = toBeAdded.Description
            };
            var result = await robotsService.CreateRobot(req, TestServerCallContext.Create());


            //assert
            Assert.Equal("Duplicate Robot existed", result.Result);
            Assert.False(result.IsOk);
        }
    }
}
