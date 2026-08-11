using HotelBooking.Domain.Entities;

public class RoomAvailabilityService
{
    public bool IsAvailable(
        Room room,
        DateTime checkIn,
        DateTime checkOut)
    {
        return !room.Bookings.Any(
            b => b.Status == BookingStatus.Confirmed &&
                 b.Overlaps(checkIn, checkOut));
    }
}