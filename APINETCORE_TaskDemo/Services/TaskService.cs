using APINETCORE_TaskDemo.Models.RequestModels;

namespace APINETCORE_TaskDemo.Services
{
    public class TaskService: ITaskService
    {
        private static List<TaskModel> _taskList = new List<TaskModel>(){
            new TaskModel{
                TaskId = Guid.NewGuid(),
                Title = "Task 01",
                IsCompleted = true
            },
            new TaskModel{
                TaskId = Guid.NewGuid(),
                Title = "Task 02",  
                IsCompleted = false
            },
            new TaskModel{
                TaskId = Guid.NewGuid(),
                Title = "Task 03",
                IsCompleted = true
            }
        };

        public void AddTask(TaskModel task)
        {
            var newTask = new TaskModel
            {
                TaskId = Guid.NewGuid(),
                Title = task.Title,
                IsCompleted = task.IsCompleted
            };
            _taskList.Add(newTask);
        }

        public List<TaskModel> GetAll()
        {
            return _taskList;
        }

        public TaskModel? GetOne(Guid id)
        {
            return _taskList.FirstOrDefault(x => x.TaskId == id);
        }

    }
}
