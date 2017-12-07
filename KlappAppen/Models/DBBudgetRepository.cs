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


        public HomeGiftVM[] GetAllGifts()
        {
            var ret = klapp.Gifts
                .Select(g => new HomeGiftVM
                {
                    Name = g.Name,
                    Price = g.Price

                }).ToArray();


            var JSONgiftList = JsonConvert.SerializeObject(ret);

            File.WriteAllText(@"C:\Users\Administrator\Desktop\Json2.rtf", JSONgiftList);

            return ret;
        }

        public string GetList()
        {
            var list = klapp.Gifts
                .Select(g => new HomeMainContentVM
                {
                    Receiver = g.Receiver,
                    Name = g.Name,
                    Price = g.Price,
                    Id = g.Id

                }).ToArray();

            var giftList = JsonConvert.SerializeObject(list);

            return giftList;
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
