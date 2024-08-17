using ASP.Net_MVC_Jqgrid.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace ASP.Net_MVC_Jqgrid.Controllers
{
	
	public class EmployeeController : Controller
	{
		string ConnectionString = "Server=DESKTOP-UAD5JOD;Database=dbTest2;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False";
		public ActionResult Index()
		{
			return View(new EmployeeModel());
		}
		public ActionResult Create()
		{ 
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(EmployeeModel employeeModel)
		{
			using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
			{
				sqlConn.Open();
				string query = "INSERT INTO Employees values(@Name ,@Position ,@Age ,@Office)";
				SqlCommand cmd = new SqlCommand(query , sqlConn);
				cmd.Parameters.AddWithValue("@Name", employeeModel.Name);
				cmd.Parameters.AddWithValue("@Position", employeeModel.Position);
				cmd.Parameters.AddWithValue("@Age", employeeModel.Age);
				cmd.Parameters.AddWithValue("@Office", employeeModel.Office);
				cmd.ExecuteNonQuery();	
			}
			return RedirectToAction("Index");
		}
		//public 
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
