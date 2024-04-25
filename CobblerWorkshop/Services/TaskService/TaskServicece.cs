using CobblerWorkshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.Services.TaskService
{
    public class TaskServicece : ITaskService
    {
        private List<RepairTask> _tasks;

        public TaskServicece()
        {
           _tasks = new List<RepairTask>();

            var taskType1 = new TaskType(1, "Sklejenie podeszfy", 100.40);
            var taskType2 = new TaskType(2, "Naprawa flekow", 30.70);

            var client1 = new Client(1, "Wojtek");
            var client2 = new Client(1, "Maciek");

           _tasks.Add(new RepairTask(
                1,
                100.20,
                taskType1,
                "dodatkowe czyszczenie w gratisie",
                new DateTime(2024, 04, 23),
                client1));

            _tasks.Add(new RepairTask(
                2,
                50.80,
                taskType2,
                "Dodatkowo pastowanie",
                new DateTime(2024, 03, 11),
                client2));
        }

        public bool AddTask(RepairTask task)
        {
            if (_tasks.FirstOrDefault(t => t.Id == task.Id) is not null)
                return false;
            else
            {
                _tasks.Add(task);
                return true;
            }           
        }

        public bool DeleteTask(int id)
        {
            var task = _tasks.SingleOrDefault(t => t.Id == id);
            if (task is null)
                return false;
            else
            {
                _tasks.Remove(task);
                return true;
            }
        }

        public bool EditTask(RepairTask task)
        {
            var ToEdit = _tasks.SingleOrDefault(t => t.Id == task.Id);
            if (ToEdit is null)
                return false;
            else
            {
                _tasks.Remove(ToEdit);
                _tasks.Add(task);
                return true;
            }
        }

        public IEnumerable<RepairTask> GetAllTasks()
        {
            return _tasks;
        }

        public RepairTask? GetTaskById(int id)
        {
            return _tasks.SingleOrDefault(t => t.Id == id);
        }
    }
}
