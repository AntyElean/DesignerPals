﻿using DesignerPals.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DesignerPals.Infrastructure.GenericRepository;

namespace DesignerPals.Infrastructure
{
    public class GenericRepository : IGenericRepository
    {
        private ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        //generic query method
        public IQueryable<T> Query<T>() where T : class
        {
            return _db.Set<T>().AsQueryable();
        }

        //add new entity
        public void Add<T>(T entityToCreate) where T : class
        {
            _db.Set<T>().Add(entityToCreate);
            this.SaveChanges();
        }

        //update existing entity
        public void Update<T>(T entityToUpdate) where T : class
        {
            _db.Set<T>().Update(entityToUpdate);
            this.SaveChanges();
        }

        //delete existing entity
        public void Delete<T>(T entityToDelete) where T : class
        {
            _db.Set<T>().Remove(entityToDelete);
            this.SaveChanges();
        }

        // Execute stored procedures and dynamic sql
        public IQueryable<T> SqlQuery<T>(string sql, params object[] parameters) where T : class
        {
            return _db.Set<T>().FromSql(sql, parameters);
        }

        //save changes to database
        public void SaveChanges()
        {
            _db.SaveChanges();
        }


        public void Dispose()
        {
            _db.Dispose();
        }

        public interface IGenericRepository
        {
            void Add<T>(T entityToCreate) where T : class;
            void Delete<T>(T entityToDelete) where T : class;
            void Dispose();
            IQueryable<T> Query<T>() where T : class;
            void SaveChanges();
            IQueryable<T> SqlQuery<T>(string sql, params object[] parameters) where T : class;
            void Update<T>(T entityToUpdate) where T : class;
        }
    }
}