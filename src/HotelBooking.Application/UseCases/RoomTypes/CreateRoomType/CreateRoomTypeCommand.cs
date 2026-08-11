namespace HotelBooking.Application.UseCases.RoomTypes.CreateRoomType;

public class CreateRoomTypeCommand
{
    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public int Capacity { get; init; }

    public decimal BasePrice { get; init; }
}