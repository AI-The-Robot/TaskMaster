using System.ComponentModel.DataAnnotations;

namespace WPFProject.Data;

public class Task
{
    [Key]
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string ProjectName { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public bool IsCompleted { get; set; }
}