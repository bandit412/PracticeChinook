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
    [Table("Albums")]
    public class Album
    {
        // Key notation is optional if the SQL PrimaryKey end in ID or Id
        // Required if default if: entity is NOT Identity
        //                         PrimaryKey is compound

        // Properties can be fully implemented or auto-implemented
        // Property names should use SQL attribute name
        // Properties should be listed in the same order as SQL table
        //   attributes for ease of maintenance
        [Key]
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public int ReleaseYear { get; set; }
        public string ReleaseLabel { get; set; }

        // Create navigation properties for use by LINQ
        //   need to know the ForeignKey(s)
        // These properties will be of type virtual
        // There are 2 types of navigation properties:
        //   ICollection<T> point to "children"
        //   ParentName point to "parent"
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
