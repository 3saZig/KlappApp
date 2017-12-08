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


        public string GetAllGifts()
        {
            var ret = klapp.Gifts
                .Select(g => new HomeGiftVM
                {
                    Name = g.Name,
                    Price = g.Price

                }).ToArray();


            var JSONgiftList = JsonConvert.SerializeObject(ret);

            File.WriteAllText(@"C:\Users\Administrator\Desktop\Json2.rtf", JSONgiftList);

            return JSONgiftList;
        }

        public string CreateBudget()
        {
            var ret = klapp.Budgets
                .Select(g => new HomeSetBudgetVM
                {
                    Total = g.Total

                }).ToArray();


            var JSONtotalBudget = JsonConvert.SerializeObject(ret);

            File.WriteAllText(@"C:\Users\Administrator\Desktop\Json2.rtf", JSONtotalBudget);

            return JSONtotalBudget;
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

        public string DeletePerson(int id)
        {
            var deletePerson = klapp.Gifts
                .SingleOrDefault(d => d.Id == id);
            if (deletePerson != null)
            {
                klapp.Gifts.Remove(deletePerson);
                klapp.SaveChanges();
            }

            var deleteId = JsonConvert.SerializeObject(klapp.Gifts);

            return deleteId;
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
