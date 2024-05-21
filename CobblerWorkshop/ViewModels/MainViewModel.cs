using CobblerWorkshop.Services;
using CobblerWorkshop.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        [ObservableProperty]
        private INavigationService _navigation;

        public MainViewModel(INavigationService navigationService)
        {
            _navigation = navigationService;
            _navigation.NavigateTo<TasksListViewModel>();
        }

        [RelayCommand]
        public void NavigateToTasksList()
        {
            Navigation.NavigateTo<TasksListViewModel>();
        }

        [RelayCommand]
        public void NavigateToClientList()
        {
            Navigation.NavigateTo<ClientsListViewModel>();
        }

        [RelayCommand]
        public void NavigateToTaskTypesList()
        {
            Navigation.NavigateTo<TaskTypeListViewModel>();
        }

        [RelayCommand]
        public void NavigateToResourceList()
        {
            Navigation.NavigateTo<ResourceListViewModel>();
        }
    }
}

