using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    public class HousesController : Controller
    {
        // GET: HousesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HousesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HousesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HousesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HousesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HousesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HousesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HousesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
