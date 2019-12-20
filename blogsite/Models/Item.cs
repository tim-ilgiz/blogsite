using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogsite.Models
{
    public class Item
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string LinkUrl { get; set; }

        public string Image { get; set; }

        public long ParentId { get; set; }
        public long Click { get; set; }
    }
}
