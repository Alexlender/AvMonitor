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
            throw new NotImplementedException();
        }

        public void AddTask(TaskModel task)
        {


            /*if (task.Id == default)
                _taskDataContext.Entry(task).State = EntityState.Added;
            else
                _taskDataContext.Entry(task).State = EntityState.Modified;
            _taskDataContext.SaveChanges();*/

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
