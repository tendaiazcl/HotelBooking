using HotelBooking.Api.Models.RoomTypes;
using HotelBooking.Application.DTOs.RoomTypes;
using HotelBooking.Application.UseCases.RoomTypes.CreateRoomType;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[ApiController]
[Route("api/room-types")]
public class RoomTypesController : ControllerBase
{
    private readonly CreateRoomTypeHandler _handler;

    public RoomTypesController(CreateRoomTypeHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoomTypeRequest request)
    {
        var command = new CreateRoomTypeCommand
        {
            Name = request.Name,
            Description = request.Description,
            Capacity = request.Capacity,
            BasePrice = request.BasePrice
        };

        var roomType = await _handler.Handle(command);

        var response = new RoomTypeResponseDto
        {
            Id = roomType.Id,
            Name = roomType.Name,
            Description = roomType.Description,
            Capacity = roomType.Capacity,
            BasePrice = roomType.BasePrice
        };

        return Ok(response);
    }
}