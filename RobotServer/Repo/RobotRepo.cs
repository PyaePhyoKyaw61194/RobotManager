using RobotServer.Entities;

namespace RobotServer.Repo
{
    public class RobotRepo : IRobotRepo
    {
        static readonly List<Robot> robotList = new();

        public bool CreateRobot(Robot robot)
        {
            try
            {
                robotList.Add(robot);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRobot(int index)
        {
            try
            {
                robotList.RemoveAt(index);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Robot? GetRobot(string id)
        {
            return robotList.Find(robot => robot.Id == Guid.Parse(id));
        }

        public int GetRobotIndexByName(string name)
        {
            return robotList.FindIndex(robot => robot.Name == name);
        }

        public int GetRobotIndexByName(string id, string name)
        {
            return robotList.FindIndex(robot => robot.Name == name && robot.Id != Guid.Parse(id));
        }

        public int GetRobotIndexById(string id)
        {
            return robotList.FindIndex(robot => robot.Id == Guid.Parse(id));
        }

        public List<Robot> GetRobots()
        {
            return robotList;
        }

        public bool UpdateRobot(Robot existingRobot)
        {
            try
            {
                var _index = robotList.FindIndex(_robot => _robot.Id == existingRobot.Id);
                robotList[_index] = existingRobot;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
