using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CobblerWorkshop.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        public Dictionary<string, object> Params { get; set; }

        public ViewModelBase()
        {
            Params = new Dictionary<string, object>();
        }
    }
}
