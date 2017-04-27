using DesignerPals.Data;
using DesignerPals.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignerPals.Infrastructure
{
    public class QRepository : IDisposable, IRepository
    {
        private ApplicationDbContext _db;

        public QRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        //retrieve all questions
        public IList<Q> ListQ()
        {
            return _db.Qs.Include(i => i.Answers).ToList();
        }
        //find q by primary key
        public Q FindQ(int id)
        {
            return _db.Qs.FirstOrDefault(i => i.Id == id);
        }

        //add new question
        public void CreateQ(Q qtoCreate)
        {
            _db.Qs.Add(qtoCreate);
            _db.SaveChanges();
        }
        //update existing question in database
        public void UpdateQ(Q qtoUpdate)
        {
            var originalQ = FindQ(qtoUpdate.Id);
            originalQ.Name = qtoUpdate.Name;
            originalQ.Question = qtoUpdate.Question;
            originalQ.Answers = qtoUpdate.Answers;
            _db.SaveChanges();
        }

        //delete existing question in database
        public void DeleteQ(int id)
        {
            var originalQ = this.FindQ(id);
            _db.Qs.Remove(originalQ);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

    }
}
