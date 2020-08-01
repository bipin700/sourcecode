using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class tblFriends
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string DOB { get; set; }
        public int CountryCode { get; set; }
        public long FriendId { get; set; }
    }
}