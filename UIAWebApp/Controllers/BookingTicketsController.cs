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
    public class BookingTicketsController : Controller
    {
        private UIATicketDataEntities db = new UIATicketDataEntities();

        // GET: BookingTickets
        public ActionResult Index()
        {
            var bookingTickets = db.BookingTickets.Include(b => b.Airport).Include(b => b.AirTicketDetail).Include(b => b.Flight);
            return View(bookingTickets.ToList());
        }

        // GET: BookingTickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingTicket bookingTicket = db.BookingTickets.Find(id);
            if (bookingTicket == null)
            {
                return HttpNotFound();
            }
            return View(bookingTicket);
        }

        // GET: BookingTickets/Create
        public ActionResult Create()
        {
            ViewBag.AirportID = new SelectList(db.Airports, "AirportID", "AirportName");
            ViewBag.AirTicketID = new SelectList(db.AirTicketDetails, "AirTicketID", "Origin");
            ViewBag.FlightNumber = new SelectList(db.Flights, "FlightNumber", "FlightDepart");
            return View();
        }

        // POST: BookingTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,BookingDate,AirTicketID,FlightNumber,AirportID")] BookingTicket bookingTicket)
        {
            if (ModelState.IsValid)
            {
                db.BookingTickets.Add(bookingTicket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AirportID = new SelectList(db.Airports, "AirportID", "AirportName", bookingTicket.AirportID);
            ViewBag.AirTicketID = new SelectList(db.AirTicketDetails, "AirTicketID", "Origin", bookingTicket.AirTicketID);
            ViewBag.FlightNumber = new SelectList(db.Flights, "FlightNumber", "FlightDepart", bookingTicket.FlightNumber);
            return View(bookingTicket);
        }

        // GET: BookingTickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingTicket bookingTicket = db.BookingTickets.Find(id);
            if (bookingTicket == null)
            {
                return HttpNotFound();
            }
            ViewBag.AirportID = new SelectList(db.Airports, "AirportID", "AirportName", bookingTicket.AirportID);
            ViewBag.AirTicketID = new SelectList(db.AirTicketDetails, "AirTicketID", "Origin", bookingTicket.AirTicketID);
            ViewBag.FlightNumber = new SelectList(db.Flights, "FlightNumber", "FlightDepart", bookingTicket.FlightNumber);
            return View(bookingTicket);
        }

        // POST: BookingTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,BookingDate,AirTicketID,FlightNumber,AirportID")] BookingTicket bookingTicket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingTicket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AirportID = new SelectList(db.Airports, "AirportID", "AirportName", bookingTicket.AirportID);
            ViewBag.AirTicketID = new SelectList(db.AirTicketDetails, "AirTicketID", "Origin", bookingTicket.AirTicketID);
            ViewBag.FlightNumber = new SelectList(db.Flights, "FlightNumber", "FlightDepart", bookingTicket.FlightNumber);
            return View(bookingTicket);
        }

        // GET: BookingTickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingTicket bookingTicket = db.BookingTickets.Find(id);
            if (bookingTicket == null)
            {
                return HttpNotFound();
            }
            return View(bookingTicket);
        }

        // POST: BookingTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingTicket bookingTicket = db.BookingTickets.Find(id);
            db.BookingTickets.Remove(bookingTicket);
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
