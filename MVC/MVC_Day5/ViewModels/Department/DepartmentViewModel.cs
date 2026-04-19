using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Day5.Models;

namespace MVC_Day5.ViewModels.Department
{
    public class DepartmentViewModel
    {
        public string Name { get; set; }
        public List<SelectListItem>? Students { get; set; }
        public DepartmentState? State { get; set; }
    }
}
