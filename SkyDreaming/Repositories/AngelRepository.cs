using SkyDreaming.Models;
using SkyDreaming.Mycontext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SkyDreaming.Repositories
{
    public class AngelRepository
    {
        ApplicationContext db;

        public AngelRepository(ApplicationContext context)
        {
            db = context;
        }

        public List<Angel> GetAll()
        {
            return db.Angels.ToList();
        }

        public List<Angel>GetAllWithRooms()
        {
            return db.Angels.Include(x => x.Room).ToList();
        }
        public Angel GetById(int? id)
        {
           var angel =  db.Angels.Find(id);
           return angel;
        }

        public void Add(Angel angel)
        {
            db.Entry(angel).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(Angel angel)
        {            
            db.Entry(angel).State = EntityState.Modified;
            db.SaveChanges();
        }
       public void Delete(Angel ang)
        {
            db.Entry(ang).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}