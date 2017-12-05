using KlappAppen.Models.Entities;
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

        public Persons[] GetAllPersons()
        {
            return context.Persons.ToArray();
        }
    }
}
