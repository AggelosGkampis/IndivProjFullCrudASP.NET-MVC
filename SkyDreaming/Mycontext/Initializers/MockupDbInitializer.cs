﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SkyDreaming.Models;
using System.Data.Entity.Migrations;
using SkyDreaming.Models.Enums;

namespace SkyDreaming.Mycontext.Initializers
{
    public class MockupDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {

            #region Rooms Seeding
            Room r1 = new Room() { Id = 1, Name = "Salt and Caramel", Cost = 1000, UrlImage = "https://www.travelplusstyle.com/wp-content/uploads/2016/01/sonevajani-1880.jpg" };
            Room r2 = new Room() { Id = 2, Name = "Spooky Pooky", Cost = 750, UrlImage = "https://www.smartertravel.com/wp-content/uploads/2018/06/Belmond-Hotel-Caruso-in-Ravello-Italy.jpg" };
            Room r3 = new Room() { Id = 3, Name = "Eye Food", Cost = 800, UrlImage = "https://www.sanmarco.gr/wp-content/uploads/2016/11/homepage-slide-5483.jpg" };

            context.Rooms.AddOrUpdate(r => r.Name, r1, r2, r3);
            context.SaveChanges();

            #endregion


            #region Angels Seeding
            Angel angel1 = new Angel() { Id = 1, Name = "Thotiana", Height = 1.70, Kg = 66, HairColor = HairColor.LightBlonde, Age = 26, ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/81mckefMJHL.png" };
            Angel angel2 = new Angel() { Id = 2, Name = "Vicky", Height = 1.72, Kg = 67, HairColor = HairColor.Black, Age = 22, ImageUrl = "https://i.pinimg.com/736x/b0/b2/7c/b0b27c6aba57362956a18e999cdd87ea.jpg" };
            Angel angel3 = new Angel() { Id = 3, Name = "Victoria", Height = 1.68, Kg = 66, HairColor = HairColor.Brown, Age = 25, ImageUrl = "https://img.freepik.com/free-photo/beautiful-girl-stands-near-walll-with-leaves_8353-5377.jpg?w=740&t=st=1655211315~exp=1655211915~hmac=0ee49796cbd81cd01ce36009bf03faa9af91bb4ef5282d41754c9fbd6a375eff" };

            angel1.Room = r1;
            angel2.Room = r2;
            angel3.Room = r3;


            context.Angels.AddOrUpdate(a => a.Id, angel1, angel2, angel3);
            context.SaveChanges();
            #endregion


            base.Seed(context);
        }
    }
}