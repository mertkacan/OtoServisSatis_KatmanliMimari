using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Interfaces;
using System.Security.Claims;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IService<Kullanici> _service;

        public LoginController(IService<Kullanici>service)
        {
            _service = service;
        }
        public async Task<IActionResult> LogOut() // Oturumu kapatmak için oluşturdum.
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin/Login"); // Redirect metodu ile Admin/Logout sayfasına yönlendirildi.
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string email,string password) //Oturum açmak için işlemler yapıldı.
        {
            try
            {
                var account=_service.Get(x=>x.Email == email && x.Sifre==password && x.AktifMi==true);
                if (account==null)
                {

                    TempData["mesaj"] = "Giriş başarısız";
                }
                else
                {
                    var claims=new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, account.Adi),
                        new Claim("Role", "Admin"),
                    };
                    var userIdentity=new ClaimsIdentity(claims,"Login");
                    ClaimsPrincipal principal=new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return Redirect("/Admin");
                }
            }
            catch (Exception)
            {
                TempData["mesaj"] = "Hata oluştu";
            }
            return View();
        }
    }
}
