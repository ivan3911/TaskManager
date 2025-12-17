using System.ComponentModel.DataAnnotations;
using TaskManager.Utilities;

namespace TaskManager.DTO
{
    public class TaskDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public Task_Status Status { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
