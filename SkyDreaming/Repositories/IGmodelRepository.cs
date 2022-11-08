using SkyDreaming.Models;
using SkyDreaming.Mycontext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SkyDreaming.Repositories
{
    public class IGmodelRepository
    {
        ApplicationContext db;

        public IGmodelRepository(ApplicationContext context)
        {
            db = context;
        }

        public List<IGmodel> GetAll()
        {
            return db.IGmodels.ToList();
        }

        public List<IGmodel>GetAllWithRooms()
        {
            return db.IGmodels.Include(x => x.Room).ToList();
        }
        public IGmodel GetById(int? id)
        {
           var IGmodel =  db.IGmodels.Find(id);
           return IGmodel;
        }

        public void Add(IGmodel IGmodel)
        {
            db.Entry(IGmodel).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(IGmodel IGmodel)
        {            
            db.Entry(IGmodel).State = EntityState.Modified;
            db.SaveChanges();
        }
       public void Delete(IGmodel ang)
        {
            db.Entry(ang).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}