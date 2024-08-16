using ASP.Net_MVC_Jqgrid.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.Net_MVC_Jqgrid.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}
		private static readonly List<Person> _people = new List<Person>
		{
			new Person { Id = 1, Name = "John Doe", Age = 30, Gender = "Male" },
			new Person { Id = 2, Name = "Jane Doe", Age = 25, Gender = "Female" },
            // Add more sample data here
        };



		public JsonResult GetData()
		{
			// jqGrid expects specific parameters for paging
			int page = int.Parse(Request.Query["page"]);
			int rows = int.Parse(Request.Query["rows"]);
			string sidx = Request.Query["sidx"]; // Sort column
			string sord = Request.Query["sord"]; // Sort order

			var sortedData = _people.OrderBy(p => p.Id); // Add sorting logic based on sidx and sord

			var pagedData = sortedData.Skip((page - 1) * rows).Take(rows).ToList();
			var totalRecords = _people.Count;

			var jsonData = new
			{
				total = (totalRecords + rows - 1) / rows, // Total number of pages
				page,
				records = totalRecords,
				rows = pagedData
			};

			return Json(jsonData);
		}

		public JsonResult GetEmployees()
		{
			var emplist = new List<EmployeeModel>
			{
				 new EmployeeModel { Id = 1, Name = "John Doe", Position = "Developer", Age = 30, Office = "New York" },
			new EmployeeModel { Id = 2, Name = "Jane Doe", Position = "Designer", Age = 25, Office = "London" },
			new EmployeeModel { Id = 3, Name = "Michael Smith", Position = "Manager", Age = 35, Office = "Sydney" },
			new EmployeeModel { Id = 4, Name = "Maria Garcia", Position = "HR", Age = 28, Office = "Madrid" },

			};
			return Json(emplist);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}

	public class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public string Gender { get; set; }
	}


	}
