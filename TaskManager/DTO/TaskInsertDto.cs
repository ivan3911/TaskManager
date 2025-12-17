using System.ComponentModel.DataAnnotations;
using TaskManager.Utilities;

namespace TaskManager.DTO
{
    public class TaskInsertDto
    {
        [Required(ErrorMessage = "El titulo es obligatorio")]
        [MaxLength(80, ErrorMessage = "El numero maximo de caracteres es de 80")]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required(ErrorMessage = "El status es obligatorio")]
        public Task_Status Status { get; set; }

    }
}
