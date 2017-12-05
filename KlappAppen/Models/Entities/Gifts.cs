using System;
using System.Collections.Generic;

namespace KlappAppen.Models.Entities
{
    public partial class Gifts
    {
        public Gifts()
        {
            P2g = new HashSet<P2g>();
        }

        public int Id { get; set; }
        public string Gift { get; set; }
        public int Price { get; set; }

        public ICollection<P2g> P2g { get; set; }
    }
}
