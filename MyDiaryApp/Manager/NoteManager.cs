using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyDiaryApp.Models;
using MyDiaryApp.GateWay;

namespace MyDiaryApp.Manager
{
    
    public class NoteManager
    {
        NoteGateWay noteGateWay = new NoteGateWay();

        public string SaveNote(Note note)
        {
            if (noteGateWay.SaveNote(note) > 0)
            {
                return "Saved";
            }
            return "Don't Save";
        }

        //ShowNote
        public List<Note> ShowNotes()
        {
           
                return noteGateWay.ShowNotes();
            
        }

        public Note Edit(int noteId)
        {
            return noteGateWay.Edit(noteId);
        }

        public int SaveEdit(Note note)
        {
            return noteGateWay.SaveEdit(note);
        }
        public int Delete(int id)
        {
            return noteGateWay.Delete(id);
        }
    }
}