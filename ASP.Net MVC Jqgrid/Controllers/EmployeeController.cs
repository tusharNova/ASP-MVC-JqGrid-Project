using ASP.Net_MVC_Jqgrid.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;


namespace ASP.Net_MVC_Jqgrid.Controllers
{
	
	public class EmployeeController : Controller
	{
		string ConnectionString = "Server=DESKTOP-UAD5JOD;Database=dbTest2;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False";
		public ActionResult Index()
		{
			return View();
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

		
		public JsonResult GetEmployees()
		{
			
			DataTable dt = new DataTable();
			SqlConnection sqlconnection = new SqlConnection();
			sqlconnection.ConnectionString = ConnectionString;
			sqlconnection.Open();
			SqlCommand cmd = new SqlCommand();
			cmd = sqlconnection.CreateCommand();
			SqlDataReader res;
			cmd.CommandText = "select * from Employees;";
			res = cmd.ExecuteReader();
			dt.Load(res);
			sqlconnection.Close();
			//using (SqlConnection sqlConn = new SqlConnection(ConnectionString)) 
			//{
			//	sqlConn.Open();
			//	string query = "Select * from Employees";
			//	SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlConn);
			//	sqlDa.Fill(dt);
			//}
			List<EmployeeModel> employeeList = new List<EmployeeModel>();
			for (int i = 1; i <= dt.Rows.Count; i++)
			{
				EmployeeModel p =  new EmployeeModel();
				p.Id = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
				p.Name = dt.Rows[i]["Name"].ToString();
				p.Position = dt.Rows[i]["Name"].ToString();
				p.Age = Convert.ToInt32(dt.Rows[i]["Age"].ToString());
				p.Office = dt.Rows[i]["Office"].ToString();
				
				employeeList.Add(p);
			}

			return Json(employeeList);
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
