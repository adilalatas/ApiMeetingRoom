
namespace Entitiyes.Dto
{
    public record MeetingDto
    {
        public Guid? Id { get; set; }
        public Guid CreateUserId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
