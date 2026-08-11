using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.UseCases.RoomTypes.CreateRoomType;

public class CreateRoomTypeHandler
{
    private readonly IRoomTypeRepository _roomTypeRepository;

    public CreateRoomTypeHandler(IRoomTypeRepository roomTypeRepository)
    {
        _roomTypeRepository = roomTypeRepository;
    }

    public async Task<RoomType> Handle(CreateRoomTypeCommand command)
    {
        var roomType = new RoomType(
            command.Name,
            command.Description,
            command.Capacity,
            command.BasePrice);

        await _roomTypeRepository.AddAsync(roomType);

        return roomType;
    }
}