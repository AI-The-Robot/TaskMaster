using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WPFProject.Data;
using Task = System.Threading.Tasks.Task;
using System.Linq;
using System.Collections.ObjectModel;

namespace WPFProject.View.UserControls;

public partial class DashboardView : UserControl
{
    public ObservableCollection<Data.Task> AllTasks { get; set; }
    public DashboardView()
    {
        InitializeComponent();

        this.Loaded += DashboardView_Loaded;
    }

    private void DashboardView_Loaded(object sender, RoutedEventArgs e)
    {
        AllTasks = DataManager.GetTasks();
        
        var upcoming = new ObservableCollection<Data.Task>(AllTasks.Where(t => t.DueDate >= DateTime.Today && !t.IsCompleted));
        
        var overdue = new ObservableCollection<Data.Task>(AllTasks.Where(t => t.DueDate < DateTime.Today && !t.IsCompleted));

        UpcomingTaskListView.ItemsSource = upcoming;
        OverdueTaskListView.ItemsSource = overdue;
    }
}