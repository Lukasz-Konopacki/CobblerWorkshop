using CobblerWorkshop.Services.TaskService;
using CobblerWorkshop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CobblerWorkshop.Models;
using CommunityToolkit.Mvvm.Input;
using System.Collections;
using System.Diagnostics;
using CobblerWorkshop.Views;
using CobblerWorkshop.Services.ClientService;
using System.Security.AccessControl;
using CobblerWorkshop.Services.ResourceService;

namespace CobblerWorkshop.ViewModels
{
    public partial class AddTaskTypeViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private double? _suggestPrice;
        [ObservableProperty]
        private ObservableCollection<ResourcesPosition> _resourcePositions;
        [ObservableProperty]
        private ObservableCollection<Resource> _resourceTypes;

        private readonly TaskType _taskType;

        private ITaskService _taskService;
        private INavigationService _navigationService;
        private IResourceService _resourceService;

        public AddTaskTypeViewModel(ITaskService taskService, INavigationService navigationService, IResourceService resourceService)
        {
            _taskService = taskService;
            _navigationService = navigationService;
            _resourceService = resourceService;

            SuggestPrice = 0f;
            ResourcePositions = new ObservableCollection<ResourcesPosition>();
            ResourceTypes = new ObservableCollection<Resource>(resourceService.GetResources() ?? []);
        }

        public AddTaskTypeViewModel(int taskTypeId,ITaskService taskService, INavigationService navigationService, IResourceService resourceService)
        {
            _taskService = taskService;
            _navigationService = navigationService;

            var taskType = _taskService.GetTaskTypeById(taskTypeId);
            if (taskType is not null)
            {
                _taskType = taskType;
                _name = _taskType.Name;
                _suggestPrice = _taskType.SuggestPrice;
                ResourcePositions = new ObservableCollection<ResourcesPosition>(_taskType.Positions ?? []);
                ResourceTypes = new ObservableCollection<Resource>(resourceService.GetResources() ?? []);
            }
            else
            {
                throw new ArgumentException($"Task Type with ID: {taskTypeId} doesn't exist");
            }
        }

        [RelayCommand]
        private void AddResourcePosition()
        {
            ResourcePositions.Add(new ResourcesPosition());
        }

        [RelayCommand]
        private void Save()
        {
            if (_taskType is null)
            {
                var taskType = new TaskType(Name, SuggestPrice ?? 0d);

                _taskService.AddTaskType(taskType);
            }
            else
            {
                _taskType.Name = Name;
                _taskType.SuggestPrice = SuggestPrice ?? 0d;

                _taskService.EditTaskType(_taskType);
            }

            _navigationService.NavigateTo<TaskTypeListViewModel>();
        }

        [RelayCommand]
        private void Back()
        {
            _navigationService.NavigateTo<TaskTypeListViewModel>();
        }
    }
}
