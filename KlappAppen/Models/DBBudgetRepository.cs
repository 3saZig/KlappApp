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

        private KlappAppContext context;

        public DBBudgetRepository(KlappAppContext context)
        {
            this.context = context;
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
            var ret = context.Gifts
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


        public HomeMainContentVM[] GetGifts(int budgetId)
        {
            return context.Gifts
                .Where(g => g.BudgetId == budgetId)
                .Select(g => new HomeMainContentVM
                {
                    Receiver = g.Receiver,
                    Name = g.Name,
                    Price = g.Price,
                    Id = g.Id

                }).ToArray();
        }

        public string GetBudgetTotalAmountFromId(int budgetId)
        {
            int tmp = 1;

            var totalBudget = context.Budgets
                .SingleOrDefault(b => b.Id == budgetId);

            if (totalBudget != null)
                tmp = totalBudget.Total;

            var totalBudget2 = JsonConvert.SerializeObject(tmp);

            return totalBudget2;
        }


        public string DeletePerson(int id)
        {
            var deletePerson = context.Gifts
                .SingleOrDefault(d => d.Id == id);
            if (deletePerson != null)
            {
                context.Gifts.Remove(deletePerson);
                context.SaveChanges();
            }

            var deleteId = JsonConvert.SerializeObject(context.Gifts.Where(o => o.BudgetId == deletePerson.BudgetId));

            return deleteId;
        }

        public Gift[] EditPerson(int id, string receiver, string gift, int price)
        {
            var giftToEdit = context.Gifts
                .SingleOrDefault(e => e.Id == id);
            if (giftToEdit != null)
            {
                //editPerson.Id = id;
                giftToEdit.Receiver = receiver;
                giftToEdit.Name = gift;
                giftToEdit.Price = price;
                context.SaveChanges();
            }

            return context.Gifts
                .Where(o => o.BudgetId == giftToEdit.BudgetId)
                .ToArray();
        }


        public string AddPerson(HomeMainContentVM homeMainVM)
        {
            context.Gifts.Add(new Gift
            {
                Receiver = homeMainVM.Receiver,
                Name = homeMainVM.Name,
                Price = homeMainVM.Price,
                BudgetId = homeMainVM.Id
            });
            context.SaveChanges();
            //.Where(b => b.Id == budgetId)

            var updatedList = JsonConvert.SerializeObject(context.Gifts);
            return updatedList;
        }


        //=================================================================================================
        //BUDGET
        //=================================================================================================


        //anropas i homecontroller/getbudget
        public BudgetsVM[] GetBudgets(string userId)
        {
            return context.Budgets
                .Where(b => b.AspNetUsersId == userId)
                .Select(b => new BudgetsVM
                {
                    BudgetName = b.BudgetName,
                    Id = b.Id,
                    Total = b.Total,
                }
                ).ToArray();
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
            context.Budgets
                .Add(new Budget   //Lägga till 
                {
                    BudgetName = budgetVM.BudgetName,
                    AspNetUsersId = userId,
                    Total = budgetVM.Total
                });

            context.SaveChanges();

            var newBudget = JsonConvert.SerializeObject(context.Budgets);
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
