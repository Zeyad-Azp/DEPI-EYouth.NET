using Application.ServiceInterfaces;
using Application.ViewModels.TaskItem;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace PL.Controllers
{
    public class TaskItemController : Controller
    {
        ITaskItemService _taskItemService;

        public TaskItemController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        public IActionResult Index()
        {
            var taskItems = _taskItemService.GetAll()
                .Select(t => new GetAllTaskItemViewModel
            {
                Id = t.Id,
                Title = t.Title
            });
            return View(taskItems);
        }

        public IActionResult GetById(int id)
        {
            var taskItem = _taskItemService.GetById(id);
            var viewModel = new GetByIdTaskItemViewModel
            {
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted,
                CreatedAt = taskItem.CreatedAt,
                DueDate = taskItem.DueDate,
                Status = taskItem.IsCompleted ? "Completed" : (taskItem.DueDate.HasValue && taskItem.DueDate.Value < DateTime.Now ? "Overdue" : "Pending"),
                StyleClass = taskItem.IsCompleted ? "text-success" : "text-danger"
            };
            return View(viewModel);
        }

        public IActionResult Add()
        {
            return View(new AddTaskItemViewModel());
        }

        [HttpPost]
        public IActionResult Add(AddTaskItemViewModel taskItemVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", taskItemVM);
            }
            _taskItemService.Add(taskItemVM);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var taskItem = _taskItemService.GetById(id);
            var viewModel = new UpdateTaskItemViewModel
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                DueDate = taskItem.DueDate,
                IsCompleted = taskItem.IsCompleted
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(UpdateTaskItemViewModel taskItemVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", taskItemVM);
            }
            _taskItemService.Update(taskItemVM);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var taskItem = _taskItemService.GetById(id);
            var viewModel = new DeleteTaskItemViewModel
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted,
                CreatedAt = taskItem.CreatedAt,
                DueDate = taskItem.DueDate,
                Status = taskItem.IsCompleted ? "Completed" : (taskItem.DueDate.HasValue && taskItem.DueDate.Value < DateTime.Now ? "Overdue" : "Pending"),
                StyleClass = taskItem.IsCompleted ? "text-success" : "text-danger"
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(DeleteTaskItemViewModel VM)
        {
            _taskItemService.Delete(VM.Id);
            return RedirectToAction("Index");
        }
        public IActionResult Filter()
        {
            var taskItems = _taskItemService.GetAll()
                .Where(t => t.IsCompleted == true)
                .Select(t => new GetByIdTaskItemViewModel
            {
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                CreatedAt = t.CreatedAt,
                DueDate = t.DueDate,
                Status = t.IsCompleted ? "Completed" : (t.DueDate.HasValue && t.DueDate.Value < DateTime.Now ? "Overdue" : "Pending"),
                StyleClass = t.IsCompleted ? "text-success" : "text-danger"
            });
            return View(taskItems);
        }
        public IActionResult Sort()
        {
            var taskItems = _taskItemService.GetAll()
                .OrderBy(t => t.DueDate)
                .Select(t => new GetByIdTaskItemViewModel
                {
                    Title = t.Title,
                    Description = t.Description,
                    IsCompleted = t.IsCompleted,
                    CreatedAt = t.CreatedAt,
                    DueDate = t.DueDate,
                    Status = t.IsCompleted ? "Completed" : (t.DueDate.HasValue && t.DueDate.Value < DateTime.Now ? "Overdue" : "Pending"),
                    StyleClass = t.IsCompleted ? "text-success" : "text-danger"
                });
            return View(taskItems);
        }
    }
}
