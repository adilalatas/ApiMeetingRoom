namespace Entitiyes.Exceptions
{
    public sealed class RoomFoundException : NotFoundException
    {
        public RoomFoundException(Guid id) : base($"Toplantı Odası Bulunamadı Id : {id} .")
        {
        }
    }
}
