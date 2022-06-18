using SkyDreaming.Models;
using SkyDreaming.Mycontext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}