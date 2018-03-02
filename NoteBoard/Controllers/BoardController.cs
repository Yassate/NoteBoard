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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace NoteBoard.Controllers
{
    public class BoardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Board/Private
        public async Task<ActionResult> Private()
        {
            string UserId = User.Identity.GetUserId();
            var Board = await db.Boards.FirstOrDefaultAsync(x => (x.UserId == UserId && x.BoardType == BoardType.Private));
            return View(Board);
        }

        // GET: Board/Private/AddNote
        [Route("Board/Private/AddNote", Name = "AddNoteToBoard_GET")] 
        public ActionResult AddNote()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Board/Private/AddNote", Name = "AddNoteToBoard_POST")]
        public async Task<ActionResult> AddNote(PrivateNoteViewModel model)
        {

            return View("Private");
        }



        // GET: Board
        public async Task<ActionResult> Index()
        {
            return View(await db.Boards.ToListAsync());
        }

        // GET: Board/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board Board = await db.Boards.FindAsync(id);
            if (Board == null)
            {
                return HttpNotFound();
            }
            return View(Board);
        }

        // GET: Board/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Board/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BoardID")] Board Board)
        {
            if (ModelState.IsValid)
            {
                db.Boards.Add(Board);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(Board);
        }

        // GET: Board/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board Board = await db.Boards.FindAsync(id);
            if (Board == null)
            {
                return HttpNotFound();
            }
            return View(Board);
        }

        // POST: Board/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BoardID")] Board Board)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Board).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Board);
        }

        // GET: Board/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board Board = await db.Boards.FindAsync(id);
            if (Board == null)
            {
                return HttpNotFound();
            }
            return View(Board);
        }

        // POST: Board/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Board Board = await db.Boards.FindAsync(id);
            db.Boards.Remove(Board);
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
