using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additonal Namespaces
using System.ComponentModel; //ODS
using ChinookSystem.Data.Entities;
using ChinookSystem.Data.POCOs;
using ChinookSystem.DAL;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class TrackController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Track> ListTracks()
        {
            using (var context = new ChinookContext())
            {
                // Return ALL records, and ALL attributes
                return context.Tracks.ToList();
            }
        }//eom

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Track GetTrack(int trackID)
        {
            using (var context = new ChinookContext())
            {
                // Return ONE record
                return context.Tracks.Find(trackID);
            }
        }//eom

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void InsertTrack(Track trackInfo)
        {
            using (var context = new ChinookContext())
            {
                // Any business rules
                if(trackInfo.UnitPrice > 1.0m)
                {
                    throw new Exception("Bob's your uncle");
                }
                // Any data refinements
                // Review of using the IIF
                // The Composer can be a NULL string; we do not wish
                //   to store an empty string
                trackInfo.Composer = string.IsNullOrEmpty(trackInfo.Composer) ?
                    null : trackInfo.Composer;

                // Add the instance of trackInfo to the database
                context.Tracks.Add(trackInfo);

                // Commit of the Add
                context.SaveChanges();
            }
        }//eom

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void UpdateTrack(Track trackInfo)
        {
            using (var context = new ChinookContext())
            {
                // Any business rules

                // Any data refinements
                // Review of using the IIF
                // The Composer can be a NULL string; we do not wish
                //   to store an empty string
                trackInfo.Composer = string.IsNullOrEmpty(trackInfo.Composer) ?
                    null : trackInfo.Composer;

                // Update the existing instance of trackInfo on the database
                context.Entry(trackInfo).State = System.Data.Entity.EntityState.Modified;

                // Commit the Transaction
                context.SaveChanges();
            }
        }//eom

        // The DeleteTrack is an overloaded method technique
        [DataObjectMethod(DataObjectMethodType.Delete,true)]
        public void DeleteTrack(Track trackInfo)
        {
            DeleteTrack(trackInfo.TrackId);
        }//eom

        public void DeleteTrack(int trackId)
        {
            using (var context = new ChinookContext())
            {
                // Any business rules

                // Do the DELETE
                // Find the existing record on the database
                var existing = context.Tracks.Find(trackId); // could also use GetTrack(trackId)
                // DELETE the record from the database
                context.Tracks.Remove(existing);
                // Commit the transaction
                context.SaveChanges();
            }
        }//eom

    }//eoc
}//eon
