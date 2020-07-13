using computer_reparatieshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace computer_reparatieshop.ViewModels
{
    public class RepairOrderVM
    {
        public Reparatieopdrachten RepairOrder { get; set; }
        public List<Customer> Customers { get; set; }
        public int CustomerId { get; set; }
    }
}