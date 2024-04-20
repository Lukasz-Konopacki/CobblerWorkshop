using CobblerWorkshop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.Services
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>(object? param = null)
           where TViewModel : ViewModelBase;
    }
}
