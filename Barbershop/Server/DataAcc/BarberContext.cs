using Barbershop.Server.DataAcc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Barbershop.Server.DataAcc
{
    public class BarberContext : DbContext
    {
        public DbSet<BarberServModel> Services { get; set; }
        public BarberContext(DbContextOptions options): base(options)
        {

        }
    }
}
