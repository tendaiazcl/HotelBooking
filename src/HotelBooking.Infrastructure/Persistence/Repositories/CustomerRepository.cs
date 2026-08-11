using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Persistence.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly HotelBookingDbContext _context;

    public BookingRepository(HotelBookingDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);

        await _context.SaveChangesAsync();
    }

    public async Task<bool> HasOverlappingBookingAsync(
        int roomId,
        DateTime checkIn,
        DateTime checkOut)
    {
        return await _context.Bookings.AnyAsync(b =>
            b.RoomId == roomId &&
            b.Status == BookingStatus.Confirmed &&
            b.CheckIn < checkOut &&
            b.CheckOut > checkIn);
    }
}