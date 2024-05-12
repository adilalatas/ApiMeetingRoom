
namespace Entitiyes.Dto
{
    public record MeetingDto
    {
        public int Id { get; set; }
        public int CreateUserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
