﻿namespace ebilet.Model.Dtos.PlaceDtos.Response
{
    public class GetByIdPlaceRequestDto
    {
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
        public string? WebAddress { get; set; }

        public string? GoogleMapLink { get; set; }
    }
}
