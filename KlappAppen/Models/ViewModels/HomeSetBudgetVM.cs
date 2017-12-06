using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlappAppen.Models.ViewModels
{
    public class HomeSetBudgetVM
    {
        public int Total { get; set; }
        public int MyProperty { get; set; }
        public HomeGiftVM[] GiftItems { get; internal set; }
    }
}
