using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.Models
{
    public class TaskType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double SuggestPrice { get; set; }

        public TaskType(int id, string name, double suggestPrice)
        {
            Id = id;
            Name = name;
            SuggestPrice = suggestPrice;
        }

    }
}
