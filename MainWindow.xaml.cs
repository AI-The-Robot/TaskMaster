using System.Windows;
using WPFProject.View.UserControls;

namespace WPFProject;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        DashboardView dashboardView = new DashboardView();

        MainContentArea.Content = dashboardView;
    }
}