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

        public bool EditTaskPosition(RepairTaskPosition taskPosition);
        public bool DeleteTaskPosition(RepairTaskPosition taskPosition);

        public IEnumerable<TaskType> GetTaskTypes();
        public TaskType? GetTaskTypeById(int id);
        public bool AddTaskType(TaskType taskType);
        public bool EditTaskType(TaskType taskType);
        public bool DeleteTaskType(int Id);
    }
}
