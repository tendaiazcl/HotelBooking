using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interfaces;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer);

    Task<Customer?> GetByIdAsync(int id);
}