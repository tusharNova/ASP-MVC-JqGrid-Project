using ASP.Net_MVC_Jqgrid.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_MVC_Jqgrid.Controllers
{
	public class EmployeeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public JsonResult GetEmployees()
		{
			var employees = new List<EmployeeModel>
			{
				new EmployeeModel { Id = 1, Name = "John Doe", Position = "Developer", Age = 30, Office = "New York" },
				new EmployeeModel { Id = 2, Name = "Jane Doe", Position = "Designer", Age = 25, Office = "London" },
				new EmployeeModel { Id = 3, Name = "Michael Smith", Position = "Manager", Age = 35, Office = "Sydney" },
				new EmployeeModel { Id = 4, Name = "Maria Garcia", Position = "HR", Age = 28, Office = "Madrid" },
			};

			return Json(employees);
		}
	}
}
