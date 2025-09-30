using System.Collections.ObjectModel;

namespace TaskMaster.Data;

public class DataManager
{
    public static ObservableCollection<Task> GetTasks()
    {
        var tasks = new ObservableCollection<Task>();
        
        tasks.Add(new Task
        {
            Title = "Finalize Project Proposal",
            ProjectName = "TaskMaster",
            DueDate = DateTime.Today.AddDays(1),
            IsCompleted = false
        });
        
        tasks.Add(new Task
        {
            Title = "Schedule Social Media Posts",
            ProjectName = "Marketing Campaign",
            DueDate = DateTime.Today.AddDays(1),
            IsCompleted = false
        });
        
        tasks.Add(new Task
        {
            Title = "Review Design Mockups",
            ProjectName = "Product Development",
            DueDate = DateTime.Today.AddDays(-1),
            IsCompleted = false
        });
        
        tasks.Add(new Task
        {
            Title = "Follow up with Potential clients",
            ProjectName = "Sales strategy",
            DueDate = DateTime.Today.AddDays(-3),
            IsCompleted = false
        });
        
        tasks.Add(new Task
        {
            Title = "Send weekly reports",
            ProjectName = "Project Alpha",
            DueDate = DateTime.Today.AddDays(-1),
            IsCompleted = true
        });
        
        tasks.Add(new Task
        {
            Title = "Prep Onboarding materials",
            ProjectName = "Client Onboarding",
            DueDate = DateTime.Today.AddDays(2),
            IsCompleted = true
        });
        
        return tasks;
    }
}