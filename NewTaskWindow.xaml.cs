using System.Windows;
using TaskMaster.Data;
using Task = System.Threading.Tasks.Task;

namespace TaskMaster;

public partial class NewTaskWindow : Window
{
    private readonly TaskDataContext _context;
    
    public NewTaskWindow(TaskDataContext context)
    {
        InitializeComponent();
        _context = context;
    }

    private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        string title = TitleTextBox.Text;
        string project = ProjectTextBox.Text;
        DateTime? dueDate = DueDatePicker.SelectedDate;

        if (string.IsNullOrEmpty(title) || dueDate == null)
        {
            MessageBox.Show("Title and Due Date cannot be empty.", "Validation Error", MessageBoxButton.OK,
                MessageBoxImage.Error);
            return;
        }

        var newTask = new Data.Task()
        {
            Title = title,
            ProjectName = project,
            DueDate = dueDate.Value,
            IsCompleted = false
        };
        
        _context.Tasks.Add(newTask);

        try
        {
            await _context.SaveChangesAsync();
            
            MessageBox.Show("Task Saved Successfully", "Success", MessageBoxButton.OK, 
                MessageBoxImage.Information);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, $"Error while saving task:", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}