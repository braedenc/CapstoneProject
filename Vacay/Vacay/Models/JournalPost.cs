using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vacay.Models
{
    public class JournalPost
    {
        [Key]
        public int ID { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Username { get; set; }
        public string Post { get; set; }
    }
}