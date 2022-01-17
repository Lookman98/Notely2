using System;
using System.Collections.Generic;
using Notely.Models;

namespace Notely.Repositories
{
    public interface INoteRepositories
    {
        Note FindById(Guid id);
        IEnumerable<Note> GetAll();
        void Save(Note note);
        void Delete(Note note);
    }
}