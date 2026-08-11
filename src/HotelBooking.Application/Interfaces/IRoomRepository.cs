using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interfaces;

public interface IRoomRepository
{
    Task AddAsync(Room room);

    Task<List<Room>> GetByHotelIdAsync(int hotelId);
    
}