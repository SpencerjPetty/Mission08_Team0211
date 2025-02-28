namespace Mission08_Team0211.Models
{
    public interface IRepository
    {
        IQueryable<Task> Tasks { get; }
        IQueryable<Category> Categories { get; }
        public void AddTask(Task task);
        public Task EditTask(Task task);
        public void DeleteTask(Task task);
    }
}
