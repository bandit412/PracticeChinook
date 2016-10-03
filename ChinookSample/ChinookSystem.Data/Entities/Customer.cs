﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace ChinookSystem.Data.Entities
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        // The [ForeignKey] annotation has to be specified as the
        //   foreign key is named differently from the parent table.
        // This also matches the navigation property
        [ForeignKey("Employee")]
        public int SupportRepId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
