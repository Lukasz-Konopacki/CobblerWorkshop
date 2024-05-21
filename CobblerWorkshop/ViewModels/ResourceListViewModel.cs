using CobblerWorkshop.Models;
using CobblerWorkshop.Services.ClientService;
using CobblerWorkshop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CobblerWorkshop.Services.ResourceService;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Data;

namespace CobblerWorkshop.ViewModels
{
    public partial class ResourceListViewModel : ViewModelBase
    {
        private readonly IResourceService _resourceService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private ObservableCollection<Resource> _resources;

        public ResourceListViewModel(INavigationService navigationService, IResourceService resourceService)
        {
            _navigationService = navigationService;
            _resourceService = resourceService;

            _resources = new ObservableCollection<Resource>(resourceService.GetResources());
        }

        [RelayCommand]
        public void AddResource()
        {
            Resources.Add(new Resource("", ""));
        }

        [RelayCommand]
        private void DeleteResource(int id)
        {
            Resources.Remove(Resources.FirstOrDefault(r => r.Id == id));
            CollectionViewSource.GetDefaultView(Resources).Refresh();
        }

        [RelayCommand]
        private void Save()
        {
            _resourceService.SaveChanges(Resources.ToList());
            _navigationService.NavigateTo<ResourceListViewModel>();
        }

        [RelayCommand]
        private void Back()
        {
            _navigationService.NavigateTo<ResourceListViewModel>();
        }
    }
}
