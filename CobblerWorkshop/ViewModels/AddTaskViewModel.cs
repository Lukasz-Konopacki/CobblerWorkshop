using CobblerWorkshop.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CobblerWorkshop.ViewModels
{
    public partial class AddTaskViewModel :ViewModelBase
    {
        [ObservableProperty]
        private List<string> _tasksTypes;
        [ObservableProperty]
        private string _selectedTaskType;
        [ObservableProperty]
        private double? _price;
        [ObservableProperty]
        private string _description;
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

        public AddTaskViewModel()
        {
            var tt1 = new TaskType(1, "Sklejenie podeszfy", 100.40);
            var tt2 = new TaskType(2, "Naprawa flekow", 30.70);
            _tasksTypes = [tt1.Name, tt2.Name];
                
            _selectedTaskType = _tasksTypes.First();
            _startDate = DateTime.Now;
            _endDate = DateTime.Now.AddDays(7);
        }
    }
}
