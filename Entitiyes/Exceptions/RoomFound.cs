namespace Entitiyes.Exceptions
{
    public sealed class RoomFoundException : NotFoundException
    {
        public RoomFoundException(int id) : base($"Toplantı Odası Bulunamadı Id : {id} .")
        {
        }
    }
}
