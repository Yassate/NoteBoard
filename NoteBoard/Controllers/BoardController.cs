using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NoteBoard.Models;

namespace NoteBoard.Controllers
{
    public class BoardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MainBoard
        public async Task<ActionResult> Index()
        {
            return View(await db.Boards.ToListAsync());
        }

        // GET: MainBoard/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board mainBoard = await db.Boards.FindAsync(id);
            if (mainBoard == null)
            {
                return HttpNotFound();
            }
            return View(mainBoard);
        }

        // GET: MainBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainBoard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MainBoardID")] Board mainBoard)
        {
            if (ModelState.IsValid)
            {
                db.Boards.Add(mainBoard);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mainBoard);
        }

        // GET: MainBoard/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board mainBoard = await db.Boards.FindAsync(id);
            if (mainBoard == null)
            {
                return HttpNotFound();
            }
            return View(mainBoard);
        }

        // POST: MainBoard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BoardID")] Board mainBoard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainBoard).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mainBoard);
        }

        // GET: MainBoard/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board mainBoard = await db.Boards.FindAsync(id);
            if (mainBoard == null)
            {
                return HttpNotFound();
            }
            return View(mainBoard);
        }

        // POST: MainBoard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Board mainBoard = await db.Boards.FindAsync(id);
            db.Boards.Remove(mainBoard);
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
