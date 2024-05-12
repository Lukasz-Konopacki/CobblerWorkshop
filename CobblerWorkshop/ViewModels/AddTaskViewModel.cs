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
using System.Xml.Linq;

namespace CobblerWorkshop.ViewModels
{
    public partial class AddTaskViewModel :ViewModelBase
    {
        //Task specific info
        [ObservableProperty]
        private double? _price;
        [ObservableProperty]
        private string? _description;
        [ObservableProperty]
        private DateTime _startDate;
        [ObservableProperty]
        private DateTime _endDate;
        [ObservableProperty]
        private string? _clientPhoneNumber;

        /// Client extra data when number was not found
        [ObservableProperty]
        private string? _clientFirstName;
        [ObservableProperty]
        private string? _clientLastName;
        [ObservableProperty]
        private string? _clientEmail;

        /// Shoes in Task
        [ObservableProperty]
        private ObservableCollection<RepairTaskPosition> _listOfTaskPosition;
        [ObservableProperty]
        private ObservableCollection<string> _tasksPostionTypes;

        private readonly ITaskService _taskService;
        private readonly INavigationService _navigationService;

        private readonly RepairTask? _task;

        public AddTaskViewModel(ITaskService taskService, INavigationService navigationService)
        {
            _taskService = taskService;
            _navigationService = navigationService;

            _tasksPostionTypes = new ObservableCollection<string>(taskService.GetTaskPositionTypes().Select(t => t.Name));


            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(7);
            ListOfTaskPosition = [];
        }
        public AddTaskViewModel(int taskId,ITaskService taskService, INavigationService navigationService)
        {
            _taskService = taskService;
            _navigationService = navigationService;

            _tasksPostionTypes = new ObservableCollection<string>(taskService.GetTaskPositionTypes().Select(t => t.Name));

            var task = taskService.GetTaskById(taskId);
            if(task is not null)
            {
                _task = task;
                Price = task.Price;
                Description = task.Description;
                StartDate = task.StartDate;
                EndDate = task.EndDate;
                if (task.Client is not null)
                {
                    ClientPhoneNumber = task.Client.PhoneNumber;
                    ClientFirstName = task.Client.FirstName;
                    ClientLastName = task.Client.LastName;
                    ClientEmail = task.Client.Email;
                    ListOfTaskPosition = new ObservableCollection<RepairTaskPosition>(task.Positions) ?? [];
                }
            }
            else
            {
                throw new ArgumentException($"Task with ID: {task.Id} doesn't exist");
            }   
        }

        [RelayCommand]
        private void AddTasKPosition()
        {
            ListOfTaskPosition.Add(new RepairTaskPosition(ListOfTaskPosition.Count + 1,"", 0, new TaskPositionType("Naprawa flekow", 30.70)));
        }

        [RelayCommand]
        private void Back()
        {
            _navigationService.NavigateTo<TasksListViewModel>();
        }

        [RelayCommand]
        private void DeleteTaskPosition(int no)
        {
            var position = ListOfTaskPosition.FirstOrDefault(p => p.No == no);
            ListOfTaskPosition.Remove(position);

            for (int i = 0; i < ListOfTaskPosition.Count; i++) 
            {
                ListOfTaskPosition[i].No = i + 1;
            }

            CollectionViewSource.GetDefaultView(ListOfTaskPosition).Refresh();
        }

        [RelayCommand]
        private void Save()
        {
            if(_task is null)
            {
                var task = new RepairTask(Price ?? 0f, Description, DateTime.Now, EndDate,
                new Client(ClientFirstName, ClientLastName, ClientPhoneNumber, ClientEmail),
                [.. ListOfTaskPosition]);


                _taskService.AddTask(task);
            }
            else
            {
                _task.Price = Price ?? 0f;
                _task.Description = Description;
                _task.LastUpdateDate = DateTime.Now;
                _task.EndDate = EndDate;
                _task.StartDate = StartDate;
                _task.Positions = [.. ListOfTaskPosition];

                if(_task.Client is not null)
                {
                    _task.Client.FirstName = ClientFirstName;
                    _task.Client.LastName = ClientLastName;
                    _task.Client.PhoneNumber = ClientPhoneNumber;
                    _task.Client.Email = ClientEmail;
                }


                _taskService.EditTask(_task);
            }
            
            _navigationService.NavigateTo<TasksListViewModel>();
        }

    }
}
