using ebilet.Context;
using ebilet.Model.Dtos.ImageDtos.Request;
using ebilet.Model.Dtos.ImageDtos.Response;
using ebilet.Model.Dtos.ImageDtos.Resquest;
using ebilet.Model.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace ebilet.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        Mycontext context = new Mycontext();

        [HttpGet]

        public IActionResult GetAll()
        {

            List<GetAllImageResponseDto> response = context.Images.Select(x => new GetAllImageResponseDto
            {
                ImageId = x.ImageId,
                ImageUrl = x.ImageUrl,
                EventId = x.EventId,
            }).ToList();

            return Ok(response);

        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Image Image = context.Images.FirstOrDefault(x => x.ImageId == id);

            if(Image == null)
            {
                return NotFound(id+ " "+ "nolu id bulunamadı");
            }
            else
            {
                GetByIdImageResponseDto response = new GetByIdImageResponseDto();
                response.ImageId = Image.ImageId;
                response.ImageUrl = Image.ImageUrl;
                response.EventId = Image.EventId;

                return Ok(response);

            }
       
            
        }
        [HttpPost]

        public IActionResult Post(CreateImageRequestDto request)
        {
            Image Image = new Image();
           
           
            Image.ImageUrl = request.ImageUrl;
            context.Images.Add(Image);
              context.SaveChanges();
           
            return Ok(request);

        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, UpdateImageRequestDto request)
        {

            Image Image = context.Images.FirstOrDefault(x => x.ImageId == id);

            if(Image == null)
            {
                return NotFound(id + " " + "No'lu id bulunamadı");
            }
            else
            {
                Image.EventId = request.EventId;
                Image.ImageUrl = request.ImageUrl;
                context.SaveChanges();
               
            }
            List<GetAllImageResponseDto> response = context.Images.Select(x => new GetAllImageResponseDto
            {
                ImageId = x.ImageId,
                ImageUrl = x.ImageUrl,
                EventId = x.EventId,
            }).ToList();
            return Ok(response);



        }
        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            Image Image = context.Images.FirstOrDefault(x => x.ImageId == id);
             if(Image == null)
            {
                return NotFound(id + " No'lu id verisi bulunamadı");
            }
            else
            {
                context.Images.Remove(Image);
                context.SaveChanges();
                return Ok("delete");
            }


        }



    }
}
