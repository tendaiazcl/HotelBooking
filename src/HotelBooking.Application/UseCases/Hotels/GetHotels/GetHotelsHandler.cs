using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.UseCases.Hotels.GetHotels;

public class GetHotelsHandler
{
    private readonly IHotelRepository _hotelRepository;

    public GetHotelsHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<List<Hotel>> Handle()
    {
        return await _hotelRepository.GetAllAsync();
    }
}