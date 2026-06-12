using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.MVC.ViewModels;

namespace TaskManagement.MVC.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskViewModel>> GetAllTasks();
        Task<TaskViewModel?> GetTaskById(int id);
        Task<bool> CreateTask(TaskViewModel task);
    }
}