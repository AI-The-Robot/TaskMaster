using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using TaskMaster.Data;

namespace TaskMaster.View.UserControls;

public partial class TaskView : UserControl
{
    private readonly TaskDataContext _context;
    
    public TaskView(TaskDataContext context)
    {
        InitializeComponent();
        
        _context = context;

        this.Loaded += async (sender, e) =>
        {
            await _context.Tasks.LoadAsync();
            TaskDataGrid.ItemsSource = _context.Tasks.Local.ToObservableCollection();
        };
    }
}