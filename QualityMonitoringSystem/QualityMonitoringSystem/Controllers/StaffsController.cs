using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QualityMonitoringSystem.Models;
using QualityMonitoringSystem.Interfaces;
using QualityMonitoringSystem.Dal;

namespace QualityMonitoringSystem.Controllers
{
    public class StaffsController : Controller
    {
        public IDatabaseAccess<Staff> databaseAccess = new StaffDatabaseAccess();
        // GET: Staffs
        // This handles any link that directs to the view main page in the Staffs.
        public async Task<ActionResult> Index()
        {
            return View(await this.databaseAccess.GetAllAsync());
        }

        // GET: Staffs/Details/5
        // This handles any link that directs to the view "details" in the Staffs.
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = await this.databaseAccess.FindByIdAsync(id);
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
                this.databaseAccess.Add(staff);
                await this.databaseAccess.SaveChangesAsync();
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
            Staff staff = await this.databaseAccess.FindByIdAsync(id);
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
                this.databaseAccess.Entry(staff).State = EntityState.Modified;
                await this.databaseAccess.SaveChangesAsync();
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
            Staff staff = await this.databaseAccess.FindByIdAsync(id);
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
            Staff staff = await this.databaseAccess.FindByIdAsync(id);
            this.databaseAccess.Remove(staff);
            await this.databaseAccess.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.databaseAccess.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
