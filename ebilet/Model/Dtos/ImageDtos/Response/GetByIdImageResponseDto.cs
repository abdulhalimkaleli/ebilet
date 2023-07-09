 namespace ebilet.Model.Dtos.ImageDtos.Response
{
    public class GetByIdImageResponseDto
    {
        public int ImageId { get; set; }
        public string? ImageUrl { get; set; }

        public int EventId { get; set; }
    }
}
