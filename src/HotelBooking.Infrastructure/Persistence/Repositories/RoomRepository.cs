using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Persistence.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly HotelBookingDbContext _context;

    public RoomRepository(HotelBookingDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Room room)
    {
        await _context.Rooms.AddAsync(room);

        await _context.SaveChangesAsync();
    }

    public async Task<List<Room>> GetByHotelIdAsync(int hotelId)
    {
        return await _context.Rooms
            .AsNoTracking()
            .Where(r => r.HotelId == hotelId)
            .ToListAsync();
    }
}