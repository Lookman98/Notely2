using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notely.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Notely.Repositories;

namespace Notely.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INoteRepositories _noteRepositories;

        public HomeController(ILogger<HomeController> logger, INoteRepositories noteRepositories)
        {
            _logger = logger;
            _noteRepositories = noteRepositories;
        }

        public IActionResult Index()
        {
            var notes = _noteRepositories.GetAll().Where(n => n.IsDeleted == false);

            return View(notes);
        }

        public IActionResult NoteDetail(Guid id)
        {
            var note = _noteRepositories.FindById(id);

            return View(note);
        }

        [HttpGet]
        public IActionResult NoteEditor(Guid id = default)
        {
            if (id != Guid.Empty)
            {
                var note = _noteRepositories.FindById(id);
                return View(note);
            }

            return View();
        }

        [HttpPost]
        public IActionResult NoteEditor(Note note)
        {
            var date = DateTime.Now;

            if (ModelState.IsValid)
            {

                if (note != null && note.Id == Guid.Empty)
                {
                    note.Id = Guid.NewGuid();
                    note.CreatedDateTime = date;
                    note.LastModifiedDate = date;
                    _noteRepositories.Save(note);

                }
                else
                {
                    var noteEdit = _noteRepositories.FindById(note.Id);
                    noteEdit.LastModifiedDate = date;
                    noteEdit.Subject = note.Subject;
                    noteEdit.Detail = note.Detail;
                } 
            }
            else
            {
                return View();
            }

            return RedirectToAction("index");
        }

        public IActionResult DeleteNote(Guid id)
        {
            var note = _noteRepositories.FindById(id);
            note.IsDeleted = true;
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
