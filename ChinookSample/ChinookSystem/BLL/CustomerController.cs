﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel; // for ODS
using ChinookSystem.Data.Entities;
using ChinookSystem.Data.POCOs;
using ChinookSystem.DAL;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class CustomerController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<RepresentativeCustomers> RepresentativeCustomers_Get(int employeeId)
        {
            // Setup transaction area
            using (var context = new ChinookContext())
            {
                var results = from x in context.Customers
                              where x.SupportRepId == employeeId
                              select new RepresentativeCustomers
                              {
                                  Name = x.LastName + ", " + x.FirstName,
                                  City = x.City,
                                  State = x.State,
                                  Phone = x.Phone,
                                  Email = x.Email
                              };
                return results.ToList();
            }
        }
    }
}
