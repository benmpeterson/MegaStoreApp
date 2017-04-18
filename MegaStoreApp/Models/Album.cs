using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaStoreApp.Models
{
    public class Album
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Album")]
        public int AlbumID { get; set; }

        [StringLength(50, MinimumLength =1)]
        public string Title { get; set; }
       
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int GenreID { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual ICollection<Purchases> Purchases { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}