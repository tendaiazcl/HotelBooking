using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Persistence.Repositories;

public class RoomTypeRepository : IRoomTypeRepository
{
    private readonly HotelBookingDbContext _context;

    public RoomTypeRepository(HotelBookingDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(RoomType roomType)
    {
        await _context.RoomTypes.AddAsync(roomType);

        await _context.SaveChangesAsync();
    }

    public async Task<List<RoomType>> GetAllAsync()
    {
        return await _context.RoomTypes
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<RoomType?> GetByIdAsync(int id)
    {
        return await _context.RoomTypes
            .FirstOrDefaultAsync(rt => rt.Id == id);
    } 

}