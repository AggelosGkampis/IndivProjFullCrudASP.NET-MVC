using SkyDreaming.Models;
using SkyDreaming.Mycontext.Initializers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SkyDreaming.Mycontext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("Sindesmos")
        {
            Database.SetInitializer<ApplicationContext>(new MockupDbInitializer());
            Database.Initialize(false);
        }
        public DbSet<IGmodel> IGmodels { get; set; }

        public DbSet<Room> Rooms { get; set; }
    }
}