using CobblerWorkshop.Models;
using CobblerWorkshop.Services;
using CobblerWorkshop.Services.TaskService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CobblerWorkshop.ViewModels
{
    public partial class TaskTypeListViewModel :ViewModelBase
    {
        private readonly ITaskService _taskService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private ObservableCollection<TaskType> _taskTypes;

        public TaskTypeListViewModel(INavigationService navigationService, ITaskService taskService)
        {
            _navigationService = navigationService;
            _taskService = taskService;

            _taskTypes = new ObservableCollection<TaskType>(_taskService.GetTaskTypes().ToList());
        }

        [RelayCommand]
        public void AddNewTaskType()
        {
            _navigationService.NavigateTo<AddTaskTypeViewModel>();
        }

        [RelayCommand]
        public void ShowDetails(int id)
        {
            _navigationService.NavigateTo<AddTaskTypeViewModel>(id);
        }

        [RelayCommand]
        public void DeleteTask(int id)
        {
            _taskService.DeleteTaskType(id);

            TaskTypes.Remove(TaskTypes.First(t => t.Id == id));

            CollectionViewSource.GetDefaultView(TaskTypes).Refresh();
        }
    }
}
