using Barbershop.Server.DataAcc.Models;
using Barbershop.Shared;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.Server.DataAcc
{
    public class BarberRepo
    {
        private readonly  BarberContext _context;
        public BarberRepo(BarberContext context)
        {
            _context = context; 
        }
        public async Task<List<BarberServDto>>  GetAllAsync() {
        
            List<BarberServModel> Allservs = await _context.Services.ToListAsync();
            return Allservs.Select(selector => new BarberServDto
            {

                Klippning = selector.Klippning,
                Tid = selector.Tid,
                Pris = selector.Pris
            }).ToList();

        
        }
        public async Task<IResult> Addserv(BarberServDto NewServ)
        {
           await _context.Services.AddAsync(new BarberServModel
            {
                Klippning = NewServ.Klippning,
                Tid = NewServ.Tid,
                Pris = NewServ.Pris

            });
            await _context.SaveChangesAsync();  
            return Results.Ok();
        }
        public async Task<IResult> Updateserv(BarberServDto Updateserv)
        {
            _context.Services.Update(new BarberServModel
            {
                Klippning = Updateserv.Klippning,
                Tid = Updateserv.Tid,
                Pris = Updateserv.Pris

            });
            await _context.SaveChangesAsync();  
            return Results.Ok();    
        }
        public async Task<IResult> Deleteserv(int id)
        {
            _context.Services.Remove(new BarberServModel
            {
                Id =id

            });
            await _context.SaveChangesAsync();  
           return Results.Ok();
        }
    }

}
