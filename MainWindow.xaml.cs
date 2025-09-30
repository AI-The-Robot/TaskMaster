using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TaskMaster.Data;
using TaskMaster.View.UserControls;

namespace TaskMaster;

public partial class MainWindow : Window
{
    private readonly TaskDataContext _context;

    public MainWindow()
    {
        InitializeComponent();
        _context = new TaskDataContext();

        LoadView(new DashboardView(_context));
    }

    private void LoadView(UserControl view)
    {
        MainContentArea.Content = view;
    }

    private void DashboardButton_OnClick(object sender, RoutedEventArgs e)
    {
        LoadView(new DashboardView(_context));
    }

    private void TasksButton_OnClick(object sender, RoutedEventArgs e)
    {
        LoadView(new TaskView(_context));
    }

    private void TitleBar_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            this.DragMove();
        }
    }

    private void MinimizeButton_OnClick(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void MaximizeButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (WindowState == WindowState.Maximized)
        {
            this.WindowState = WindowState.Normal;
        }
        else
        {
            this.WindowState = WindowState.Maximized;
        }
    }

    private void CloseButton_OnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}