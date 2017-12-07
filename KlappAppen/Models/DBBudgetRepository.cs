using KlappAppen.Models.Entities;
using KlappAppen.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

            var budgetGiftList = JsonConvert.SerializeObject(ret);

            File.WriteAllText(@"C:\Users\Administrator\Desktop\Json.rtf", budgetGiftList);

            return ret;
        }

        //public HomeMainContentVM[] GetAllPersons()
        //{
        //    //var ret = context.Persons
        //        .Select(o => new HomeMainContentVM
        //        {
        //            PersonName = o.Name,
        //            GiftItems = o.P2g.Select(g => new HomePersonGiftItemVM
        //            {
        //                GiftName = g.G.Gift,
        //                GiftPrice = g.G.Price
        //            }).ToArray()
        //        })
        //        .ToArray();

        //    return ret;
        //}
    }
}
