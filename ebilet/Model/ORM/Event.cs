using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ebilet.Model.ORM
{
    public class Event
    {
        public int EventId { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public EventType EventType { get; set; }

        public decimal Price { get; set; }
     
        public int? PlaceId {get; set; }
        public Place? Place { get; set; }
        
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public virtual ICollection<Image> Images { get; set; }





    }
}
