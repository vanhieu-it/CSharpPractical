using APINETCORE_TaskDemo.Models.RequestModels;

namespace APINETCORE_TaskDemo.Services
{
    public interface ITaskService
    {
        void AddTask(TaskModel task);
        List<TaskModel> GetAll();
        TaskModel? GetOne(Guid id);

    }
}
