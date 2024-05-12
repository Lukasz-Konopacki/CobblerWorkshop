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

        public IEnumerable<RepairTask> GetAllTasks()
        {
            return _context.RepairTasks.ToList();
        }

        public RepairTask? GetTaskById(int id)
        {
            return _context.RepairTasks.SingleOrDefault(t => t.Id == id);
        }

        public IEnumerable<TaskPositionType> GetTaskPositionTypes()
        {
            return _context.TaskPositionTypes.ToList();
        }

        public bool AddTask(RepairTask task)
        {
            _context.Add<RepairTask>(task);
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

        public bool EditTask(RepairTask task)
        {
            _context.Update<RepairTask>(task);
            _context.SaveChanges();
            return true;
        }


    }
}
