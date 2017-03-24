using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vacay.Models
{
    public class PostAndLikes
    {
        public JournalPost Post { get; set; }
        public List<UserUpvote> ListOfUpvotes{ get; set; }

    }
}