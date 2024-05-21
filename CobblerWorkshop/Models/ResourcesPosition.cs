using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.Models
{
    public class ResourcesPosition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [ForeignKey(nameof(Id))]
        public TaskType TaskType { get; set; }

        [ForeignKey(nameof(Id))]
        public Resource Resource { get; set; }

        public int Quantity { get; set; }
    }
}
