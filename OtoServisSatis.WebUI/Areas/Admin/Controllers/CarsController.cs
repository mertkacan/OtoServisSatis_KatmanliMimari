using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Interfaces;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarsController : Controller
    {
        private readonly IService<Arac> _service;
        private readonly IService<Marka> _markaService;

        public CarsController(IService<Arac> service,IService<Marka>markaService)
        {
            _service = service;
            _markaService = markaService;
        }
        // GET: CarsController
        public async Task<ActionResult> Index()
        {
            var araclar = await _service.GetAllAsync();
            return View(araclar);
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarsController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.MarkaId = new SelectList(await _markaService.GetAllAsync(),"Id","Adi"); // Create View'da, Marka seçimini yapmak için liste tipi oluşturduk.
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Arac arac)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Add(arac);
                    _service.Save();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata oluştu");
                }
            }
            ViewBag.MarkaId = new SelectList(_markaService.GetAll(), "Id", "Adi");
            return View(arac);
        }

        // GET: CarsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.MarkaId = new SelectList(await _markaService.GetAllAsync(), "Id", "Adi");
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Arac arac)
        {
            try
            {
                _service.Update(arac);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var arac = await _service.FindAsync(id);
            return View(arac);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Arac arac)
        {
            try
            {
                _service.Delete(arac);
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
