using System;
using System.Collections.Generic;

namespace KlappAppen.Models.Entities
{
    public partial class P2g
    {
        public int Pid { get; set; }
        public int Gid { get; set; }

        public Gifts G { get; set; }
        public Persons P { get; set; }
    }
}
