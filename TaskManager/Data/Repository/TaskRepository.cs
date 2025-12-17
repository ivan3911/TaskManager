
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

        public System.Threading.Tasks.Task AddTask(Entities.Task task)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entities.Task>> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Task?> GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateTask(Entities.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
