

using TaskManager.Utilities;

namespace TaskManager.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Task_Status Status { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
