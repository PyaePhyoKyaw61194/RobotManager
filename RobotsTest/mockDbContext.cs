using RobotServer.Entities;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
namespace RobotsTest
{
    public class mockDbContext
    {
        public DbContextMock<RobotContext> getDbContext(Robot[] initialEntities)
        {
            DbContextMock<RobotContext> dbContextMock = new DbContextMock<RobotContext>(new DbContextOptionsBuilder<RobotContext>().Options);
            dbContextMock.CreateDbSetMock(x => x.RobotItems, initialEntities);
            return dbContextMock;
        }
    }
}
