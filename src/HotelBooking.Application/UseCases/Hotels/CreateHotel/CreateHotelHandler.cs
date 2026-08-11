using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.UseCases.Hotels.CreateHotel;

public class CreateHotelHandler
{
    private readonly IHotelRepository _hotelRepository;

    public CreateHotelHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<Hotel> Handle(CreateHotelCommand command)
    {
        var hotel = new Hotel(
            command.Name,
            command.Description,
            command.Address,
            command.City,
            command.Country,
            command.StarRating);

        await _hotelRepository.AddAsync(hotel);

        return hotel;
    }
}