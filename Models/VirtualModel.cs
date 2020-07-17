using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace computer_reparatieshop.Models
{
    public class VirtualModel
    {
        public int Id { get; set; }
        public Reparatieopdrachten reparatieopdrachten { get; set; }
        public Customer Customer { get; set; }
    }

}