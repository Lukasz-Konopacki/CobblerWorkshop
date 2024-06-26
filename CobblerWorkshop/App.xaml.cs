﻿using CobblerWorkshop.DbProviders;
using CobblerWorkshop.Services;
using CobblerWorkshop.Services.ClientService;
using CobblerWorkshop.Services.Navigation;
using CobblerWorkshop.Services.ResourceService;
using CobblerWorkshop.Services.TaskService;
using CobblerWorkshop.ViewModels;
using CobblerWorkshop.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CobblerWorkshop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            //
            services.AddSingleton(provaider => new MainWindow { DataContext = provaider.GetRequiredService<MainViewModel>() });

            //ViewModele
            services.AddSingleton<MainViewModel>();

            services.AddTransient<TasksListViewModel>();
            services.AddTransient<AddTaskViewModel>();

            services.AddTransient<TaskTypeListViewModel>();
            services.AddTransient<AddTaskTypeViewModel>();

            services.AddTransient<ClientsListViewModel>();
            services.AddTransient<AddClientViewModel>();

            services.AddTransient<ResourceListViewModel>();

            services.AddSingleton<Func<Type, object?, ViewModelBase>>(provaider => (viewModelType, param) =>
            {
                return param == null ? (ViewModelBase)provaider.GetRequiredService(viewModelType) : (ViewModelBase)ActivatorUtilities.CreateInstance(provaider, viewModelType, param);
            });

            //Serwisy
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ITaskService, TaskServiceDb>();
            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<IResourceService, ResourceService>();
            services.AddDbContext<SqliteDbContext>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainwindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainwindow.Show();
            base.OnStartup(e); ;
        }
    }
}