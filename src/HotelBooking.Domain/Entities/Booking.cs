namespace HotelBooking.Domain.Entities;

public class Booking
{
    public int Id { get; private set; }

    public int CustomerId { get; private set; }

    public Customer Customer { get; private set; }

    public int RoomId { get; private set; }

    public Room Room { get; private set; }

    public DateTime CheckIn { get; private set; }

    public DateTime CheckOut { get; private set; }

    public BookingStatus Status { get; private set; }
    public decimal PricePerNight { get; private set; }

    public decimal TotalPrice { get; private set; }

    private Booking()
    {
    }

    public Booking(
    int customerId,
    int roomId,
    DateTime checkIn,
    DateTime checkOut,
    decimal pricePerNight)
    {
        if (checkIn >= checkOut)
            throw new ArgumentException(
                "Check-out must be after check-in.");

        if (pricePerNight < 0)
            throw new ArgumentException(
                "Price cannot be negative.");

        var nights = (checkOut - checkIn).Days;

        CustomerId = customerId;
        RoomId = roomId;
        CheckIn = checkIn;
        CheckOut = checkOut;

        PricePerNight = pricePerNight;
        TotalPrice = nights * pricePerNight;

        Status = BookingStatus.Confirmed;
    }
    public void Cancel()
    {
        if (Status == BookingStatus.Cancelled)
            throw new InvalidOperationException(
                "Booking is already cancelled.");

        Status = BookingStatus.Cancelled;
    }
    public bool Overlaps(
    DateTime requestedCheckIn,
    DateTime requestedCheckOut)
    {
        return CheckIn < requestedCheckOut &&
               CheckOut > requestedCheckIn;
    }
}