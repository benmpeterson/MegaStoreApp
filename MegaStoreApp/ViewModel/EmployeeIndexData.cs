using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MegaStoreApp.Models;

namespace MegaStoreApp.ViewModel
{
    public class EmployeeIndexData
    {
        public IList<Employee> Instructors { get; set; }
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Purchases> Purchases { get; set; }
    }
}