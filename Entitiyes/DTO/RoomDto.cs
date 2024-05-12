
namespace Entitiyes.Dto
{
    public record RoomDto
    {
        public int Id { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }

    }
}
