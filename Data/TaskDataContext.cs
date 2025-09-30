using Microsoft.EntityFrameworkCore;

namespace TaskMaster.Data;

public class TaskDataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Tasks.db");
        optionsBuilder.UseLazyLoadingProxies();
    }
    
    public DbSet<Task> Tasks { get; set; }
}