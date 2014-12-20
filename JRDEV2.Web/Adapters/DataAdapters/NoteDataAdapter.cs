using JRDEV2.Web.Adapters.Interfaces;
using JRDEVData;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.DataAdapters
{
    public class NoteDataAdapter : INoteAdapter
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<Note> GetNote()
        {
            List<Note> model = new List<Note>();
            model = db.Notes
                            //.Where(j=>j.Hidden == false)
                            .ToList();
            return model;

        }
        public Note GetNote(int id)
        {
            Note model = new Note();

            model = db.Notes
                           .Where(j => j.NoteId == id)
                           //.Where(j=>j.Hidden == false)
                           .FirstOrDefault();
            return model;
        }

        public Note PostNewNote(Note newNote)
        {
            Note note = new Note();
            //set variables
            db.Notes.Add(note);
            db.SaveChanges();

            return newNote; 
        }

        public Note PutNote(int id, Note newNote)
        {
            db.Notes.Where(j=>j.NoteId == id)
                        //.Where(j=>j.Hidden == false)
                        .FirstOrDefault();
            Note note = new Note();
            //Set Variables
            db.SaveChanges();
            return newNote;
        }

        public Note DeleteNote(int id)
        {           
            Note note = new Note();
            note = db.Notes
                            .Where(j => j.NoteId == id)
                            //.Where(j=>j.Hidden == false)
                            .FirstOrDefault();
            note.IsDeleted = true;
            db.SaveChanges();
            return db.Notes.FirstOrDefault();
        }
    }
}