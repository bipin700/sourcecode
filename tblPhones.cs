using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class tblPhones
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long id { get; set; }
        public string Phone { get; set; }
        public string PhoneType { get; set; }
        public long FriendId { get; set; }
        public int AreaCode { get; set; }
    }
}