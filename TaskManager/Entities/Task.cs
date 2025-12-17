

using System.ComponentModel.DataAnnotations;
using TaskManager.Utilities;

namespace TaskManager.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }
        
        [Required]
        public Task_Status Status { get; set; }
        
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
