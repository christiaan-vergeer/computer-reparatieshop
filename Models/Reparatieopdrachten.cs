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
        
        public string name { get; set; }

        [DataType(DataType.Date)]
        public DateTime startdate { get; set; }
        [DataType(DataType.Date)]
        public DateTime enddate { get; set; }
        public status status { get; set; }


    }

    public enum status
    {
        Pending,
        Underway,
        [Display(Name ="Waiting for parts")]
        Waitingforparts,
        Done
    }
}