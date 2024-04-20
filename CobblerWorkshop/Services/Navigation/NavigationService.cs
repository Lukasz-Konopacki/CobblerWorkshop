using CobblerWorkshop.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CobblerWorkshop.Services.Navigation
{
    public class NavigationService : ObservableObject, INavigationService
    {

            private ViewModelBase? _currentView;
            private readonly Func<Type, object?, ViewModelBase> _viewModelFactory;

            public ViewModelBase? CurrentView
            {
                get => _currentView;
                private set
                {
                    _currentView = value;
                    OnPropertyChanged();

                }
            }

            public NavigationService(Func<Type, object?, ViewModelBase> viewModelFactory)
            {
                _viewModelFactory = viewModelFactory;
            }

            public void NavigateTo<TViewModel>(object? param = null) where TViewModel : ViewModelBase
            {
                //Stworzenie nowego viewModelu na podstawie przekazanego typu
                var viewModel = _viewModelFactory(typeof(TViewModel), param);

                CurrentView = viewModel;
            }
    }
}
