using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MegaStoreApp.Models
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Display(Name="Genre")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name="Total Sales")]
        public decimal TotalSold { get; set; }

        [Display(Name = "Genre Expert")]
        public string FullName { get; set; }
    }
}