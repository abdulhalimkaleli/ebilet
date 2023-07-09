using ebilet.Model.ORM;

namespace ebilet.Model.Dtos.EventDtos.Response
{
    public class GetByIdEventResponseDto
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public EventType EventType { get; set; }

        public decimal Price { get; set; }
        public int PlaceId { get; set; }
        public int CategoryId { get; set; }
    }
}
