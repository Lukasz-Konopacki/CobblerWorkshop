using CobblerWorkshop.DbProviders;
using CobblerWorkshop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.Services.TaskService
{
    public class TaskServiceDb : ITaskService
    {
        private readonly SqliteDbContext _context;

        public TaskServiceDb(SqliteDbContext databaseContext)
        {
            _context = databaseContext;
        }

        /// <summary>
        /// Task
        /// </summary>
        /// <returns></returns>

        public IEnumerable<RepairTask> GetAllTasks()
        {
            return _context.RepairTasks.Include(t => t.Client).ToList();
        }

        public RepairTask? GetTaskById(int id)
        {
            return _context.RepairTasks
                .Include(t => t.Client)
                .Include(t => t.Positions)
                .SingleOrDefault(t => t.Id == id);
        }

        public bool AddTask(RepairTask task)
        {
            _context.Add<RepairTask>(task);
            _context.SaveChanges();

            return true;
        }
        public bool EditTask(RepairTask task)
        {
            _context.Update<RepairTask>(task);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteTask(int id)
        {
            var task = _context.RepairTasks.Include(t => t.Positions).FirstOrDefault(t => t.Id == id);
            
            if (task == null)
                return false;

            foreach (var position in task.Positions.ToList())
            {
                _context.RepairTaskPositions.Remove(position);
            }

            // Usuń zadanie
            _context.RepairTasks.Remove(task);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// RepairTaskPosition
        /// </summary>
        /// <param name="taskPosition"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public bool EditTaskPosition(RepairTaskPosition taskPosition)
        {
            _context.RepairTaskPositions.Update(taskPosition);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteTaskPosition(RepairTaskPosition taskPosition)
        {
            _context.RepairTaskPositions.Remove(taskPosition);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Task Types
        /// </summary>
        /// <returns></returns>

        public IEnumerable<TaskType> GetTaskTypes()
        {
            return _context.TaskTypes.ToList();
        }

        public TaskType? GetTaskTypeById(int id)
        {
            return _context.TaskTypes.FirstOrDefault(t => t.Id == id);
        }

        public bool AddTaskType(TaskType taskType)
        {
            _context.TaskTypes.Add(taskType);
            _context.SaveChanges();
            return true;
        }

        public bool EditTaskType(TaskType taskType)
        {
            _context.TaskTypes.Update(taskType);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteTaskType(int id)
        {
            var taskType = _context.TaskTypes.FirstOrDefault(t => t.Id == id);
            var tasksWithType = _context.RepairTaskPositions.Where(t => t.TaskType != null && t.TaskType.Id == id);

            if (taskType == null)
                return false;

            foreach (var position in tasksWithType.ToList())
            {
                position.TaskType = null;
                _context.RepairTaskPositions.Update(position);
            }

            // Usuń zadanie
            _context.TaskTypes.Remove(taskType);
            _context.SaveChanges();
            return true;
        }
    }
}
