using AvMonitor.Data;
using AvMonitor.Models;
using Microsoft.EntityFrameworkCore;

namespace AvMonitor.Classes
{
    public class DataBase : IDataBase
    {

        private readonly TaskDataContext _taskDataContext;

        public DataBase(TaskDataContext TaskDataContext)
        {
            _taskDataContext = TaskDataContext;
        }


        public void AddResponse(ResponseModel response)
        {
            _taskDataContext.Responses.Add(response);
            _taskDataContext.SaveChanges();
            Console.WriteLine(_taskDataContext.Responses.AsEnumerable().Count());
        }

        public void AddTask(TaskModel task)
        {


            _taskDataContext.Tasks.Add(task);
            _taskDataContext.SaveChanges();

        }

        public void DeleteTask(TaskModel task)
        {
            if (task != null)
            {
                _taskDataContext.Tasks.Remove(task);
                _taskDataContext.SaveChanges();
            }
        }

        public void DeleteTaskByID(string Id)
        {
            TaskModel itemToRemove = GetTaskByID(Id);

            if (itemToRemove != null)
            {
                _taskDataContext.Tasks.Remove(itemToRemove);
                _taskDataContext.SaveChanges();
            }
        }

        public List<ResponseModel> GetAllResponsesByTask(TaskModel task)
        {
            return _taskDataContext.Responses.AsEnumerable().Where(response => response.TaskId == task.Id).ToList();
        }

        public List<TaskModel> GetAllTasksFromUser(UserModel user)
        {
            return _taskDataContext.Tasks.AsEnumerable().Where(task => task.UserName == user.Name).ToList();
        }

        public List<ResponseModel> GetResponsesByTask(TaskModel task, int n)
        {
            return _taskDataContext.Responses.AsEnumerable().Where(response => response.TaskId == task.Id).Reverse().Take(n).ToList();
        }

        public TaskModel? GetTaskByID(string Id)
        {
            return _taskDataContext.Tasks.AsEnumerable().Where(task => task.Id == Id).FirstOrDefault(null as TaskModel);
        }
    }
}
