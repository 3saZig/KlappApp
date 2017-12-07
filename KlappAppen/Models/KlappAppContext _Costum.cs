using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KlappAppen.Models.Entities
{
    public partial class KlappAppContext
    {
        public KlappAppContext(DbContextOptions<KlappAppContext> options) : base(options)
        {

        }
    }
}
