using SkyDreaming.Models;
using SkyDreaming.Mycontext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SkyDreaming.Repositories
{
    public class productRepository
    {
        ApplicationContext db;

        public productRepository(ApplicationContext context)
        {
            db = context;
        }

        public List<product> GetAll()
        {
            return db.products.ToList();
        }

        public List<product> GetAllWithIGmodels()
        {
            return db.products.Include(x => x.IGmodels).ToList();
        }
        public product GetById(int? id)
        {
           var product =  db.products.Find(id);
           return product;
        }
        public product GetByIdWithIGmodels(int? id)
        {
            var product = GetAllWithIGmodels().Find(x => x.Id == id);
            return product;
        }

        public void Add(product product)
        {
            db.Entry(product).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(product product)
        {            
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }
       public void Delete(product rom)
        {
            db.Entry(rom).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}