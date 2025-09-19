namespace WPFProject.Data;

public class Task
{
    public string Title { get; set; }
    
    public string ProjectName { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public bool IsCompleted { get; set; }
}