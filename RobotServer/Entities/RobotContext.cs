﻿using Microsoft.EntityFrameworkCore;
namespace RobotServer.Entities
{
    public class RobotContext : DbContext
    {
        public RobotContext(DbContextOptions<RobotContext> options)
            : base(options)
        {
        }

        public DbSet<Robot> RobotItems { get; set; }
    }
}
