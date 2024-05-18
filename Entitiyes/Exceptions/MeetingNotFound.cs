namespace Entitiyes.Exceptions
{
    public sealed class MeetingNotFoundException : NotFoundException
    {
        public MeetingNotFoundException(Guid id) : base($"Toplantı Bulunamadı: {id}")
        {
        }
    }
}
