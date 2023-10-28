using Microsoft.AspNetCore.Mvc;

namespace AddEditMetronic8.Areas.SEC_User.Controllers
{
	[Area("SEC_User")]
	[Route("[Controller]/[action]")]
	
	public class SEC_UserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
