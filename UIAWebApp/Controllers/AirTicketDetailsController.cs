using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UIAWebApp.Models;

namespace UIAWebApp.Controllers
{
    [Authorize]
    public class AirTicketDetailsController : Controller
    {
        private UIATicketDataEntities db = new UIATicketDataEntities();

        // GET: AirTicketDetails
        public ActionResult Index()
        {
            var airTicketDetails = db.AirTicketDetails.Include(a => a.Customer);
            return View(airTicketDetails.ToList());
        }

        // GET: AirTicketDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirTicketDetail airTicketDetail = db.AirTicketDetails.Find(id);
            if (airTicketDetail == null)
            {
                return HttpNotFound();
            }
            return View(airTicketDetail);
        }

        // GET: AirTicketDetails/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName");
            return View();
        }

        // POST: AirTicketDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AirTicketID,Origin,Destination,DepartDate,ReturnDate,Guest,CustomerID")] AirTicketDetail airTicketDetail)
        {
            if (ModelState.IsValid)
            {
                db.AirTicketDetails.Add(airTicketDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName", airTicketDetail.CustomerID);
            return View(airTicketDetail);
        }

        // GET: AirTicketDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirTicketDetail airTicketDetail = db.AirTicketDetails.Find(id);
            if (airTicketDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName", airTicketDetail.CustomerID);
            return View(airTicketDetail);
        }

        // POST: AirTicketDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AirTicketID,Origin,Destination,DepartDate,ReturnDate,Guest,CustomerID")] AirTicketDetail airTicketDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airTicketDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName", airTicketDetail.CustomerID);
            return View(airTicketDetail);
        }

        // GET: AirTicketDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirTicketDetail airTicketDetail = db.AirTicketDetails.Find(id);
            if (airTicketDetail == null)
            {
                return HttpNotFound();
            }
            return View(airTicketDetail);
        }

        // POST: AirTicketDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AirTicketDetail airTicketDetail = db.AirTicketDetails.Find(id);
            db.AirTicketDetails.Remove(airTicketDetail);
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
