using ebilet.Context;
using ebilet.Model.Dtos.PlaceDtos.Request;
using ebilet.Model.Dtos.PlaceDtos.Response;
using ebilet.Model.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ebilet.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        Mycontext context = new Mycontext();

        [HttpGet]

        public IActionResult GetAll()
        {
            List<GetAllPlaceResponseDto> response = context.Places.Select(x => new GetAllPlaceResponseDto
            {
                PlaceId = x.PlaceId,
                Name = x.Name,
                Address = x.Address,
                Phone = x.Phone,
                WebAddress = x.WebAddress,
                GoogleMapLink = x.GoogleMapLink,

            }).ToList();
            return Ok(response);

        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Place place = context.Places.FirstOrDefault(x => x.PlaceId == id);

            if(place == null)
            {
                return NotFound( id+" " + "id not found");
            }
            else
            {
                GetByIdPlaceRequestDto response = new GetByIdPlaceRequestDto();
                response.PlaceId = place.PlaceId;
                response.Name = place.Name;
                response.Address = place.Address;
                response.Phone = place.Phone;
                response.WebAddress = place.WebAddress;
                return Ok(response);
            }


        }
        [HttpPost]

        public IActionResult Post (CreatePlaceRequestDto request)
        {
            Place place = new Place();
            place.Name = request.Name;
            place.Address = request.Address;
            place.Phone = request.Phone;
            place.WebAddress = request.WebAddress;
            context.Places.Add(place);
            context.SaveChanges();
            return Ok(request);
        }
        [HttpPut("{id}")]

        public IActionResult Put(int id, UpdatePlaceRequestDto request) {
            Place place = context.Places.FirstOrDefault(x => x.PlaceId == id);

            if(place == null)
            {
                return NotFound();
            }
            else
            {
                place.Name = request.Name;
                place.Address = request.Address;
                place.Phone = request.Phone;
                place.WebAddress = request.WebAddress;
                context.SaveChanges();
                
            }

            List<GetAllPlaceResponseDto> response = context.Places.Select(x => new GetAllPlaceResponseDto
            {
                PlaceId = x.PlaceId,
                Name = x.Name,
                Address = x.Address,
                Phone = x.Phone,
                WebAddress = x.WebAddress

            }).ToList();
            return Ok(response);


        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            Place place = context.Places.FirstOrDefault(x => x.PlaceId == id);

            if(place == null)
            {
                return NotFound(id + "No'lu id veritabanında bulunmuyor ");
            }
            else
            {
                context.Places.Remove(place);
                context.SaveChanges();
                return Ok("Delete");

            }
        }
    }
}
