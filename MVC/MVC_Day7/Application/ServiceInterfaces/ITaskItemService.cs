using Application.ViewModels.TaskItem;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces
{
    public interface ITaskItemService
    {
        public List<TaskItem> GetAll();
        public TaskItem GetById(int id);
        public void Add(AddTaskItemViewModel taskItem);
        public void Update(UpdateTaskItemViewModel taskItem);
        public void Delete(int id);
    }
}
