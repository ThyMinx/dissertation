﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QualityMonitoringSystem.Models;

namespace QualityMonitoringSystem.Controllers
{
    public class StaffsController : Controller
    {
        private QualityMonitoringSystemEntities db = new QualityMonitoringSystemEntities();

        // GET: Staffs
        // This handles any link that directs to the view main page in the Staffs.
        public async Task<ActionResult> Index()
        {
            return View(await db.Staffs.ToListAsync());
        }

        // GET: Staffs/Details/5
        // This handles any link that directs to the view "details" in the Staffs.
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = await db.Staffs.FindAsync(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: Staffs/Create
        // This handles any link that directs to the view "create" in the Staffs.
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Email,Password,Surname,Forenames")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Staffs.Add(staff);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(staff);
        }

        // GET: Staffs/Edit/5
        // This handles any link that directs to the view "edit" in the Staffs.
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = await db.Staffs.FindAsync(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Email,Password,Surname,Forenames")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: Staffs/Delete/5
        // This handles any link that directs to the view "delete" in the Staffs.
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = await db.Staffs.FindAsync(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Staff staff = await db.Staffs.FindAsync(id);
            db.Staffs.Remove(staff);
            await db.SaveChangesAsync();
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
