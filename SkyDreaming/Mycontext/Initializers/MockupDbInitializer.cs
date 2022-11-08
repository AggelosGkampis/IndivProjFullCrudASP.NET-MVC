using System;
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
            Room r1 = new Room() { Id = 1, Name = "Sturm face cream", Cost = 1000, UrlImage = "https://cdn11.bigcommerce.com/s-dwdwr5marw/images/stencil/960w/products/531/578/Face-Cream-1__08337.1592835694.386.513.jpg_c_1&_ga_2.33918375.722347298.1594023925-2071108408__41938.1594392042.jpg?c=1" };
            Room r2 = new Room() { Id = 2, Name = "Sturm night cream", Cost = 750, UrlImage = "https://cdn11.bigcommerce.com/s-dwdwr5marw/images/stencil/960w/products/2996/5377/GOOD-NIGHT-1__50175.1642752423.jpg?c=1" };
            Room r3 = new Room() { Id = 3, Name = "Hotel Gorilla's Nest", Cost = 800, UrlImage = "https://i.pinimg.com/originals/4f/b6/77/4fb677d43727f194e6bb0db98e3b9be0.jpg" };
            Room r4 = new Room() { Id = 4, Name = "Hotel Sunshine", Cost = 1200, UrlImage = "https://static.propertylogic.net/blog/1448297869/internationl_luxury_premium_bedroom.jpg" };
            Room r5 = new Room() { Id = 5, Name = "Hotel The Bachelor", Cost = 1069, UrlImage = "http://cdn.home-designing.com/wp-content/uploads/2014/09/bachelor-bedroom.jpeg" };
            Room r6 = new Room() { Id = 6, Name = "Saunt laurent Dress", Cost = 1050, UrlImage = "https://saint-laurent.dam.kering.com/m/7ac568fa83ad455d/Medium2-693962Y36UR1000_A.jpg?v=2" };
            Room r7 = new Room() { Id = 7, Name = "Volvo car", Cost = 600, UrlImage = "https://carwow-uk-wp-3.imgix.net/Volvo-XC40-white-scaled.jpg" };
            Room r8 = new Room() { Id = 8, Name = "Wedding Dress", Cost = 1750, UrlImage = "https://cdn.shopify.com/s/files/1/0584/8983/1574/products/GRACELOVESLACE.SHOP.WEDDING-DRESSES.MILA-01_1024x.jpg?v=1651479474" };
            Room r9 = new Room() { Id = 9, Name = "Dress Shoes", Cost = 900, UrlImage = "https://media.jimmychoo.com/image/upload/f_auto,q_auto:best,dpr_2.0,w_520,h_520,c_fit/ROWPROD_PRODUCT/images/original/ROMY85CGF_120011_SIDE_vg01.jpg" };
            Room r10 = new Room() { Id = 10, Name = "Iphone 14 pro", Cost = 1050, UrlImage = "https://techblog.gr/wp-content/uploads/2022/09/iphone-14-pro-iphone-14-pro-max-3.jpg" };

            context.Rooms.AddOrUpdate(r => r.Name, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10);
            context.SaveChanges();

            #endregion


            #region IGmodels Seeding
            IGmodel IGmodel1 = new IGmodel() { Id = 1, Name = "Tatiana", Height = 1.76, Kg = 66, HairColor = HairColor.LightBlonde, Age = 26, ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/81mckefMJHL.png" };
            IGmodel IGmodel2 = new IGmodel() { Id = 2, Name = "Vicky", Height = 1.72, Kg = 67, HairColor = HairColor.Black, Age = 22, ImageUrl = "https://i.pinimg.com/736x/b0/b2/7c/b0b27c6aba57362956a18e999cdd87ea.jpg" };
            IGmodel IGmodel3 = new IGmodel() { Id = 3, Name = "Victoria", Height = 1.68, Kg = 66, HairColor = HairColor.Brown, Age = 25, ImageUrl = "https://img.freepik.com/free-photo/beautiful-girl-stands-near-walll-with-leaves_8353-5377.jpg?w=740&t=st=1655211315~exp=1655211915~hmac=0ee49796cbd81cd01ce36009bf03faa9af91bb4ef5282d41754c9fbd6a375eff" };
            IGmodel IGmodel4 = new IGmodel() { Id = 4, Name = "Spydou", Height = 1.73, Kg = 69, HairColor = HairColor.Blonde, Age = 22, ImageUrl = "https://wallpapercave.com/wp/wp4997495.jpg" };
            IGmodel IGmodel5 = new IGmodel() { Id = 5, Name = "Helena", Height = 1.60, Kg = 52, HairColor = HairColor.Red, Age = 24, ImageUrl = "https://redheaddates.com/wp-content/uploads/2020/09/e9bcff20c68ae2e27e40335c745244370.jpg" };
            IGmodel IGmodel6 = new IGmodel() { Id = 6, Name = "Anastasia", Height = 1.67, Kg = 66, HairColor = HairColor.Black, Age = 29, ImageUrl = "https://cdn.thetealmango.com/wp-content/uploads/2022/02/Yael-Shelbia.jpg" };
            IGmodel IGmodel7 = new IGmodel() { Id = 7, Name = "Anjelina", Height = 1.69, Kg = 60, HairColor = HairColor.Blonde, Age = 27, ImageUrl = "https://cdn.thetealmango.com/wp-content/uploads/2021/07/IGmodelina.jpg" };
            IGmodel IGmodel8 = new IGmodel() { Id = 8, Name = "Nicky", Height = 1.75, Kg = 70, HairColor = HairColor.Pink, Age = 30, ImageUrl = "https://i.pinimg.com/originals/06/56/31/0656319d5b512d6138d8631c491d9bd3.jpg" };
            IGmodel IGmodel9 = new IGmodel() { Id = 9, Name = "Sonia", Height = 1.72, Kg = 66, HairColor = HairColor.Brown, Age = 26, ImageUrl = "https://i0.wp.com/www.hadviser.com/wp-content/uploads/2020/04/2-long-dark-brown-hair-CKUAfqUh4Pd.jpg?resize=1021%2C1245&ssl=1" };
            IGmodel IGmodel10 = new IGmodel() { Id = 10, Name = "Nicole", Height = 1.63, Kg = 56, HairColor = HairColor.LightBlonde, Age = 20, ImageUrl = "https://images.pexels.com/photos/3448813/pexels-photo-3448813.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500" };

            IGmodel1.Room = r1;
            IGmodel2.Room = r2;
            IGmodel3.Room = r3;
            IGmodel4.Room = r4;
            IGmodel5.Room = r5;
            IGmodel6.Room = r6;
            IGmodel7.Room = r7;
            IGmodel8.Room = r8;
            IGmodel9.Room = r9;
            IGmodel10.Room = r10;


            context.IGmodels.AddOrUpdate(a => a.Id, IGmodel1, IGmodel2, IGmodel3, IGmodel4, IGmodel5, IGmodel6, IGmodel7, IGmodel8, IGmodel9, IGmodel10);
            context.SaveChanges();
            #endregion


            base.Seed(context);
        }
    }
}