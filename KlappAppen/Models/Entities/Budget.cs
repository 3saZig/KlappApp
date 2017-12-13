using System;
using System.Collections.Generic;

namespace KlappAppen.Models.Entities
{
    public partial class Budget
    {
        public Budget()
        {
            Gift = new HashSet<Gift>();
        }

        public int Id { get; set; }
        public int Total { get; set; }
        public string AspNetUsersId { get; set; }
        public string BudgetName { get; set; }

        public ICollection<Gift> Gift { get; set; }
    }
}
