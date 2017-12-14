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

        public string UserExist(string username)
        {
            return null;
        }



        //=================================================================================================
        //THE CHART
        //=================================================================================================


        //anropas i homecontroller/createchart
        public string GetAllGifts()
        {
            var ret = klapp.Gifts
                .Select(g => new HomeGiftVM
                {
                    Name = g.Name,
                    Price = g.Price

                }).ToArray();


            var JSONgiftList = JsonConvert.SerializeObject(ret);
            return JSONgiftList;
        }


        //=================================================================================================
        //KLAPPLISTAN
        //=================================================================================================


        public string GetGifts(int budgetId)
        {

            var list = klapp.Gifts
                .Where(g => g.BudgetId == budgetId)
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

        public string EditPerson(int id, string receiver, string gift, int price)
        {
            var editPerson = klapp.Gifts
                .SingleOrDefault(e => e.Id == id);
            if (editPerson != null)
            {
                //editPerson.Id = id;
                editPerson.Receiver = receiver;
                editPerson.Name = gift;
                editPerson.Price = price;
                klapp.SaveChanges();
            }

            var editId = JsonConvert.SerializeObject(klapp.Gifts);
            return editId;
        }


        public string AddPerson(HomeMainContentVM homeMainVM)
        {
            klapp.Gifts.Add(new Gift
            {
                Receiver = homeMainVM.Receiver,
                Name = homeMainVM.Name,
                Price = homeMainVM.Price,
                BudgetId = homeMainVM.BudgetId
            });
            klapp.SaveChanges();

            var updatedList = JsonConvert.SerializeObject(klapp.Gifts);
            return updatedList;
        }


        //=================================================================================================
        //BUDGET
        //=================================================================================================


        //anropas i homecontroller/getbudget
        public string GetBudgets(string userId)
        {
            var list = klapp.Budgets
                .Where(b => b.AspNetUsersId == userId)
                .Select(b => new BudgetsVM
                {
                    BudgetName = b.BudgetName,
                    Id = b.Id,
                    Total = b.Total,
                }
                ).ToArray();

            var JSONtotalBudget = JsonConvert.SerializeObject(list);
            return JSONtotalBudget;
        }

        //******KAN DET HÄR VARA NÅGONTING? HÄMTAR KLAPPARNA FRÅN EN SPECIFIK BUDGET? OCH ATT DET BUDGET-ID VI
        //SKICKAR IN HAR VI PLOCKAT UT FRÅN VÅR DROP-DOWN? getBudgetIdFromSelect PÅ JAVASIDAN?
        //public string GetGiftsFromSelectedBudget(HomeMainContentVM homeMainVM, int budgetID)
        //{
        //    var klapplistaFranBudget = klapp.Gifts
        //        .Where(b => b.Id == budgetID)
        //        .Select(b => new Gift
        //        {
        //            Receiver = homeMainVM.Receiver,
        //            Name = homeMainVM.Name,
        //            Price = homeMainVM.Price,
        //            BudgetId = homeMainVM.BudgetId
        //        }
        //        ).ToArray();

        //    var JSONklapplistaFranValdBudget = JsonConvert.SerializeObject(klapplistaFranBudget);
        //    return JSONklapplistaFranValdBudget;
        //}


        public string AddNewBudget(BudgetsVM budgetVM, string userId)
        {
            klapp.Budgets
                .Add(new Budget   //Lägga till 
                {
                    BudgetName = budgetVM.BudgetName,
                    AspNetUsersId = userId,
                    Total = budgetVM.Total
                });

            klapp.SaveChanges();

            var newBudget = JsonConvert.SerializeObject(klapp.Budgets);
            return newBudget;
        }


        //=================================================================================================
        //GRAVEYARD
        //=================================================================================================


        //public string SumGifts()
        //{
        //    var list = klapp.Gifts
        //       .Select(g => new HomeMainContentVM
        //       {

        //           Price = g.Price,


        //       }).ToArray();
        //}

        //File.WriteAllText(@"C:\Users\Administrator\Desktop\Json2.rtf", JSONgiftList);


        //public string ChangeBudget(int id, int total)
        //{
        //    var changeBudget = klapp.Budgets
        //        .FirstOrDefault(b => b.Id == id);
        //    if (changeBudget != null)
        //    {
        //        changeBudget.Total = total;   
        //        klapp.SaveChanges();
        //    }


        //    var newBudget = JsonConvert.SerializeObject(klapp.Budgets);
        //    return newBudget;
        //}
    }
}
