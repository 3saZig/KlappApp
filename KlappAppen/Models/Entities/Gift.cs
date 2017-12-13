using System;
using System.Collections.Generic;

namespace KlappAppen.Models.Entities
{
    public partial class Gift
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Receiver { get; set; }
        public string Name { get; set; }
        public int BudgetId { get; set; }

        public Budget Budget { get; set; }
    }
}
