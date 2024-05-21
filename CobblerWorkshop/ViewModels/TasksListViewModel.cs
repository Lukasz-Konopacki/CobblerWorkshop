using CobblerWorkshop.Models;
using CobblerWorkshop.Services;
using CobblerWorkshop.Services.TaskService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace CobblerWorkshop.ViewModels
{
    public partial class TasksListViewModel : ViewModelBase
    {
        private readonly ITaskService _taskService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private ObservableCollection<RepairTask> _tasks;
        [ObservableProperty]
        private ObservableCollection<RepairTaskStatus> _statusTypes;

        public TasksListViewModel(INavigationService navigationService,ITaskService taskService)
        {
           _navigationService = navigationService;
           _taskService = taskService;

            _statusTypes = new ObservableCollection<RepairTaskStatus>();
            foreach (RepairTaskStatus status in Enum.GetValues(typeof(RepairTaskStatus)))
            {
                _statusTypes.Add(status);
            }

            Tasks = new ObservableCollection<RepairTask>(_taskService.GetAllTasks().ToList());
        }


        [RelayCommand]
        public void AddNewTask()
        {
             _navigationService.NavigateTo<AddTaskViewModel>();
        }

        [RelayCommand]
        public void ShowDetails(int TaskId)
        {
            _navigationService.NavigateTo<AddTaskViewModel>(TaskId);
        }

        [RelayCommand]
        public void DeleteTask(int TaskId)
        {
            _taskService.DeleteTask(TaskId);
            Tasks.Remove(Tasks.First(t => t.Id == TaskId));

            CollectionViewSource.GetDefaultView(Tasks).Refresh();
        }

        [RelayCommand]
        public void EditStatus(int TaskId)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == TaskId);
            _taskService.EditTask(task);
        }

    }
}
