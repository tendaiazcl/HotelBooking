using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interfaces;

public interface IRoomTypeRepository
{
    Task AddAsync(RoomType roomType);

    Task<List<RoomType>> GetAllAsync();
    Task<RoomType?> GetByIdAsync(int id);
}