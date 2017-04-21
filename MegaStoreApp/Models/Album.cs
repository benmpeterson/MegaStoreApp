using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaStoreApp.Models
{
    public class Album
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Album")]
        [Key]
        public int AlbumID { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Artist { get; set; }

        [StringLength(50, MinimumLength =1)]
        public string Title { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Genre { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public string AlbumArtLocation { get; set; }

        public virtual Genre GenreCategory { get; set; }
        public virtual ICollection<Purchases> Purchases { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}