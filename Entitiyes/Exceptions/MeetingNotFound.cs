namespace Entitiyes.Exceptions
{
    public sealed class MeetingNotFoundException : NotFoundException
    {
        public MeetingNotFoundException(int id) : base($"Toplantı Bulunamadı: {id}")
        {
        }
    }
}
