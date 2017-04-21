using MegaStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MegaStoreApp.DAL
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
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
            new Album{AlbumID=1050,Artist = "Kendrick Lamar",Title="Damn",Genre="Hip-Hop",Price=9.99M,AlbumArtLocation="~/Content/Images/kendrick.jpg"},
            new Album{AlbumID=4022,Artist = "Daft Punk", Title="RAM",Genre="Electronic",Price=9.99M,AlbumArtLocation="~/Content/Images/daftpunk.jpg"},
            new Album{AlbumID=4041,Artist = "Frankie Cosmos", Title="Next Thing",Genre="Indie Rock",Price=7.99M,AlbumArtLocation="~/Content/Images/frankiecosmos.jpg"},
            new Album{AlbumID=1045,Artist = "Frank Ocean", Title="Blonde",Genre="Hip-Hop",Price=9.99M,AlbumArtLocation="~/Content/Images/frankocean.jpg"},
            new Album{AlbumID=3141,Artist = "The Knife", Title="Silent Shout", Genre = "Electronic",Price=5.57M,AlbumArtLocation="~/Content/Images/theknife.jpg"},
            new Album{AlbumID=2021,Artist = "Kanye West", Title="The College Dropout", Genre = "Hip Hop",Price=9.99M,AlbumArtLocation="~/Content/Images/collegedropout.jpg"},
            new Album{AlbumID=2042,Artist = "Marvin Gaye",Title="What's Going On", Genre = "Soul" ,Price=9.99M,AlbumArtLocation="~/Content/Images/marvingaye.jpg"},
            new Album{AlbumID=3000,Artist = "Alex G",Title="Rules", Genre = "Indie Rock" ,Price=9.99M,AlbumArtLocation="~/Content/Images/rules.jpg"},
            new Album{AlbumID=7000,Artist = "RadioHead",Title="In Rainbows", Genre = "Electronic" ,Price=9.99M,AlbumArtLocation="~/Content/Images/radiohead.jpg"}
            };
            albums.ForEach(s => context.Albums.Add(s));
            context.SaveChanges();

            var purchases = new List<Purchases>
            {
            new Purchases{CustomerID=1,AlbumID=1050,Rating=Rating.Five},
            new Purchases{CustomerID=1,AlbumID=4022,Rating=Rating.Four},
            new Purchases{CustomerID=1,AlbumID=4041,Rating=Rating.Five},
            new Purchases{CustomerID=2,AlbumID=1045,Rating=Rating.Three},
            new Purchases{CustomerID=2,AlbumID=3141,Rating=Rating.Five},
            new Purchases{CustomerID=2,AlbumID=2021,Rating=Rating.Five},
            new Purchases{CustomerID=3,AlbumID=1050},
            new Purchases{CustomerID=4,AlbumID=1050,Rating=Rating.Three},
            new Purchases{CustomerID=4,AlbumID=4022,Rating=Rating.Five},
            new Purchases{CustomerID=5,AlbumID=4041,Rating=Rating.Two},
            new Purchases{CustomerID=6,AlbumID=1045},
            new Purchases{CustomerID=7,AlbumID=3141,Rating=Rating.Five},
            };
            purchases.ForEach(s => context.Purchases.Add(s));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee { FirstMidName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Employee { FirstMidName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Employee { FirstMidName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Employee { FirstMidName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Employee { FirstMidName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };
            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            var genres = new List<Genre>
            {
                new Genre { Name = "Hip-Hop",     TotalSold = 350000,                    
                    FullName  = employees.Single( i => i.LastName == "Abercrombie").FullName },
                new Genre { Name = "Indie Rock", TotalSold = 10000,                    
                    FullName = employees.Single( i => i.LastName == "Fakhouri").FullName },
                new Genre { Name = "Electronic", TotalSold = 20000,                    
                    FullName = employees.Single( i => i.LastName == "Harui").FullName },
                new Genre { Name = "Soul",   TotalSold = 5000,                    
                    FullName = employees.Single( i => i.LastName == "Kapoor").FullName }
            };
            genres.ForEach(s => context.Genres.Add(s));
            context.SaveChanges();

            //Another way to add Purchases, less clean but more control
            //var purchase = new List<Purchases>
            //{
            //    new Purchases {
            //        CustomerID = customers.Single(s => s.LastName == "Alexander").CustomerID,
            //        AlbumID = albums.Single(c => c.Title == "Blonde" ).AlbumID,
            //        Rating = Rating.five
            //    },
            //     new Purchases {
            //        CustomerID = customers.Single(s => s.LastName == "Alexander").CustomerID,
            //        AlbumID = albums.Single(c => c.Title == "Blonde" ).AlbumID,
            //        Rating = Rating.three
            //     },

            //     new Purchases {
            //         CustomerID = customers.Single(s => s.LastName == "Alonso").CustomerID,
            //        AlbumID = albums.Single(c => c.Title == "Blonde" ).AlbumID,
            //        Rating = Rating.four
            //     },
            //     new Purchases {
            //         CustomerID = customers.Single(s => s.LastName == "Alonso").CustomerID,
            //        AlbumID = albums.Single(c => c.Title == "Blonde" ).AlbumID,
            //        Rating = Rating.two
            //     },
            //     new Purchases {
            //        CustomerID = customers.Single(s => s.LastName == "Alonso").CustomerID,
            //        AlbumID = albums.Single(c => c.Title == "Blonde" ).AlbumID,
            //        Rating = Rating.five
            //     },
            //     new Purchases {
            //        CustomerID = customers.Single(s => s.LastName == "Anand").CustomerID,
            //        AlbumID = albums.Single(c => c.Title == "RAM" ).AlbumID
            //     },
            //     new Purchases {
            //        CustomerID = customers.Single(s => s.LastName == "Anand").CustomerID,
            //        AlbumID = albums.Single(c => c.Title == "Blonde").AlbumID,
            //        Rating = Rating.four
            //     },
            //    new Purchases {
            //        CustomerID = customers.Single(s => s.LastName == "Barzdukas").CustomerID,
            //        AlbumID = albums.Single(c => c.Title == "Blonde").AlbumID,
            //        Rating = Rating.two
            //     },
            //     new Purchases {
            //        CustomerID = customers.Single(s => s.LastName == "Li").CustomerID,
            //        AlbumID = albums.Single(c => c.Title == "Blonde").AlbumID,
            //        Rating = Rating.three
            //     },
            //     new Purchases {
            //        CustomerID = customers.Single(s => s.LastName == "Justice").CustomerID,
            //        AlbumID = albums.Single(c => c.Title == "Blonde").AlbumID,
            //        Rating = Rating.five
            //     }
            //};

            //purchase.ForEach(s => context.Purchases.Add(s));
            //context.SaveChanges();
        }
    }
}