using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCAssign.Models;

namespace MVCAssign.Controllers
{
    public class Bhagyesh_UserRegistrationController : Controller
    {
        private CDACEntities1 db = new CDACEntities1();

        // GET: Bhagyesh_User
        public ActionResult Index()
        {
            return View(db.Bhagyesh_User.ToList());
        }

        // GET: Bhagyesh_User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bhagyesh_User bhagyesh_User = db.Bhagyesh_User.Find(id);
            if (bhagyesh_User == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/UserLogin/Details.cshtml", bhagyesh_User);
        }

        // GET: Bhagyesh_User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bhagyesh_User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "UserId,UserName,Password,ConfirmPassword,Address,IsActive")] Bhagyesh_User bhagyesh_User)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Bhagyesh_User.Add(bhagyesh_User);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(bhagyesh_User);
        //}

        // GET: Bhagyesh_User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bhagyesh_User bhagyesh_User = db.Bhagyesh_User.Find(id);
            if (bhagyesh_User == null)
            {
                return HttpNotFound();
            }
            return View( bhagyesh_User);
        }

        // POST: Bhagyesh_User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Password,ConfirmPassword,Address,IsActive")] Bhagyesh_User bhagyesh_User)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bhagyesh_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View( bhagyesh_User);
        }

        // GET: Bhagyesh_User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bhagyesh_User bhagyesh_User = db.Bhagyesh_User.Find(id);
            if (bhagyesh_User == null)
            {
                return HttpNotFound();
            }
            return View(bhagyesh_User);
        }

        // POST: Bhagyesh_User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bhagyesh_User bhagyesh_User = db.Bhagyesh_User.Find(id);
            db.Bhagyesh_User.Remove(bhagyesh_User);
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
