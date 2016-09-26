using System;
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
    // reference or point to the SQL table that this file maps
    [Table("Artists")]
    public class Artist
    {
        // Key notation is optional if the SQL PrimaryKey end in ID or Id
        // Required if default if: entity is NOT Identity
        //                         PrimaryKey is compound

        // Properties can be fully implemented or auto-implemented
        // Property names should use SQL attribute name
        // Properties should be listed in the same order as SQL table
        //   attributes for ease of maintenance
        [Key]
        public int ArtistId { get; set; }
        public string Name { get; set; }

        // Create navigation properties for use by LINQ
        // These properties will be of type virtual
        // There are 2 types of navigation properties:
        //   ICollection<T> point to "children"
        //   ParentName point to "parent"
        public virtual ICollection<Album> Albums { get; set; }
    }
}
