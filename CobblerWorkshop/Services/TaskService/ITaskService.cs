using CobblerWorkshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CobblerWorkshop.Services.TaskService
{
    public interface ITaskService
    {
        public IEnumerable<RepairTask> GetAllTasks();
        public RepairTask? GetTaskById(int id);
        public bool AddTask(RepairTask task);
        public bool EditTask(RepairTask task);
        public bool DeleteTask(int id);
        public IEnumerable<TaskPositionType> GetTaskPositionTypes();
    }
}
