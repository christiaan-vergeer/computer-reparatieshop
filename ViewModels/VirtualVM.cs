using computer_reparatieshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace computer_reparatieshop.ViewModels
{
    public class VirtualVM
    {
        //public VirtualModel VirtualModel { get; set; }

        public Customer Customer { get; set; }

        public Reparatieopdrachten Reparatieopdrachten { get; set; }

    }
}