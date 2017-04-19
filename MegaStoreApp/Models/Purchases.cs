using System.ComponentModel.DataAnnotations;

namespace MegaStoreApp.Models
{
    public enum Rating
    {
        One = 1, Two = 2, Three = 3, Four = 4, Five = 5
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