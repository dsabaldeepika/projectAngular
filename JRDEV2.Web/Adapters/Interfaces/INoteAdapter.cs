using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEV2.Web.Adapters.Interfaces
{
    public interface INoteAdapter
    {
        List<Note> GetNote();
        Note GetNote(int id);
        Note PostNewNote(Note newNote);
        Note PutNote(int id, Note newNote);
        Note DeleteNote(int id);
    }
}
