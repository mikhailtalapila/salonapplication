using DataAccess.Context;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.Notes
{
   public class NotesController : ApiBaseController
    {
      public NotesController(SalonDbContext db):base(db)
      {

      }

      public HttpResponseMessage Get()
      {
         var notes = _db.Notes.Where(n=>n.Active==true).ToList();
         if (notes == null) throw new HttpResponseException(HttpStatusCode.NotFound);
         return Request.CreateResponse<IEnumerable<Note>>(HttpStatusCode.OK, notes);
      }


      public HttpResponseMessage Get(int id)
      {
         var note = _db.Notes.FirstOrDefault(n => n.NoteId == id);
         if (note == null) throw new HttpResponseException(HttpStatusCode.NotFound);
         return Request.CreateResponse<Note>(HttpStatusCode.OK, note);
      }

      public HttpResponseMessage Post([FromBody] Note values)
      {
         var newNote = new Note
         {
            NoteDescription = values.NoteDescription,
            CreatedOn = values.CreatedOn,
            CreatedBy = values.CreatedBy,
            Active = values.Active,
            Completed = values.Completed,
            CompletedOn = values.CompletedOn,
            CompletedBy = values.CompletedBy
         };
         var n = _db.Notes.Add(newNote);
         _db.SaveChanges();
         if (n != null)
         {
            var msg = new HttpResponseMessage(HttpStatusCode.Created);
            msg.Headers.Location = new Uri(Request.RequestUri + "/" + newNote.NoteId.ToString());
            return msg;
         }
         else
         {
            var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
            return msg;
         }
      }

      public HttpResponseMessage Put([FromBody] Note values)
      {
         
         var note = new Note
         {
            NoteId = values.NoteId,
            NoteDescription = values.NoteDescription,
            CreatedOn = values.CreatedOn,
            CreatedBy = values.CreatedBy,
            Active = values.Active,
            Completed = values.Completed,
            CompletedOn = values.CompletedOn,
            CompletedBy = values.CompletedBy
         };
         var status = _db.Notes.Attach(note);
         var entry = _db.Entry(note);
         entry.Property(e => e.NoteDescription).IsModified = true;
         entry.Property(e => e.CreatedOn).IsModified = true;
         entry.Property(e => e.CreatedBy).IsModified = true;
         entry.Property(e => e.Active).IsModified = true;
         entry.Property(e => e.Completed).IsModified = true;
         entry.Property(e => e.CompletedOn).IsModified = true;
         entry.Property(e => e.CompletedBy).IsModified = true;
         _db.SaveChanges();
         if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
         throw new HttpResponseException(HttpStatusCode.NotFound);
      }

      public HttpResponseMessage Delete(int id)
      {
         var note = new Note { NoteId = id };
         _db.Notes.Attach(note);
         var status = _db.Notes.Remove(note);
         _db.SaveChanges();
         if (status != null) return new HttpResponseMessage(HttpStatusCode.OK);
         throw new HttpResponseException(HttpStatusCode.NotFound);
      }

    }
}
