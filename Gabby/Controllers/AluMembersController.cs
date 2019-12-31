using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gabby.Models;

namespace Gabby.Controllers
{
    public class AluMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AluMembers
        public ActionResult Index()
        {
            return View(db.AppLists.ToList());
        }

        // GET: AluMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AluMember aluMember = db.AppLists.Find(id);
            if (aluMember == null)
            {
                return HttpNotFound();
            }
            return View(aluMember);
        }

        // GET: AluMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AluMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AluMemberID,Name,ImagePath,DOB,Details")] AluMember aluMember, HttpPostedFileBase ImageFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string extension = Path.GetExtension(ImageFile.FileName);

            if (ModelState.IsValid)
            {
                db.AppLists.Add(aluMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aluMember);
        }

        // GET: AluMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AluMember aluMember = db.AppLists.Find(id);
            if (aluMember == null)
            {
                return HttpNotFound();
            }
            return View(aluMember);
        }

        // POST: AluMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AluMemberID,Name,ImagePath,DOB,Details")] AluMember aluMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aluMember);
        }

        // GET: AluMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AluMember aluMember = db.AppLists.Find(id);
            if (aluMember == null)
            {
                return HttpNotFound();
            }
            return View(aluMember);
        }

        // POST: AluMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AluMember aluMember = db.AppLists.Find(id);
            db.AppLists.Remove(aluMember);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
