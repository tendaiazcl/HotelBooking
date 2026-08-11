using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Persistence.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly HotelBookingDbContext _context;

    public HotelRepository(HotelBookingDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Hotel hotel)
    {
        await _context.Hotels.AddAsync(hotel);

        await _context.SaveChangesAsync();
    }
    public async Task<List<Hotel>> GetAllAsync()
   {
       return await _context.Hotels
          .AsNoTracking()
           .ToListAsync();
   }
   public async Task<Hotel?> GetByIdAsync(int id)
   {
       return await _context.Hotels
           .FirstOrDefaultAsync(h => h.Id == id);
   }
}