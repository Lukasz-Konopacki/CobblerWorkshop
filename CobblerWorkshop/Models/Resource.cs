using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.Models
{
    public class Resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }

        public Resource(string name, string unit)
        {
            Name = name;
            Unit = unit;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
