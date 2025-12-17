namespace TaskManager.Data.Repository
{
    //interfaz para el patron repository

    public interface ITaskRepository
    {
        Task<IEnumerable<Entities.Task>> GetAllTasks();
        Task<Entities.Task?> GetTaskById(int id);
        Task<Entities.Task> AddTask(Entities.Task task);
        Task UpdateTask(Entities.Task task);
        Task DeleteTask(Entities.Task task);
    }
}
