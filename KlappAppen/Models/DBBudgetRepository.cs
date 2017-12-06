using KlappAppen.Models.Entities;
using KlappAppen.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlappAppen.Models
{
    public class DBBudgetRepository
    {

        private KlappAppContext klapp;

        public DBBudgetRepository(KlappAppContext klapp)
        {
            this.klapp = klapp;
        }


        public HomeSetBudgetVM[] GetAllBudgets()
        {
            var ret = klapp.Budgets
                .Select(b => new HomeSetBudgetVM
                {
                    Total = b.Total,
                    GiftItems = b.Gifts.Select(g => new HomeGiftVM
                    { 
                         Receiver = g.Receiver,
                         Name = g.Name,
                         Price = g.Price

                     }).ToArray()
                 })
                .ToArray();

            return ret;
        }


    }
}
