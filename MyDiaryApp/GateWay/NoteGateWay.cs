using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyDiaryApp.Models;
using  System.Data.SqlClient;
using System.Linq.Expressions;

namespace MyDiaryApp.GateWay
{
    public class NoteGateWay : DBConnection
    {
        public int SaveNote(Note note)
        {
            note.CreatedDateTime = DateTime.Now.ToString();

           try
            {
                Query = "Insert into NoteTB(UserId,CreatedDateTime,NoteTitle,NoteDescription)Values(@UserId,@CreatedDateTime,@NoteTitle,@NoteDescription)";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Connection.Open();

                Command.Parameters.AddWithValue("@UserId", note.UserId);
                Command.Parameters.AddWithValue("@CreatedDateTime", note.CreatedDateTime);
                Command.Parameters.AddWithValue("@NoteTitle", note.NoteTitle);
                Command.Parameters.AddWithValue("@NoteDescription", note.NoteDescription);

                Count = Command.ExecuteNonQuery();
                Connection.Close();
        }
            catch (Exception)
            {
                
            }
            return Count;

        }

      


        //ShowNote
        public List<Note> ShowNotes()
        {
            
            List<Note> noteList=new List<Note>();

            try
            {
                Query = "Select * From NoteTB where UserId='" +1004+ "' ORDER BY CreatedDateTime ASC ";
                Command = new SqlCommand(Query, Connection);
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    Note notes = new Note();
                    notes.NotId = (int)Reader["NoteId"];
                    //notes.UserId = (int)Reader["UserId"];
                    notes.CreatedDateTime = Reader["CreatedDateTime"].ToString();
                    notes.NoteTitle = Reader["NoteTitle"].ToString();
                    //notes.NoteDescription = Reader["NoteDescription"].ToString();

                    noteList.Add(notes);
                  
                }
                Reader.Close();
                Connection.Close();
            }
            catch (Exception)
            {
                
            }
                return noteList;

        }


        //Edit
        public Note Edit(int noteId)
        {

            Note notes = new Note();

            try
            {
                Query = "Select * From NoteTB where NoteId='" + noteId + "' ";
                Command = new SqlCommand(Query, Connection);
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {

                    notes.NotId = (int)Reader["NoteId"];
                    //notes.UserId = (int)Reader["UserId"];
                    // notes.CreatedDateTime = Reader["CreatedDateTime"].ToString();
                    notes.NoteTitle = Reader["NoteTitle"].ToString();
                    notes.NoteDescription = Reader["NoteDescription"].ToString();



                }
                Reader.Close();
                Connection.Close();
            }
            catch (Exception)
            {

            }
            return notes;

        }


        public int SaveEdit(Note note)
        {
            Query = "Update NoteTB set NoteTitle='"+note.NoteTitle+"', NoteDescription='"+note.NoteDescription+"' where NoteId='"+note.NotId+"'";
            
            Command =new SqlCommand(Query,Connection);
            Connection.Open();
            Count = Command.ExecuteNonQuery();
            Connection.Close();
            return Count;
        }



        public int Delete(int id)
        {
            Query = "Delete from NoteTB where NoteId='"+id+"'";
            
            Command =new SqlCommand(Query,Connection);
            Connection.Open();
            Count = Command.ExecuteNonQuery();
            Connection.Close();
            return Count;
        }

    }
}