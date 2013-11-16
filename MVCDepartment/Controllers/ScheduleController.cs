using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDepartment.Filters;
using MVCDepartment.Models;
using WebMatrix.WebData;

namespace MVCDepartment.Controllers
{
    [InitializeSimpleMembership]
    public class ScheduleController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Schedule/

        public ActionResult Index()
        {
            return View(db.Schedules.ToList());
        }

        //
        // GET: /Schedule/Details/5

        public ActionResult Details(int id = 0)
        {
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        //
        // GET: /Schedule/Create

        public ActionResult Create()
        {
            ViewBag.Disciplines = new SelectList(db.Disciplines.AsEnumerable(), "Id", "Name");
            return View();
        }

        //
        // POST: /Schedule/Create

        [HttpPost]
        public ActionResult Create(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                schedule.Discipline = db.Disciplines.Find(Convert.ToInt32(Request["discipline_id"]));
                schedule.UserAccount = db.UserAccounts.Find(WebSecurity.CurrentUserId);
                db.Schedules.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schedule);
        }

        //
        // GET: /Schedule/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        //
        // POST: /Schedule/Edit/5

        [HttpPost]
        public ActionResult Edit(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schedule);
        }

        //
        // GET: /Schedule/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        //
        // POST: /Schedule/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            db.Schedules.Remove(schedule);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}