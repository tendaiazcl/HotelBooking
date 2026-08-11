using HotelBooking.Application.Interfaces;
using HotelBooking.Application.DTOs.Rooms;

namespace HotelBooking.Application.UseCases.Rooms.SearchAvailableRooms;

public class SearchAvailableRoomsHandler
{
    private readonly IRoomRepository _roomRepository;

    public SearchAvailableRoomsHandler(
        IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<List<AvailableRoomDto>> Handle(
        SearchAvailableRoomsQuery query)
    {
        if (query.CheckIn >= query.CheckOut)
            throw new ArgumentException(
                "Check-out must be after check-in.");

        var rooms =
            await _roomRepository.SearchAvailableAsync(
                query.HotelId,
                query.CheckIn,
                query.CheckOut);

        return rooms.Select(room => new AvailableRoomDto
        {
            RoomId = room.Id,
            RoomNumber = room.RoomNumber,
            RoomType = room.RoomType.Name,
            PricePerNight = room.RoomType.BasePrice
        }).ToList();
    }
}