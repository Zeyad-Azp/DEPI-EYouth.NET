using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RepositoryIntefaces
{
    public interface ITaskItemRepository
    {
        public List<TaskItem> GetAll();
        public TaskItem GetById(int id);
        public void Add(TaskItem taskItem);
        public void Update(TaskItem taskItem);
        public void Delete(int id);
    }
}
