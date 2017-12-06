using KlappAppen.Models.Entities;
using KlappAppen.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlappAppen.Models
{
    public class DBPersonsRepository
    {
        KlappAppContext context;

        public DBPersonsRepository(KlappAppContext context)
        {
            this.context = context;
        }

        public HomeMainContentVM[] GetAllPersons()
        {
            var ret = context.Persons
                .Select(o => new HomeMainContentVM
                {
                    PersonName = o.Name,
                    GiftItems = o.P2g.Select(g => new HomePersonGiftItemVM
                    {
                        GiftName = g.G.Gift,
                        GiftPrice = g.G.Price
                    }).ToArray()
                })
                .ToArray();

            return ret;
        }
    }
}
