using Microsoft.AspNetCore.Mvc;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")] // Controller'ın çalışması için yer tanımlaması yaptım.
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
