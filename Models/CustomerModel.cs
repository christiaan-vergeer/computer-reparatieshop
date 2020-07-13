using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace computer_reparatieshop.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int TotalOrderCount { get; set; }
        public int OpenOrderCount { get; set; }
    }
}