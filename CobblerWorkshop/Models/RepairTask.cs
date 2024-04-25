using System;
using System.Collections.Generic;
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
        public int Id { get; private set; }
        public double Price { get; set; }
        TaskType TaskType { get; set; }
        string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        DateTime LastUpdateDate { get; set; } // Wyliczalne lub przez odpalanie funkcji
        Client Client { get; set; }
        public TaskStatus Status { get; set; }

        public RepairTask(int id, double price, TaskType taskType, string? description, DateTime startDate, Client client)
        {
            Id = id;
            Price = price;
            TaskType = taskType;
            Description = description;
            StartDate = startDate;
            LastUpdateDate = startDate;
            Client = client;
            Status = TaskStatus.NewTask;
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
