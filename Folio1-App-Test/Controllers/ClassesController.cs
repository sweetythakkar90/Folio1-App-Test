using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Folio1_App_Test.Models;

namespace Folio1_App_Test.Controllers
{
    public class ClassesController : Controller
    {
        private FolioAppTestEntities db = new FolioAppTestEntities();

        //
        // GET: /Classes/

        public ActionResult Index(int? id, int? studentId)
        {
            var viewModel = new ClassesData();

            viewModel.Cls = db.tbl_Classes.ToList();
    
            if (id != null)
            {
                ViewBag.Id = id.Value;
                
                viewModel.Stud = viewModel.Cls.Where(
                    i => i.Id== id.Value).Single().tbl_Students;
            }

            return View(viewModel);
        }

        //
        // GET: /Classes/Details/5

        public ActionResult Details(int id = 0)
        {
            tbl_Classes tbl_classes = db.tbl_Classes.Find(id);
            if (tbl_classes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_classes);
        }

        //
        // GET: /Classes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Classes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_Classes tbl_classes)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Classes.Add(tbl_classes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_classes);
        }

        //
        // GET: /Classes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tbl_Classes tbl_classes = db.tbl_Classes.Find(id);
            if (tbl_classes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_classes);
        }

        //
        // POST: /Classes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_Classes tbl_classes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_classes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_classes);
        }

        //
        // GET: /Classes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tbl_Classes tbl_classes = db.tbl_Classes.Find(id);
            if (tbl_classes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_classes);
        }

        //
        // POST: /Classes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Classes tbl_classes = db.tbl_Classes.Find(id);
            db.tbl_Classes.Remove(tbl_classes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //

        //
        // GET: /Students/Details/5

        public ActionResult StudentDetails(int id = 0)
        {
            tbl_Students tbl_students = db.tbl_Students.Find(id);
            if (tbl_students == null)
            {
                return HttpNotFound();
            }
            return View(tbl_students);
        }

        //
        // GET: /Students/Create

        public ActionResult StudentCreate(int ? id)
        {

            ViewBag.ClassId = id;// new SelectList(db.tbl_Classes, "Id", "Name");
            ViewBag.ClassName = db.tbl_Classes.Find(id).Name;
            return View();
        }

        //
        // POST: /Students/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentCreate(tbl_Students tbl_students,string ClassId)
        {
            
            if (ModelState.IsValid)
            {
                tbl_students.ClassId = Convert.ToInt32(ClassId);
                db.tbl_Students.Add(tbl_students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.tbl_Classes, "Id", "Name", ViewBag.ClassId);
            return View(tbl_students);
        }

        //
        // GET: /Students/Edit/5

        public ActionResult StudentEdit(int id = 0)
        {
            tbl_Students tbl_students = db.tbl_Students.Find(id);
            if (tbl_students == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.tbl_Classes, "Id", "Name", tbl_students.ClassId);
            return View(tbl_students);
        }

        //
        // POST: /Students/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentEdit(tbl_Students tbl_students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.tbl_Classes, "Id", "Name", tbl_students.ClassId);
            return View(tbl_students);
        }

        //
        // GET: /Students/Delete/5

        public ActionResult StudentDelete(int id = 0)
        {
            tbl_Students tbl_students = db.tbl_Students.Find(id);
            if (tbl_students == null)
            {
                return HttpNotFound();
            }
            return View(tbl_students);
        }

        //
        // POST: /Students/Delete/5

        [HttpPost, ActionName("StudentDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult StudentDeleteConfirmed(int id)
        {
            tbl_Students tbl_students = db.tbl_Students.Find(id);
            db.tbl_Students.Remove(tbl_students);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

   
    }
}