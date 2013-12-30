using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PicturesExchange.Models;

namespace PicturesExchange.Controllers
{
    public class PicturesExchangeController : Controller
    {
        private PicturesExchangeContext db = new PicturesExchangeContext();

        // GET: /PicturesExchange/
        public ActionResult Index()
        {
            return View(db.Pictures.ToList());
        }

        // GET: /PicturesExchange/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        public ActionResult ErrorReport()
        {
            return View();
        }

        // GET: /PicturesExchange/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PicturesExchange/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID, Name")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase photo = Request.Files["photo"];

                if (null == photo)
                {
                    ModelState.AddModelError("photo", "No file was uploaded");
                    return RedirectToAction("ErrorReport");
                }

                picture.contentType = photo.ContentType;
                picture.pictureData = new byte[photo.ContentLength];
                photo.InputStream.Read(picture.pictureData, 0, photo.ContentLength);

                db.Pictures.Add(picture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(picture);
        }

        public ActionResult GetImage(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("photo", "Wrong request");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var photoItem = db.Pictures.Find(id);

            return new FileContentResult(photoItem.pictureData, photoItem.contentType);
        }

        // GET: /PicturesExchange/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: /PicturesExchange/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Picture picture)
        {
            HttpPostedFileBase photo = Request.Files["photo"];

            if (ModelState.IsValid && null != photo)
            {
                picture.pictureData = new byte[photo.ContentLength];
                photo.InputStream.Read(picture.pictureData, 0, photo.ContentLength);
                picture.contentType = photo.ContentType;

                db.Entry(picture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(picture);
        }

        // GET: /PicturesExchange/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: /PicturesExchange/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Picture picture = db.Pictures.Find(id);
            db.Pictures.Remove(picture);
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
