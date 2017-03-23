using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vacay.Models
{
    public class UserUpvote
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public int JournalPostId { get; set; }
        [ForeignKey("JournalPostId")]
        public JournalPost JournalPost { get; set; }

    }
}