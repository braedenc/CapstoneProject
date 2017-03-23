using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vacay.Models
{
    public class PopularPlacesViewModel
    {
        public string Location { get; set; }
        public string City { get; set; }
        public string Post { get; set; }
        public IEnumerable<JournalPost> Posts { get; set; }
    }
}