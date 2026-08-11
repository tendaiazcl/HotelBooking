public class RoomNotFoundException : Exception
{
    public RoomNotFoundException(int roomId)
        : base($"Room {roomId} was not found.")
    {
    }
}
