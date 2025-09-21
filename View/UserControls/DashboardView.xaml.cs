using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WPFProject.Data;
using Task = System.Threading.Tasks.Task;
using System.Linq;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace WPFProject.View.UserControls;

public partial class DashboardView : UserControl
{
    private readonly TaskDataContext _context;
    public DashboardView()
    {
        InitializeComponent();
        _context = new TaskDataContext();

        this.Loaded += DashboardView_Loaded;
    }

    private void DashboardView_Loaded(object sender, RoutedEventArgs e)
    {
        _context.Tasks.Load();
        
        var upcoming = new ObservableCollection<Data.Task>(_context.Tasks.Local.Where(t => t.DueDate >= DateTime.Today && !t.IsCompleted));
        
        var overdue = new ObservableCollection<Data.Task>(_context.Tasks.Local.Where(t => t.DueDate < DateTime.Today && !t.IsCompleted));

        UpcomingTaskListView.ItemsSource = upcoming;
        OverdueTaskListView.ItemsSource = overdue;
    }

    private void NewTaskButton_OnClick(object sender, RoutedEventArgs e)
    {
        var newTaskWindow = new NewTaskWindow(_context);
        
        newTaskWindow.ShowDialog();
        
        RefreshTaskLists();
    }

    private void RefreshTaskLists()
    {
        _context.Tasks.Load();
        
        var upcoming = new ObservableCollection<Data.Task>(_context.Tasks.Local.Where(t => t.DueDate >= DateTime.Today && !t.IsCompleted));
        
        var overdue = new ObservableCollection<Data.Task>(_context.Tasks.Local.Where(t => t.DueDate < DateTime.Today && !t.IsCompleted));

        UpcomingTaskListView.ItemsSource = upcoming;
        OverdueTaskListView.ItemsSource = overdue;
    }
}