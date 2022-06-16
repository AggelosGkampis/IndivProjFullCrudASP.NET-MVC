using SkyDreaming.Models;
using SkyDreaming.Mycontext;
using System;
using System.Collections.Generic;
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
    }
}