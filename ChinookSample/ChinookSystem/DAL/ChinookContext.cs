﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using ChinookSystem.Data.Entities;
#endregion

namespace ChinookSystem.DAL
{
    // Class is internal for security purposes
    // Access is restricted to within the component library
    // Inherit DbContext for Entity Framework requires
    //   System.Data.Entity
    internal class ChinookContext:DbContext
    {
        // Pass the connection string name to the DbContext
        //   using :base()
        public ChinookContext():base("ChinookDB")
        {
            
        }

        // Create a DbSet for every Entity
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
        public DbSet<Track> Tracks { get; set; }
        
        
        
        
        
        

    }
}
