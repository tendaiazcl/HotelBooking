using HotelBooking.Api.Models.Hotels;
using HotelBooking.Application.DTOs.Hotels;
using HotelBooking.Application.UseCases.Hotels.CreateHotel;
using HotelBooking.Application.UseCases.Hotels.GetHotels;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.Api.Models.Rooms;
using HotelBooking.Application.DTOs.Rooms;
using HotelBooking.Application.UseCases.Rooms.CreateRoom;

namespace HotelBooking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelsController : ControllerBase
{
    private readonly CreateHotelHandler _createHotelHandler;
    private readonly GetHotelsHandler _getHotelsHandler;
    private readonly CreateRoomHandler _createRoomHandler;

    public HotelsController(
    CreateHotelHandler createHotelHandler,
    GetHotelsHandler getHotelsHandler,
    CreateRoomHandler createRoomHandler)
    {
        _createHotelHandler = createHotelHandler;
        _getHotelsHandler = getHotelsHandler;
        _createRoomHandler = createRoomHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateHotelRequest request)
    {
        var command = new CreateHotelCommand
        {
            Name = request.Name,
            Description = request.Description,
            Address = request.Address,
            City = request.City,
            Country = request.Country,
            StarRating = request.StarRating
        };

        var hotel = await _createHotelHandler.Handle(command);

        var response = new HotelResponseDto
        {
            Id = hotel.Id,
            Name = hotel.Name,
            Description = hotel.Description,
            Address = hotel.Address,
            City = hotel.City,
            Country = hotel.Country,
            StarRating = hotel.StarRating
        };

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var hotels = await _getHotelsHandler.Handle();

        var response = hotels.Select(hotel => new HotelResponseDto
        {
            Id = hotel.Id,
            Name = hotel.Name,
            Description = hotel.Description,
            Address = hotel.Address,
            City = hotel.City,
            Country = hotel.Country,
            StarRating = hotel.StarRating
        });

        return Ok(response);
    }
    [HttpPost("{hotelId}/rooms")]
    public async Task<IActionResult> CreateRoom(
    int hotelId,
    CreateRoomRequest request)
    {
        var command = new CreateRoomCommand
        {
            HotelId = hotelId,
            RoomNumber = request.RoomNumber,
            RoomTypeId = request.RoomTypeId
        };

        var room = await _createRoomHandler.Handle(command);

        var response = new RoomResponseDto
        {
            Id = room.Id,
            RoomNumber = room.RoomNumber,
            HotelId = room.HotelId,
            RoomTypeId = room.RoomTypeId
        };

        return Ok(response);
    }
}