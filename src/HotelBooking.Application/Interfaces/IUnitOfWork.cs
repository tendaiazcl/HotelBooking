using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interfaces;

public interface IBookingRepository
{
    Task AddAsync(Booking booking);

    Task<bool> HasOverlappingBookingAsync(
        int roomId,
        DateTime checkIn,
        DateTime checkOut);
}