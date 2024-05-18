namespace Entitiyes.Exceptions
{
    public sealed class RoomNotFoundException : NotFoundException
    {
        public RoomNotFoundException(Guid id) : base($"Toplantı Odası Bulunamadı: {id}")
        {
        }
    }
}
