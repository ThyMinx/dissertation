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

namespace QualityMonitoringSystem.Controllers
{
    public class CourseworksController : Controller
    {
        private QualityMonitoringSystemEntities db = new QualityMonitoringSystemEntities();

        // GET: Courseworks
        public async Task<ActionResult> Index()
        {
            var courseworks = db.Courseworks.Include(c => c.Module);
            return View(await courseworks.ToListAsync());
        }

        // GET: Courseworks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coursework coursework = await db.Courseworks.FindAsync(id);
            if (coursework == null)
            {
                return HttpNotFound();
            }
            return View(coursework);
        }

        // GET: Courseworks/Create
        public ActionResult Create()
        {
            ViewBag.ModuleID = new SelectList(db.Modules, "ID", "Name");
            return View();
        }

        // POST: Courseworks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Title,BoxFileLink,Reviewed,ModuleID")] Coursework coursework)
        {
            if (ModelState.IsValid)
            {
                db.Courseworks.Add(coursework);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ModuleID = new SelectList(db.Modules, "ID", "Name", coursework.ModuleID);
            return View(coursework);
        }

        // GET: Courseworks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coursework coursework = await db.Courseworks.FindAsync(id);
            if (coursework == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModuleID = new SelectList(db.Modules, "ID", "Name", coursework.ModuleID);
            return View(coursework);
        }

        // POST: Courseworks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Title,BoxFileLink,Reviewed,ModuleID")] Coursework coursework)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursework).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ModuleID = new SelectList(db.Modules, "ID", "Name", coursework.ModuleID);
            return View(coursework);
        }

        // GET: Courseworks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coursework coursework = await db.Courseworks.FindAsync(id);
            if (coursework == null)
            {
                return HttpNotFound();
            }
            return View(coursework);
        }

        // POST: Courseworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Coursework coursework = await db.Courseworks.FindAsync(id);
            db.Courseworks.Remove(coursework);
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
