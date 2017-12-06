using KlappAppen.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlappAppen.Models.ViewModels
{
    public class HomeMainContentVM
    {
        public string PersonName { get; set; }
        public HomePersonGiftItemVM[] GiftItems { get; set; }
    }

    public class HomePersonGiftItemVM
    {
        public string GiftName { get; set; }
        public decimal GiftPrice { get; set; }
    }

    //Doughnut
}
