using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vacay.Models
{
    public class PopularPlacesViewModel
    {
        public IEnumerable<PostAndLikes> Posts { get; set; }
        public int Zero { get; set; }
    }
}