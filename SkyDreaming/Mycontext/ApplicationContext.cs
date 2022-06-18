using SkyDreaming.Models;
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

        }
        public DbSet<Angel> Angels { get; set; }

        public DbSet<Room> Rooms { get; set; }
    }
}