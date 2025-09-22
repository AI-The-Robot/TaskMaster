using System.Windows;
using System.Windows.Controls;
using WPFProject.Data;
using WPFProject.View.UserControls;

namespace WPFProject;

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
}