
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TaskManager.Data.Repository
{

    //implementacion de la interfaz para el patron repository
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Entities.Task> AddTask(Entities.Task task)
        {
            task.CreationDate = DateTime.Now;
            EntityEntry<Entities.Task> entityEntry = await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task DeleteTask(Entities.Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Entities.Task>> GetAllTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return tasks;
        }

        public Task<Entities.Task?> GetTaskById(int id)
        { 
            var task = _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            return task;
        }

        public async Task UpdateTask(Entities.Task task)
        {
            task.CreationDate = DateTime.Now;
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}
