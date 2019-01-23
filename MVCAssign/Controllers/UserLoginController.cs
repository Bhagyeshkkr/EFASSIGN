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
    public class UserLoginController : Controller
    {
        private CDACEntities1 db = new CDACEntities1();

        // GET: UserLogin
        //public ActionResult Index()
        //{
        //    return View(db.Bhagyesh_User.ToList());
        //}
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(UserLogin reg)
        {
            if (ModelState.IsValid)
            {
                var details = (from userlist in db.Bhagyesh_Admin
                               where userlist.UserName == reg.UserName && userlist.Password == reg.Password
                               select new
                               {
                                   userlist.UserId,
                                   userlist.UserName
                               }).ToList();


                if (details.FirstOrDefault() != null)
                {
                    Session["UserId"] = details.FirstOrDefault().UserId;
                    Session["UserName"] = details.FirstOrDefault().UserName;
                    return RedirectToAction("List");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid credentials");
            }
            return View(reg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(UserLogin reg)
        {
            if (ModelState.IsValid)
            {
                var details = (from userlist in db.Bhagyesh_User
                               where userlist.UserName == reg.UserName && userlist.Password == reg.Password
                               select new
                               {
                                   userlist.UserId,
                                   userlist.UserName

                               }).ToList();


                if (details.FirstOrDefault() != null)
                {
                    Session["UserId"] = details.FirstOrDefault().UserId;
                    Session["UserName"] = details.FirstOrDefault().UserName;
                    //var data=db.Bhagyesh_User.Where(x => x.IsActive == reg.IsActive).FirstOrDefault();
                    //if (data.IsActive==false)
                    //{
                    //    ModelState.AddModelError("", "Deactivated User");
                    //}

                    return RedirectToAction("Details", "Bhagyesh_UserRegistration", new { id = details.FirstOrDefault().UserId });
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid credentials");
            }
            return View(reg);
        }
        public ActionResult Details()
        {
            return View();

        }
        public ActionResult wellcome()
        {
            return View();

        }
        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit(int id)
        //{
        //        return RedirectToAction("Edit"+"/"+id,"UserLogin");

        //}
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
            return View(bhagyesh_User);
        }
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
            return View(bhagyesh_User);
        }
        public ActionResult wellcomeAdmin()
        {
            return View();

        }
        public ActionResult List()
        {
            return View(db.Bhagyesh_User.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: UserLogin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,Password,ConfirmPassword,Address,IsActive")] Bhagyesh_User bhagyesh_User)
        {
            if (ModelState.IsValid)
            {
                db.Bhagyesh_User.Add(bhagyesh_User);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/UserLogin/wellcome.cshtml", bhagyesh_User);
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

