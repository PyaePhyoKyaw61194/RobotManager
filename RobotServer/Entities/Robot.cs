using System.ComponentModel.DataAnnotations;

namespace RobotServer.Entities
{
    public class Robot
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
