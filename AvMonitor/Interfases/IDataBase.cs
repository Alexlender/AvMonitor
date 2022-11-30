using AvMonitor.Models;

namespace AvMonitor
{
    public interface IDataBase
    {
        void AddTask(TaskModel task);

        void DeleteTask(TaskModel task);

        void DeleteTaskByID(string Id);

        List<TaskModel> GetAllTasksFromUser(UserModel user);

        TaskModel GetTaskByID(string Id);

        void AddResponse(ResponseModel response);

        List<ResponseModel> GetAllResponsesByTask(TaskModel task);

        /// <summary>
        /// Возвращает n последних записей из таблицы
        /// </summary>
        /// <param name="task"></param>
        /// <param name="n">Количество возвращаемых записей</param>
        /// <returns></returns>
        List<ResponseModel> GetResponsesByTask(TaskModel task, int n);
    }
}
