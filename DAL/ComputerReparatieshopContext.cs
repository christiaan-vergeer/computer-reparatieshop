using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using computer_reparatieshop.Models;

namespace computer_reparatieshop.DAL
{
    public class ComputerReparatieshopContext :  DbContext
    {
        public ComputerReparatieshopContext() : base("raparaties")
        {

        }

        public DbSet<Reparatieopdrachten> Reparaties { get; set; }
    }
}