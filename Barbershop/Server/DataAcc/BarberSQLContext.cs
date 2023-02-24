using Barbershop.Server.DataAcc.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.Server.DataAcc
{
    public class BarberSQLContext : DbContext
    {
        public DbSet <BarberServModel> services { get; set; }
        public BarberSQLContext(DbContextOptions option) : base (option)
        {
            
        }
    }
}
