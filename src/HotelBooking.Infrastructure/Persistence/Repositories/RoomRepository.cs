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
    public async Task<Room?> GetByIdAsync(int id)
    {
        return await _context.Rooms
            .Include(r => r.RoomType)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
    public async Task<List<Room>> SearchAvailableAsync(
    int hotelId,
    DateTime checkIn,
    DateTime checkOut)
    {
        return await _context.Rooms
            .Include(r => r.RoomType)
            .Where(r => r.HotelId == hotelId)
            .Where(r => !r.Bookings.Any(b =>
                b.Status == BookingStatus.Confirmed &&
                b.CheckIn < checkOut &&
                b.CheckOut > checkIn))
            .ToListAsync();
    }
}