using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.Models
{
    /// <summary>
    /// Klasa zadania do wykonania
    /// </summary>
    public class RepairTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; private set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public bool IsPaid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Client? Client { get; set; }
        public TaskStatus Status { get; set; }
        public List<RepairTaskPosition> Positions { get; set; }

        public RepairTask() { }

        public RepairTask(double price, string? description, bool isPaid,
            DateTime startDate, DateTime endDate,
            Client client, 
            List<RepairTaskPosition> positions)
        {
            Price = price;
            Description = description;
            IsPaid = isPaid;
            StartDate = startDate;
            EndDate = endDate;
            LastUpdateDate = startDate;
            Client = client;
            Status = TaskStatus.NewTask;
            Positions = positions;
        }
    }


    /// <summary>
    /// Status zadania
    /// </summary>
    public enum TaskStatus
    {
        NewTask = 0,
        WorkFinished = 1,
        pickedUp = 2
    }
}
