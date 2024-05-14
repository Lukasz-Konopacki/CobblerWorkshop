using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.Models
{
    public class RepairTaskPosition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public int No { get; set; }
        public string? Name { get; set; }
        public int? NumberOfShoes { get; set; }
        public TaskType? TaskType { get; set; }
        public double Price { get; set; }


        public RepairTaskPosition() { }

        public RepairTaskPosition(int no,string? name, int numberOfShoes, TaskType taskType)
        {
            No = no;
            Name = name;
            NumberOfShoes = numberOfShoes;
            TaskType = taskType;
            Price = taskType.SuggestPrice;
        }
    }
}
