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
			var employees = new List<EmployeeModel>();

			// Generate 50 demo employees
			for (int i = 1; i <= 50; i++)
			{
				employees.Add(new EmployeeModel
				{
					Id = i,
					Name = $"Employee {i}",
					Position = GetRandomPosition(),
					Age = new Random().Next(20, 60),
					Office = GetRandomOffice()
				});
			}

			return Json(employees);
		}
		private string GetRandomPosition()
		{
			var positions = new[] { "Developer", "Designer", "Manager", "HR", "QA", "Support" };
			return positions[new Random().Next(positions.Length)];
		}

		private string GetRandomOffice()
		{
			var offices = new[] { "New York", "London", "Sydney", "Madrid", "Berlin", "Tokyo" };
			return offices[new Random().Next(offices.Length)];
		}
	}
}
