using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FriendData.Models
{
    public enum List
    {
        Gomez,
        Gallardo,
        Gimenez,
        Gago,
        Gutierrez,

    }



    public class PERSONALSTUFFS
    {
        [Key]
        public int FriendID { get; set; }
        [Required]
        public int Name { get; set; }
        [Required]
        public int Email { get; set; }

        [DataType(DataType.Date)]
        public int Birthday { get; set; }

        public List list { get; set; }

    }
}