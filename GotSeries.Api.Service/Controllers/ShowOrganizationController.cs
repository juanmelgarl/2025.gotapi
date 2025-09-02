using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GotSeries.Api.Service.Controllers
{
    public class ShowOrganizationController : Controller
    {
        // GET: ShowOrganizationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShowOrganizationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShowOrganizationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShowOrganizationController/Create
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

        // GET: ShowOrganizationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShowOrganizationController/Edit/5
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

        // GET: ShowOrganizationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShowOrganizationController/Delete/5
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
