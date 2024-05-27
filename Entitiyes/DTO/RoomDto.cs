
namespace Entitiyes.Dto
{
    public record RoomDto
    {
        public Guid? Id { get; set; }
        public string CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }

    }
}
