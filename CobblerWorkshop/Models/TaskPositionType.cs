using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.Models
{
    public class TaskPositionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Name { get; set; }
        public double SuggestPrice { get; set; }
        public TaskPositionType(string name, double suggestPrice)
        {
            Name = name;
            SuggestPrice = suggestPrice;
        }
        public TaskPositionType() {}

        public override string ToString()
        {
            return $"{Id}. {Name}";
        }
    }
}

