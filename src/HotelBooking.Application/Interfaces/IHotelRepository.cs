using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interfaces;

public interface IHotelRepository
{
    Task AddAsync(Hotel hotel);
    Task<Hotel?> GetByIdAsync(int id);
    Task<List<Hotel>> GetAllAsync();
}