using ebilet.Context;
using ebilet.Model.Dtos.EventDtos.Request;
using ebilet.Model.Dtos.EventDtos.Response;
using ebilet.Model.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ebilet.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        Mycontext context = new Mycontext();


        [HttpGet]

        public IActionResult GetAll()
        {
            List<GetAllEventResponseDto> response = context.Events.Select(x => new GetAllEventResponseDto
            {
                EventId = x.EventId,
                Name = x.Name,
                Description = x.Description,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                EventType = x.EventType,
                Price = x.Price,



            }).ToList();
            return Ok(response);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Event event1 = context.Events.FirstOrDefault(x => x.EventId == id);

            if (event1 == null)
            {
                return NotFound(id + " " + "id not found");
            }
            else
            {
                GetByIdEventResponseDto response = new GetByIdEventResponseDto();

                response.EventId = event1.EventId;
                response.Name = event1.Name;
                response.Description = event1.Description;
                response.StartTime = event1.StartTime;
                response.EndTime = event1.EndTime;
                response.EventType = event1.EventType;
                response.Price = event1.Price;

                return Ok(response);

            }

        }

        [HttpPost]

        public IActionResult Post(CreateEventRequestDto request)
        {
            Event event1 = new Event();

           
            event1.Name = request.Name;
            event1.Description = request.Description;
            event1.StartTime = request.StartTime;
            event1.EndTime = request.EndTime;
            event1.EventType = request.EventType;
            event1.Price = request.Price;

            context.Events.Add(event1);
            context.SaveChanges();

            return Ok(request);

        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, UpdateEventRequestDto request)
        {
            Event event1 = context.Events.FirstOrDefault(x => x.EventId == id);

            if (event1 == null)
            {
                return NotFound();
            }
            else
            {
                event1.Name = request.Name;
                event1.Description = request.Description;
                event1.StartTime = request.StartTime;
                event1.EndTime = request.EndTime;
                event1.EventType = request.EventType;
                event1.Price = request.Price;
                context.Events.Add(event1);
                context.SaveChanges();

            }
            List<GetAllEventResponseDto> response = context.Events.Select(x => new GetAllEventResponseDto
            {
                EventId = x.EventId,
                Name = x.Name,
                Description = x.Description,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                EventType = x.EventType,
                Price = x.Price,

            }).ToList();

            return Ok(response);
        }

        [HttpDelete]
        
        public IActionResult DeleteById(int id)
        {
            Event event1 = context.Events.FirstOrDefault(x => x.EventId == id);

            if(event1 == null)
            {
                return NotFound();
            }
            else
            {
                context.Events.Remove(event1);
                context.SaveChanges();
                return Ok("Delete");
            }


        }
    }
}
