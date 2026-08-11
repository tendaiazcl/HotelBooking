namespace HotelBooking.Application.UseCases.Rooms.CreateRoom;

public class CreateRoomCommand
{
    public int HotelId { get; init; }

    public string RoomNumber { get; init; } = string.Empty;

    public int RoomTypeId { get; init; }
}