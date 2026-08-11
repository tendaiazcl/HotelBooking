namespace HotelBooking.Domain.Entities;

public class Room
{
    public int Id { get; private set; }

    public string RoomNumber { get; private set; }

    public int RoomTypeId { get; private set; }

    public RoomType RoomType { get; private set; }

    public int HotelId { get; private set; }

    public Hotel Hotel { get; private set; }

    public ICollection<Booking> Bookings { get; private set; }
            = new List<Booking>();
    private Room()
    {
    }

    public Room(
        string roomNumber,
        int hotelId,
        int roomTypeId)
    {
        if (string.IsNullOrWhiteSpace(roomNumber))
            throw new ArgumentException("Room number is required.");

        RoomNumber = roomNumber;
        HotelId = hotelId;
        RoomTypeId = roomTypeId;
    }
}