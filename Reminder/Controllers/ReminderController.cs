using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reminder.Models;

namespace Reminder.Controllers
{
    public class ReminderController : Controller, IDisposable
    {
        NoteContext notesContext = new NoteContext();
        public ActionResult Index()
        {
            IEnumerable<Note> notes = notesContext.NotesTable;

            ViewBag.Notes = notes;

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Note note)
        {
            if (note != null)
            {
                notesContext.NotesTable.Add(note);
                notesContext.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var note = notesContext.NotesTable.Where(m => m.Id == id).FirstOrDefault();
            notesContext.NotesTable.Remove(note);

            notesContext.SaveChanges();
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var note = notesContext.NotesTable.Where(m => m.Id == id).FirstOrDefault();
            if (note != null)
            {
                ViewBag.Id = note.Id;
                ViewBag.Text = note.Text;
                ViewBag.Date = note.Date;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Note note)
        {
            var noteTemp = notesContext.NotesTable.Where(m => m.Id == note.Id).FirstOrDefault();

            noteTemp.Text = note.Text;
            noteTemp.Date = note.Date;

            notesContext.SaveChanges();
            return Redirect("Index");
        }
        protected override void Dispose(bool disposing)
        {
            notesContext.Dispose();
            base.Dispose(disposing);
        }
    }
}