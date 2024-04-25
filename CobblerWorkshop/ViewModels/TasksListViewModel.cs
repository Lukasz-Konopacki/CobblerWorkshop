using CobblerWorkshop.Models;
using CobblerWorkshop.Services;
using CobblerWorkshop.Services.TaskService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.ViewModels
{
    public partial class TasksListViewModel : ViewModelBase
    {
        private ITaskService _taskService;
        private INavigationService _navigationService;

        [ObservableProperty]
        private List<RepairTask> _tasks;

        public TasksListViewModel(INavigationService navigationService,ITaskService taskService)
        {
           _navigationService = navigationService;
           _taskService = taskService;

            _tasks = _taskService.GetAllTasks().ToList();
        }

        [RelayCommand]
        public void AddNewTask()
        {
            //var taskType1 = new TaskType(1, "Sklejenie podeszfy", 100.40);
            //var client1 = new Client(1, "Wojtek");

            //_taskService.AddTask(new RepairTask(
            //     101,
            //     100.20,
            //     taskType1,
            //     "dodatkowe czyszczenie w gratisie",
            //     new DateTime(2024, 04, 23),
            //     client1));

            //Tasks = _taskService.GetAllTasks().ToList();
             _navigationService.NavigateTo<AddTaskViewModel>();
        }



    }
}
