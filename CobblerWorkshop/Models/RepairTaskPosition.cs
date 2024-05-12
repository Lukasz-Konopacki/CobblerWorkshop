using System;
using System.Collections.Generic;
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
        public TaskPositionType? TaskPositionType { get; set; }

        public RepairTaskPosition() { }

        public RepairTaskPosition(int no,string? name, int numberOfShoes, TaskPositionType taskPositionType)
        {
            No = no;
            Name = name;
            NumberOfShoes = numberOfShoes;
            TaskPositionType = taskPositionType;
        }
    }
}
