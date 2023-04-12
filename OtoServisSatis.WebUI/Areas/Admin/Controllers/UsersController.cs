﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Interfaces;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IService<Kullanici> _service;
        private readonly IService<Rol> _serviceRol; // Create View'a, RolId göndermek için oluşturdum.

        public UsersController(IService<Kullanici> service, IService<Rol> serviceRol)
        {
            _service = service;
            _serviceRol = serviceRol;
        }
        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            var kullanicilar = await _service.GetAllAsync();
            return View(kullanicilar);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsync(), "Id", "Adi"); // RolId seçmek için Listeyi, Create View'ına gönderdim. Metin olarak Rol sınıfındaki kolonları yazdım. 
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.AddAsync(kullanici);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu");
                }
            }
            ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsync(), "Id", "Adi");
            return View(kullanici);

        }

        // GET: UsersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _service.FindAsync(id);
            ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsync(), "Id", "Adi"); // ViewBag listeleme.
            return View(model);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Kullanici kullanici)
        {
            try
            {
                _service.Update(kullanici);
                _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Kullanici kullanici)
        {
            try
            {
                _service.Delete(kullanici);
                _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
