using RobotServer.Entities;

namespace RobotServer.Repo
{
    public interface IRobotRepo
    {
        bool CreateRobot(Robot robot);
        Robot? GetRobot(string id);
        List<Robot> GetRobots();
        bool UpdateRobot(Robot robot);
        bool DeleteRobot(int index);

        int GetRobotIndexById(string id);
        int GetRobotIndexByName(string name);
        int GetRobotIndexByName(string id, string name);
    }
}
