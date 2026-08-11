using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.UseCases.Rooms.CreateRoom;

public class CreateRoomHandler
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IRoomRepository _roomRepository;

    public CreateRoomHandler(
        IHotelRepository hotelRepository,
        IRoomTypeRepository roomTypeRepository,
        IRoomRepository roomRepository)
    {
        _hotelRepository = hotelRepository;
        _roomTypeRepository = roomTypeRepository;
        _roomRepository = roomRepository;
    }

    public async Task<Room> Handle(CreateRoomCommand command)
    {
        var hotel = await _hotelRepository.GetByIdAsync(command.HotelId);

        if (hotel is null)
            throw new InvalidOperationException("Hotel not found.");

        var roomType =
            await _roomTypeRepository.GetByIdAsync(command.RoomTypeId);

        if (roomType is null)
            throw new InvalidOperationException("Room type not found.");

        var room = new Room(
            command.RoomNumber,
            command.HotelId,
            command.RoomTypeId);

        await _roomRepository.AddAsync(room);

        return room;
    }
}