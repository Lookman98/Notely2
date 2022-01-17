using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notely.Models;

namespace Notely.Repositories
{
    public class NoteRepositories : INoteRepositories
    {
        private readonly List<Note> _notes;

        public NoteRepositories()
        {
            _notes = new List<Note>();
        }

        public Note FindById(Guid id)
        {
            var note = _notes.Find(n => n.Id == id);

            return note;
        }

        public IEnumerable<Note> GetAll()
        {
            return _notes;
        }

        public void Save(Note note)
        {
            _notes.Add(note);
        }

        public void Delete(Note note)
        {
            _notes.Remove(note);
        }
    }
}
