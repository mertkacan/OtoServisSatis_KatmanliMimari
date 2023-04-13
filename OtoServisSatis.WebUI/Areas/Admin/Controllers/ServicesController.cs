using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Interfaces;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class ServicesController : Controller
    {
        private readonly IService<Servis> _service;
        private readonly IService<Marka> _serviceMarka;
        private readonly IService<Arac> _serviceArac;

        public ServicesController(IService<Servis> service, IService<Marka> serviceMarka, IService<Arac> serviceArac)
        {
            _service = service;
            _serviceMarka = serviceMarka;
            _serviceArac = serviceArac;
        }
        // GET: ServicesController
        public async Task<ActionResult> Index()
        {
            var modeller = await _service.GetAllAsync();
            return View(modeller);
        }

        // GET: ServicesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServicesController/Create
        public ActionResult Create()
        {
            ViewBag.MarkaId = new SelectList(_serviceMarka.GetAll(), "Id", "Adi");
            ViewBag.AracId = new SelectList(_serviceArac.GetAll(), "Id", "Modeli");
            return View();
        }

        // POST: ServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Servis servis)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Add(servis);
                    _service.Save();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata oluştu");
                }
            }
            return View(servis);
        }

        // GET: ServicesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: ServicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Servis servis)
        {
            try
            {
                _service.Update(servis);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: ServicesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Servis servis)
        {
            try
            {
                _service.Delete(servis);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
