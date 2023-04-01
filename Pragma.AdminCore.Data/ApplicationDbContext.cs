using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pragma.AdminCore.Data.Models.Entities;

namespace Pragma.AdminCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Filter> Filter { get; set; }
        public DbSet<Record> Record { get; set; }
        public DbSet<TempRecord> TempRecord { get; set; }
        public DbSet<RecordPriceChanges> RecordPriceChanges { get; set; }

    }
}
