using CobblerWorkshop.Models;
using CobblerWorkshop.Services.TaskService;
using CobblerWorkshop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CobblerWorkshop.Services.ClientService;
using System.Collections.ObjectModel;
using System.Collections;
using System.Diagnostics;

namespace CobblerWorkshop.ViewModels
{
    public partial class AddClientViewModel :ViewModelBase
    {
        [ObservableProperty]
        private string? _firstName;
        [ObservableProperty]
        private string? _lastName;
        [ObservableProperty]
        private string? _email;
        [ObservableProperty]
        private string? _phoneNumber;

        private readonly Client _client;

        private IClientService _clientService;
        private INavigationService _navigationService;

        public AddClientViewModel(IClientService clientService, INavigationService navigationService)
        {
            _clientService = clientService;
            _navigationService = navigationService;

        }

        public AddClientViewModel(int clientId, IClientService clientService, INavigationService navigationService)
        {
            _clientService = clientService;
            _navigationService = navigationService;

            var client = _clientService.GetClientById(clientId);
            if (client is not null)
            {
                _client = client;
                _firstName = _client.FirstName;
                _lastName = _client.LastName;
                _email = _client.Email;
                _phoneNumber = _client.PhoneNumber;
            }
            else
            {
                throw new ArgumentException($"Client with ID: {clientId} doesn't exist");
            }
        }

        [RelayCommand]
        private void Save()
        {
            if (_client is null)
            {
                var client = new Client(FirstName, LastName, PhoneNumber, Email);

                _clientService.AddClient(client);
            }
            else
            {
                _client.FirstName = FirstName;
                _client.LastName = LastName;
                _client.PhoneNumber = PhoneNumber;
                _client.Email = Email;

                _clientService.EditClient(_client);
            }

            _navigationService.NavigateTo<ClientsListViewModel>();
        }

        [RelayCommand]
        private void Back()
        {
            _navigationService.NavigateTo<TaskTypeListViewModel>();
        }
    }
}
