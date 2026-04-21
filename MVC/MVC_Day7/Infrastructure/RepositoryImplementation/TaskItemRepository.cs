using Core.Entities;
using Core.RepositoryIntefaces;
using InfraStructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImplementation
{
    
    public class TaskItemRepository : ITaskItemRepository
    {
        TaskItemDbContext _context;
        public TaskItemRepository(TaskItemDbContext context)
        {
            _context = context;
        }
        public void Add(TaskItem taskItem)
        {
            _context.Add(taskItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Remove(GetById(id));
            _context.SaveChanges();
        }

        public List<TaskItem> GetAll()
        {
            return _context.TaskItems.ToList();
        }

        public TaskItem GetById(int id)
        {
            return _context.TaskItems.Find(id);
        }

        public void Update(TaskItem taskItem)
        {
            _context.Update(taskItem);
            _context.SaveChanges();
        }
    }
}
