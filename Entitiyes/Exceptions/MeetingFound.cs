namespace Entitiyes.Exceptions
{
    public sealed class MeetingFoundException : NotFoundException
    {
        public MeetingFoundException() : base($"Toplantı Bulunamadı Id : .")
        {
        }
    }
}
