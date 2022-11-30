using AvMonitor.Models;

namespace AvMonitor.Classes
{
    public class DataBase : IDataBase
    {

        private static DataBase? _instance;

        private DataBase()
        {
            //конструктор
        }

        public static DataBase GetInstance()
        {
            if (_instance == null)
                _instance = new DataBase();
            return _instance;
        }

        public void AddResponse(ResponseModel response)
        {
            throw new NotImplementedException();
        }

        public void AddTask(TaskModel task)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(TaskModel task)
        {
            throw new NotImplementedException();
        }

        public void DeleteTaskByID(string Id)
        {
            throw new NotImplementedException();
        }

        public List<ResponseModel> GetAllResponsesByTask(TaskModel task)
        {
            throw new NotImplementedException();
        }

        public List<TaskModel> GetAllTasksFromUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public List<ResponseModel> GetResponsesByTask(TaskModel task, int n)
        {
            throw new NotImplementedException();
        }

        public TaskModel GetTaskByID(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
