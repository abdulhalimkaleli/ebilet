namespace ebilet.Model.Dtos.PlaceDtos.Request
{
    public class UpdatePlaceRequestDto
    {
       
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
        public string? WebAddress { get; set; }

        public string? GoogleMapLink { get; set; }
    }
}
