using System;
using System.Collections.Generic;

namespace KlappAppen.Models.Entities
{
    public partial class Budgets
    {
        public Budgets()
        {
            Gifts = new HashSet<Gifts>();
        }

        public int Id { get; set; }
        public int Total { get; set; }

        public ICollection<Gifts> Gifts { get; set; }
    }
}
