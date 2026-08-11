using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interfaces;

public interface IRoomRepository
{
    Task AddAsync(Room room);

    Task<Room?> GetByIdAsync(int id);

    Task<List<Room>> GetByHotelIdAsync(int hotelId);

    Task<List<Room>> SearchAvailableAsync(
        int hotelId,
        DateTime checkIn,
        DateTime checkOut);
}