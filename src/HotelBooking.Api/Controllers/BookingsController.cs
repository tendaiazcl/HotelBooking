using HotelBooking.Api.Contracts.Bookings;
using HotelBooking.Application.UseCases.Bookings.CreateBooking;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly CreateBookingHandler _handler;

    public BookingsController(CreateBookingHandler handler)
    {
        _handler = handler;
    }
    [HttpPost]
    public async Task<IActionResult> Create(
    CreateBookingRequest request)
    {
        var command = new CreateBookingCommand
        {
            CustomerId = request.CustomerId,
            RoomId = request.RoomId,
            CheckIn = request.CheckIn,
            CheckOut = request.CheckOut
        };

        var booking = await _handler.Handle(command);

        return Ok(booking);
    }
}