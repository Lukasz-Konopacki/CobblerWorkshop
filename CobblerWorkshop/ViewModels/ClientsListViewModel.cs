using CobblerWorkshop.Models;
using CobblerWorkshop.Services.TaskService;
using CobblerWorkshop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using CobblerWorkshop.Services.ClientService;

namespace CobblerWorkshop.ViewModels
{
    public partial class ClientsListViewModel : ViewModelBase
    {
        private readonly IClientService _clientService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private ObservableCollection<Client> _clients;

        public ClientsListViewModel(INavigationService navigationService, IClientService clientService)
        {
            _navigationService = navigationService;
            _clientService = clientService;

            _clients = new ObservableCollection<Client>(_clientService.GetAllClients());
        }

        [RelayCommand]
        public void AddClient()
        {
            _navigationService.NavigateTo<AddClientViewModel>();
        }

        [RelayCommand]
        public void ShowDetails(int id)
        {
            _navigationService.NavigateTo<AddClientViewModel>(id);
        }

        [RelayCommand]
        public void Delete(int id)
        {
            Client client = _clientService.GetClientById(id);

            if(client is not null)
            {
                _clientService.DeleteClient(client);
                Clients.Remove(client);
                CollectionViewSource.GetDefaultView(Clients).Refresh();
            }
        }
    }
}
