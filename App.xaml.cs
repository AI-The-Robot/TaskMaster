using System.Windows;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WPFProject.Data;

namespace WPFProject;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        DatabaseFacade facade = new DatabaseFacade(new TaskDataContext());
        facade.EnsureCreated();
    }
}