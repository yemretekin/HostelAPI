using Hostel.Entities;
using Microsoft.EntityFrameworkCore;
namespace Hostel.DataAccess
{
    public class HostelDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server = DESKTOP-7JITH0C; database=HostelDb; uid=sa;pwd=qnyy3c3c;");
        }

        public DbSet<HostelModel> Hostels { get; set; }
    }
}