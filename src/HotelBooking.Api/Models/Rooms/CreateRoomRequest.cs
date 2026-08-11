namespace HotelBooking.Api.Models.Rooms;

public class CreateRoomRequest
{
    public string RoomNumber { get; init; } = string.Empty;

    public int RoomTypeId { get; init; }
}