namespace Entitiyes.Exceptions
{
    public sealed class MeetingFoundException : NotFoundException
    {
        public MeetingFoundException(int id) : base($"Toplantı Bulunamadı Id : {id} .")
        {
        }
    }
}
