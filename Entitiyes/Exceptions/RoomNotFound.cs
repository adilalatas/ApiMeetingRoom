namespace Entitiyes.Exceptions
{
    public sealed class RoomNotFoundException : NotFoundException
    {
        public RoomNotFoundException(int id) : base($"Toplantı Odası Bulunamadı: {id}")
        {
        }
    }
}
