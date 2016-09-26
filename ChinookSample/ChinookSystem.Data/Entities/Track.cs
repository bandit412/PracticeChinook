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
    [Table("Tracks")]
    public class Track
    {
        // Key notation is optional if the SQL PrimaryKey end in ID or Id
        // Required if default if: entity is NOT Identity
        //                         PrimaryKey is compound

        // Properties can be fully implemented or auto-implemented
        // Property names should use SQL attribute name
        // Properties should be listed in the same order as SQL table
        //   attributes for ease of maintenance
        [Key]
        public int TrackId { get; set; }
        public string name { get; set; }
        public int? AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int? GenreId { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual MediaType MediaTypes { get; set; }
        public virtual Album Albums { get; set; }
    }
}
