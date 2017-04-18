using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MegaStoreApp.Models;
using MegaStoreApp.DAL;
using ContosoUniversity.DAL;

namespace MegaStoreApp.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var customers = new List<Customer>
            {
            new Customer{FirstMidName="Carson",LastName="Alexander",CreationDate=DateTime.Parse("2005-09-01")},
            new Customer{FirstMidName="Meredith",LastName="Alonso",CreationDate=DateTime.Parse("2002-09-01")},
            new Customer{FirstMidName="Arturo",LastName="Anand",CreationDate=DateTime.Parse("2003-09-01")},
            new Customer{FirstMidName="Gytis",LastName="Barzdukas",CreationDate=DateTime.Parse("2002-09-01")},
            new Customer{FirstMidName="Yan",LastName="Li",CreationDate=DateTime.Parse("2002-09-01")},
            new Customer{FirstMidName="Peggy",LastName="Justice",CreationDate=DateTime.Parse("2001-09-01")},
            new Customer{FirstMidName="Laura",LastName="Norman",CreationDate=DateTime.Parse("2003-09-01")},
            new Customer{FirstMidName="Nino",LastName="Olivetto",CreationDate=DateTime.Parse("2005-09-01")}
            };

            customers.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();
            var albums = new List<Album>
            {
            new Album{AlbumID=1050,Artist = "Kendrick Lamar",Title="Damn",Price=9.99M,},
            new Album{AlbumID=4022,Artist = "Daft Punk", Title="RAM",Price=15.00M,},
            new Album{AlbumID=4041,Artist = "Frankie Cosmos", Title="Next Thing",Price=7.99M,},
            new Album{AlbumID=1045,Artist = "Frank Ocean", Title="Blonde",Price=8.99M,},
            new Album{AlbumID=3141,Artist = "The Knife", Title="Silent Shout",Price=5.57M,},
            new Album{AlbumID=2021,Artist = "Kanye West", Title="The College Dropout",Price=3.99M,},
            new Album{AlbumID=2042,Artist = "Marvin Gaye",Title="What's Going On",Price=9.99M,}
            };
            albums.ForEach(s => context.Albums.Add(s));
            context.SaveChanges();

            var purchases = new List<Purchases>
            {
            new Purchases{CustomerID=1,AlbumID=1050,Rating=Rating.five},
            new Purchases{CustomerID=1,AlbumID=4022,Rating=Rating.four},
            new Purchases{CustomerID=1,AlbumID=4041,Rating=Rating.five},
            new Purchases{CustomerID=2,AlbumID=1045,Rating=Rating.three},
            new Purchases{CustomerID=2,AlbumID=3141,Rating=Rating.five},
            new Purchases{CustomerID=2,AlbumID=2021,Rating=Rating.five},
            new Purchases{CustomerID=3,AlbumID=1050},
            new Purchases{CustomerID=4,AlbumID=1050,Rating=Rating.three},
            new Purchases{CustomerID=4,AlbumID=4022,Rating=Rating.five},
            new Purchases{CustomerID=5,AlbumID=4041,Rating=Rating.two},
            new Purchases{CustomerID=6,AlbumID=1045},
            new Purchases{CustomerID=7,AlbumID=3141,Rating=Rating.five},
            };
            purchases.ForEach(s => context.Purchases.Add(s));
            context.SaveChanges();
        }
    }
}