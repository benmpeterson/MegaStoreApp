using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MegaStoreApp.Models
{
    public class Customer : Person
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        public virtual ICollection<Purchases> Purchases { get; set; }
    }
}