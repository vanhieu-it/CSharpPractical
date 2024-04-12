using System.ComponentModel.DataAnnotations;

namespace APINETCORE_TaskDemo.Models.RequestModels
{
    public class TaskModel
    {
        public Guid TaskId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
    }
}
