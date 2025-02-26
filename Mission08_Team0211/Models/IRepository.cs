namespace Mission08_Team0211.Models
{
    public interface IRepository
    {
        List<Task> Tasks { get; }
        List<Category> Categories { get; }
        public void AddTask(Task task);
        public Task EditTask(Task task);
        public void DeleteTask(Task task);
    }
}
