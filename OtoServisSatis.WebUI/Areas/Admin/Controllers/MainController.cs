using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize] // Controller'ın çalışması için yer tanımlaması yaptım.
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
