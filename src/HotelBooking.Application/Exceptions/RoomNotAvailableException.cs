public class RoomNotAvailableException : Exception
{
    public RoomNotAvailableException()
        : base("The selected room is not available for the requested dates.")
    {
    }
}