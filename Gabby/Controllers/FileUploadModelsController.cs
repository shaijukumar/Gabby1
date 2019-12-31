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
    public class FileUploadModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FileUploadModels
        public ActionResult Index()
        {
            return View(db.FileUploadModels.ToList());
        }

        // GET: FileUploadModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileUploadModel fileUploadModel = db.FileUploadModels.Find(id);
            if (fileUploadModel == null)
            {
                return HttpNotFound();
            }
            return View(fileUploadModel);
        }

        // GET: FileUploadModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FileUploadModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FileName,FilePath")] FileUploadModel fileUploadModel, HttpPostedFileBase fileupload1)
        {
            //if (ModelState.IsValid)
            //{
            //    db.FileUploadModels.Add(fileUploadModel);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}


            string filename = string.Empty;
            string filepath = string.Empty;
            
            if (ModelState.IsValid)
            {                
                filename = fileupload1.FileName;
                string ext = Path.GetExtension(filename);

                if (ext == ".jpg" || ext == ".png")
                {
                    filepath = Server.MapPath("~//Files//");
                    fileupload1.SaveAs(filepath + filename);
                    // FileUploadModel fm = new FileUploadModel();
                    fileUploadModel.FileName = filename;
                    fileUploadModel.FilePath = "~//Files//";

                    db.FileUploadModels.Add(fileUploadModel);
                    db.SaveChanges();
                }
                else
                {
                    return Content("You can upload only jpg or png file");
                }
            }
            else
            {
                return Content("You can upload only jpg or png file");
            }

            return RedirectToAction("Index");
        }

        // GET: FileUploadModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileUploadModel fileUploadModel = db.FileUploadModels.Find(id);
            if (fileUploadModel == null)
            {
                return HttpNotFound();
            }
            return View(fileUploadModel);
        }

        // POST: FileUploadModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FileName,FilePath")] FileUploadModel fileUploadModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fileUploadModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fileUploadModel);
        }

        // GET: FileUploadModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileUploadModel fileUploadModel = db.FileUploadModels.Find(id);
            if (fileUploadModel == null)
            {
                return HttpNotFound();
            }
            return View(fileUploadModel);
        }

        // POST: FileUploadModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FileUploadModel fileUploadModel = db.FileUploadModels.Find(id);
            db.FileUploadModels.Remove(fileUploadModel);
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
