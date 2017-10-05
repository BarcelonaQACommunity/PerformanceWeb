using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PerformanceWeb.Controllers
{
    public class GroupTodoListController : Controller
    {
        // GET: GroupTodoList
        public ActionResult Index()
        {
            return View();
        }

        // GET: GroupTodoList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GroupTodoList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupTodoList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GroupTodoList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GroupTodoList/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GroupTodoList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GroupTodoList/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}