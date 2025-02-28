namespace Mission08_Team0211.Models
{
    public class EFTaskRepository : IRepository
    {
        private TaskDbContext _context;
        public EFTaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        public IQueryable<Task> Tasks => _context.Tasks;
        public IQueryable<Category> Categories => _context.Categories;
        public void AddTask(Task task) {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
        public void DeleteTask(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
        public Task EditTask(Task task) {
            _context.Tasks.Update(task);
            _context.SaveChanges();
            return task;
        }
    }
}
