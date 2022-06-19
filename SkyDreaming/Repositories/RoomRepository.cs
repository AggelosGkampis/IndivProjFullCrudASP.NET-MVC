using SkyDreaming.Models;
using SkyDreaming.Mycontext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SkyDreaming.Repositories
{
    public class RoomRepository
    {
        ApplicationContext db;

        public RoomRepository(ApplicationContext context)
        {
            db = context;
        }

        public List<Room> GetAll()
        {
            return db.Rooms.ToList();
        }

        public List<Room> GetAllWithAngels()
        {
            return db.Rooms.Include(x => x.Angels).ToList();
        }
        public Room GetById(int? id)
        {
           var room =  db.Rooms.Find(id);
           return room;
        }

        public void Add(Room room)
        {
            db.Entry(room).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(Room room)
        {            
            db.Entry(room).State = EntityState.Modified;
            db.SaveChanges();
        }
       public void Delete(Room rom)
        {
            db.Entry(rom).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}