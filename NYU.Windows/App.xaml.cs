using NYU.Domain;
using NYU.Infrastructure.Data;
using NYU.Infrastructure.Data.Repositories;
using NYU.Windows.Factories;
using NYU.Windows.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows; 

namespace NYU.Windows;

public partial class App : Application
{
    public static User CurrentUser { get; set; } = default!;

    public IServiceProvider ServiceProvider { get; init; } 
    public IConfiguration Configuration { get; init; }

    public App()
    {
        var builder = new ConfigurationBuilder();

        Configuration = builder.Build();

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddDbContext<NYUDbContext>(ServiceLifetime.Scoped);

        serviceCollection.AddSingleton<IRepository<Bug>, 
            BugRepository>();

        serviceCollection.AddSingleton<IRepository<Feature>, 
            FeatureRepository>();

        serviceCollection.AddSingleton<IRepository<TodoTask>,
            TodoTaskRepository>();

        serviceCollection.AddSingleton<IRepository<User>,
            UserRepository>();

        serviceCollection.AddTransient<TodoViewModelFactory>();
        serviceCollection.AddTransient<FeatureViewModel>();
        serviceCollection.AddTransient<BugViewModel>();
        serviceCollection.AddTransient<MainViewModel>();
        serviceCollection.AddTransient<MainWindow>();
        serviceCollection.AddTransient(_ => ServiceProvider!);
        
        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    private async void OnStartup(object sender, StartupEventArgs e)
    {
        try
        {
            var context = ServiceProvider.GetRequiredService<NYUDbContext>();

            await context.Database.MigrateAsync();

            var user = context.Users.FirstOrDefault();

            if (user is null)
            {
                user = new Infrastructure.Data.Models.User { Name = "Filip" };
                context.Users.Add(user);
                context.SaveChanges();
            }

            App.CurrentUser = DataToDomainMapping.MapUser(user);
        }
        catch (Exception ex)
        {  
            // TODO: Add Logging
        }

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();

        mainWindow?.Show();
    }
}
