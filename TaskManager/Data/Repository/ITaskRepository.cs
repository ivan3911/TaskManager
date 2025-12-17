namespace TaskManager.Data.Repository
{
    //interfaz para el patron repository

    public interface ITaskRepository
    {
        Task<IEnumerable<Entities.Task>> GetAllTasks();
        Task<Entities.Task?> GetTaskById(int id);
        Task AddTask(Entities.Task task);
        Task UpdateTask(Entities.Task task);
        Task DeleteTask(int id);
    }
}
