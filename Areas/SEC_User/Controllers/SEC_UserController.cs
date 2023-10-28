using AddEditMetronic8.DAL;
using AddEditMetronic8.Areas.SEC_User.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AddEditMetronic8.Areas.SEC_User.Controllers
{
	[Area("SEC_User")]
	[Route("[Controller]/[action]")]

	public class SEC_UserController : Controller
	{
		private IConfiguration Configuration;
		public SEC_UserController(IConfiguration _configuration)
		{
			Configuration = _configuration;
		}

		public IActionResult Index()
		{
			return View();
		}

		#region LogIn
		[HttpPost]
		public IActionResult Login(SEC_UserModel modelSEC_User)
		{
			string connstr = this.Configuration.GetConnectionString("myConnectionString");
			string error1 = null;
			string error2 = null;
			if (modelSEC_User.UserName == null)
			{
				error1 += "User Name is required";
			}
			if (modelSEC_User.Password == null)
			{
				error2 += "Password is required";
			}

			if (error1 != null && error2 != null)
			{
				TempData["UserName"] = error1;
				TempData["Password"] = error2;
				return RedirectToAction("Index");
			}
			else
			{
				SEC_DAL dal = new SEC_DAL();
				DataTable dt = dal.dbo_PR_SEC_User_SelectByUserNamePassword(modelSEC_User.UserName, modelSEC_User.Password);
				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
						HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
						HttpContext.Session.SetString("Password", dr["Password"].ToString());
						HttpContext.Session.SetString("FirstName", dr["FirstName"].ToString());
						HttpContext.Session.SetString("LastName", dr["LastName"].ToString());
						HttpContext.Session.SetString("LastName", dr["EmailAddress"].ToString());

						break;
					}
				}
				else
				{
					TempData["Error"] = "User Name or Password is invalid!";
					return RedirectToAction("Index");
				}
				if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null)
				{
					return RedirectToAction("Index", "Home");
				}
			}
			return RedirectToAction("Index");
		}
		#endregion

		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index");
		}
	}
}
