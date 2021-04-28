using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SenderPresentation.Controllers
{
    public class UpdateController : Controller
    {
        // GET: UpdateController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UpdateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UpdateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UpdateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: UpdateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UpdateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
        //public ActionResult Send(int StockId, string StockName, int StockValue)
        //{
        //    try {
        //        string result = ("Id=" + StockId);
        //        return Content(result);
        //    }
        //    catch {
        //        return View();
        //    }
        //} 

        // GET: UpdateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UpdateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
