using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class AssignmentContext: DbContext
    {
        public AssignmentContext() : base("con") { }
        public DbSet<tblFriends> Frnds { get; set; }
        public DbSet<tblPhones> Phone { get; set; }
    }
}