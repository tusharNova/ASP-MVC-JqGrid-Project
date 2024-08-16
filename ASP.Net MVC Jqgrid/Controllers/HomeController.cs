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
