using Application.ServiceInterfaces;
using Application.ViewModels.TaskItem;
using Core.Entities;
using Core.RepositoryIntefaces;
using InfraStructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceImplementation
{
    public class TaskItemService : ITaskItemService
    {
        ITaskItemRepository _taskItemRepository;
        TaskItemDbContext _context;
        public TaskItemService(ITaskItemRepository taskItemRepository , TaskItemDbContext context)
        {
            _taskItemRepository = taskItemRepository;
            _context = context;
        }
        void ITaskItemService.Add(AddTaskItemViewModel taskItemVM)
        {
            var taskItem = new TaskItem
            {
                Title = taskItemVM.Title,
                Description = taskItemVM.Description,
                DueDate = taskItemVM.DueDate,
                CreatedAt = DateTime.Now,
                IsCompleted = taskItemVM.IsCompleted
            };
            _taskItemRepository.Add(taskItem);
            _context.SaveChanges();
        }

        void ITaskItemService.Delete(int id)
        {
            _taskItemRepository.Delete(id);
            _context.SaveChanges();
        }

        List<TaskItem> ITaskItemService.GetAll()
        {
            return _taskItemRepository.GetAll();
        }

        TaskItem ITaskItemService.GetById(int id)
        {
            return _taskItemRepository.GetById(id);
        }

        void ITaskItemService.Update(UpdateTaskItemViewModel taskItem)
        {
            var existingTaskItem = _taskItemRepository.GetById(taskItem.Id);
            existingTaskItem.Title = taskItem.Title;
            existingTaskItem.Description = taskItem.Description;
            existingTaskItem.DueDate = taskItem.DueDate;
            existingTaskItem.IsCompleted = taskItem.IsCompleted;
            _taskItemRepository.Update(existingTaskItem);
            _context.SaveChanges();
        }
    }
}
