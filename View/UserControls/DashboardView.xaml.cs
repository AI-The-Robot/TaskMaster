using System.Collections.ObjectModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using TaskMaster.Data;
using Task = System.Threading.Tasks.Task;

namespace TaskMaster.View.UserControls;

public partial class DashboardView : UserControl
{
    private readonly TaskDataContext _context;
    public DashboardView(TaskDataContext context)
    {
        InitializeComponent();
        _context = context;

        this.Loaded += (s,e) => RefreshAllData();
    }

    private void NewTaskButton_OnClick(object sender, RoutedEventArgs e)
    {
        var newTaskWindow = new NewTaskWindow(_context);

        newTaskWindow.ShowDialog();

        RefreshAllData();
    }

    public void RefreshAllData()
    {
        _context.Tasks.Load();

        UpdateOverviewMetrics();
        
        RefreshTaskLists();
    }

    private void UpdateOverviewMetrics()
    {
        int tasksDueTodayCount = _context.Tasks.Local.Count(t => t.DueDate.Date == System.DateTime.Today.Date && !t.IsCompleted);
        
        int overdueTasksCount = _context.Tasks.Local.Count(t => t.DueDate.Date < System.DateTime.Today.Date && !t.IsCompleted);
        
        int completedTodayCount = _context.Tasks.Local.Count(t => t.DueDate.Date >= System.DateTime.Today.Date && t.IsCompleted ||
                                                                  t.DueDate.Date <= System.DateTime.Today.Date && t.IsCompleted);
        
        int upcomingTasksCount = _context.Tasks.Local.Count(t => t.DueDate.Date > System.DateTime.Today.Date && !t.IsCompleted);

        TasksDueTodayTextBlock.Text = tasksDueTodayCount.ToString();
        OverdueTasksTextBlock.Text = overdueTasksCount.ToString();
        CompletedTodayTextBlock.Text = completedTodayCount.ToString();
        UpcomingTasksTextBlock.Text = upcomingTasksCount.ToString();
    }

    private void RefreshTaskLists()
    {
        var upcoming = new ObservableCollection<Data.Task>(_context.Tasks.Local.Where(t => t.DueDate >= DateTime.Today && !t.IsCompleted));
        var overdue = new ObservableCollection<Data.Task>(_context.Tasks.Local.Where(t => t.DueDate < DateTime.Today && !t.IsCompleted));

        UpcomingTaskListView.ItemsSource = upcoming;
        OverdueTaskListView.ItemsSource = overdue;
    }

    private async void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
    {
        var checkBox = sender as CheckBox;
        
        var task = checkBox.DataContext as Data.Task;

        if (task != null)
        { 
            task.IsCompleted = true;
            
            try
            {
                await _context.SaveChangesAsync();
                
                RefreshAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update task status: {ex.Message}", "Database Error");

                task.IsCompleted = false;
            }
        }
    }

    private async void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
    {
        var checkBox = sender as CheckBox;
        var task = checkBox.DataContext as Data.Task;

        if (task != null)
        {
            task.IsCompleted = false;

            try
            {
                await _context.SaveChangesAsync();
                RefreshAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update task status: {ex.Message}", "Database Error");
                task.IsCompleted = true;
            }
        }
    }
}