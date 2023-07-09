namespace ebilet.Model.ORM
{
    public class Image
    {
        public int ImageId { get; set; }
        public string? ImageUrl { get; set; }

        public int EventId { get; set; }
        public Event Events { get; set; }
    }
}
