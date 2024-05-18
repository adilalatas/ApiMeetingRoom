
namespace Entitiyes.Dto
{
    public record RoomDto
    {
        public Guid? Id { get; set; }
        public Guid CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }

    }
}
