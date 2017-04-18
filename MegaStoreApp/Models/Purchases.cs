using System.ComponentModel.DataAnnotations;

namespace MegaStoreApp.Models
{
    public enum Rating
    {
        one = 1, two = 2, three = 3, four = 4, five = 5
    }


    public class Purchases
    {
        public int PurchasesID { get; set; }
        public int AlbumID { get; set; }
        public int CustomerID { get; set; }

        [DisplayFormat(NullDisplayText = "No Grade")]
        public Rating? Rating { get; set; }

        public virtual Album Album { get; set; }
        public virtual Customer Customer { get; set; }
    }
}