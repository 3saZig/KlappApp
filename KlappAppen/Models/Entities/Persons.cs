using System;
using System.Collections.Generic;

namespace KlappAppen.Models.Entities
{
    public partial class Persons
    {
        public Persons()
        {
            P2g = new HashSet<P2g>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<P2g> P2g { get; set; }
    }
}
