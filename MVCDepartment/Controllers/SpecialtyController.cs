using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDepartment.Models;

namespace MVCDepartment.Controllers
{
    public class SpecialtyController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Specialty/

        public ActionResult Index()
        {
            var specialties = db.Specialties.Include(s => s.Plan);
            return View(specialties.ToList());
        }

        //
        // GET: /Specialty/Details/5

        public ActionResult Details(int id = 0)
        {
            Specialty specialty = db.Specialties.Find(id);
            if (specialty == null)
            {
                return HttpNotFound();
            }
            return View(specialty);
        }

        //
        // GET: /Specialty/Create

        public ActionResult Create()
        {
            ViewBag.Plans = new SelectList(db.Plans, "Id", "File");
            return View();
        }

        //
        // POST: /Specialty/Create

        [HttpPost]
        public ActionResult Create(Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                int planId;
                if (int.TryParse(Request["PlanId"], out planId))
                {
                    specialty.Plan = db.Plans.Find(planId);
                }
                db.Specialties.Add(specialty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Plans = new SelectList(db.Plans, "Id", "File");
            return View(specialty);
        }

        //
        // GET: /Specialty/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Specialty specialty = db.Specialties.Find(id);
            if (specialty == null)
            {
                return HttpNotFound();
            }
            ViewBag.Plans = new SelectList(db.Plans, "Id", "File", specialty.Id);
            return View(specialty);
        }

        //
        // POST: /Specialty/Edit/5

        [HttpPost]
        public ActionResult Edit(Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Plans = new SelectList(db.Plans, "Id", "File", specialty.Id);
            return View(specialty);
        }

        //
        // GET: /Specialty/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Specialty specialty = db.Specialties.Find(id);
            if (specialty == null)
            {
                return HttpNotFound();
            }
            return View(specialty);
        }

        //
        // POST: /Specialty/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Specialty specialty = db.Specialties.Find(id);
            db.Specialties.Remove(specialty);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult UploadPlan()
        {
            HttpPostedFileBase file = Request.Files[0];
            string message = "File upload failed";

            const int NULL_PLAN = -1;
            if (file == null || file.ContentLength == 0)
            {
                return Json(new { isUploaded = false, message = message, planId = NULL_PLAN }, "text/html");
            }
            string pathForSaving = Server.MapPath("~/Uploads");
            if (!this.CreateFolderIfNeeded(pathForSaving))
            {
                return Json(new { isUploaded = false, message = message, planId = NULL_PLAN }, "text/html");
            }
            try
            {
                file.SaveAs(Path.Combine(pathForSaving, file.FileName));
                message = file.FileName;
                var planId = AddPlanRecord(file.FileName);
                return Json(new { isUploaded = true, message = message, planId = planId }, "text/html");
            }
            catch (Exception ex)
            {
                message = string.Format("File upload failed: {0}. Inner: {1}", ex.Message, ex.InnerException);
                return Json(new { isUploaded = false, message = message, planId = NULL_PLAN }, "text/html");
            }
        }

        private int AddPlanRecord(string filename)
        {
            var plan = new Plan()
                           {
                               File = filename
                           };
            db.Plans.Add(plan);
            db.SaveChanges();
            return plan.Id;
        }



        /// <summary>
        /// Creates the folder if needed.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    /*TODO: You must process this exception.*/
                    result = false;
                }
            }
            return result;
        }
    }
}