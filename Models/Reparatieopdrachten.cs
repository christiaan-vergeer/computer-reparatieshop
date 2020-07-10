using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace computer_reparatieshop.Models
{
    public class Reparatieopdrachten
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public Customer Customer { get; set; }
    }


    public enum Status
    {
        Pending,
        Underway,
        [Display(Name = "Waiting for parts")]
        WaitingForParts,
        Done
    }
}