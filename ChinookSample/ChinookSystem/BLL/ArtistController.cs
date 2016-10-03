using System;
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
    public class ArtistController
    {
        // Dump the entire Artist entity
        // This will use Entity Framework access
        // Entity classes will be used to define the data
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Artist> Artist_ListAll()
        {
            // Setup transaction area
            using (var context = new ChinookContext())
            {
                return context.Artists.ToList();
            }
        }

        // Report a DataSet containing data from multiple entitie
        // This will use LINQ to Entity access
        // POCO classes will be used to define the data
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbum> ArtistAlbums_Get(int year)
        {
            // Setup transaction area
            using (var context = new ChinookContext())
            {
                // When you bring your query from LinqPad to your
                //   your program you MUST change the reference(s)
                //   to the data source
                // You may also need to change your navigation
                //   referencing use in LinqPad to the
                //   navigation properties you stated in the
                //   Entity class definitions

                // This will stage the LINQ query, not execute
                var results = from x in context.Albums
                              where x.ReleaseYear == year
                              orderby x.Artist.Name, x.Title
                              select new ArtistAlbum
                              {
                                  // Name and Title are POCO class property names
                                  Name = x.Artist.Name,
                                  Title = x.Title
                              };
                // The foolowing requires the query data in memory
                //   .ToList()
                // At this poin the query will actuall execute
                return results.ToList();
            }
        }
    }
}
