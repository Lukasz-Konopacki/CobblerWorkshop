using CobblerWorkshop.Models;
using CobblerWorkshop.Services;
using CobblerWorkshop.Services.ClientService;
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
        private ObservableCollection<TaskType> _taskTypes;

        private readonly ITaskService _taskService;
        private readonly IClientService _clientService;
        private readonly INavigationService _navigationService;

        private readonly RepairTask? _task;

        public AddTaskViewModel(INavigationService navigationService, ITaskService taskService, IClientService clientService)
        {
            _taskService = taskService;
            _clientService = clientService;
            _navigationService = navigationService;

            _taskTypes = new ObservableCollection<TaskType>(taskService.GetTaskTypes());


            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(7);
            ListOfTaskPosition = [];
        }
        public AddTaskViewModel(int taskId,ITaskService taskService, INavigationService navigationService, IClientService clientService)
        {
            _taskService = taskService;
            _clientService = clientService;
            _navigationService = navigationService;

            _taskTypes = new ObservableCollection<TaskType>(taskService.GetTaskTypes());

            var task = taskService.GetTaskById(taskId);
            if(task is not null)
            {
                _task = task;
                Price = task.Price;
                Description = task.Description;
                StartDate = task.StartDate;
                EndDate = task.EndDate;
                ListOfTaskPosition = new ObservableCollection<RepairTaskPosition>(task?.Positions ?? []);
                if (task.Client is not null)
                {
                    ClientPhoneNumber = task.Client.PhoneNumber;
                    ClientFirstName = task.Client.FirstName;
                    ClientLastName = task.Client.LastName;
                    ClientEmail = task.Client.Email;
                }
            }
            else
            {
                throw new ArgumentException($"Task with ID: {taskId} doesn't exist");
            }   
        }

        [RelayCommand]
        private void AddTasKPosition()
        {
            ListOfTaskPosition.Add(new RepairTaskPosition(ListOfTaskPosition.Count + 1,"", 0));
            CollectionViewSource.GetDefaultView(ListOfTaskPosition).Refresh();
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

                if (_task.Client?.Id is null)
                {
                    Client client = new Client(ClientFirstName, ClientLastName, ClientPhoneNumber, ClientEmail);
                    _clientService.AddClient(client);
                    _task.Client = client;
                }
                else
                {
                    _task.Client.FirstName = ClientFirstName;
                    _task.Client.LastName = ClientLastName;
                    _task.Client.PhoneNumber = ClientPhoneNumber;
                    _task.Client.Email = ClientEmail;

                    _clientService.EditClient(_task.Client);
                }

                _task.Positions = [.. ListOfTaskPosition];
                foreach (var position in _task.Positions)
                {
                    _taskService.EditTaskPosition(position);
                }


                _taskService.EditTask(_task);
            }
            
            _navigationService.NavigateTo<TasksListViewModel>();
        }

        [RelayCommand]
        private void Back()
        {
            _navigationService.NavigateTo<TasksListViewModel>();
        }
    }
}
