using ebilet.Context;
using ebilet.Model.Dtos.CategoryDtos.Request;
using ebilet.Model.Dtos.CategoryDtos.Response;
using ebilet.Model.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ebilet.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        Mycontext context = new Mycontext();




        [HttpGet]

        public IActionResult GetAll()
        {

            List<GetAllCategoryResponseDto> response = context.Categories.Select(x => new GetAllCategoryResponseDto
            {
                CategoryId = x.CategoryId,
                Name = x.Name,
            }).ToList();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Category category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return NotFound(id + " id not found");
            }
            else
            {
                GetCategoryByIdResponseDto response = new GetCategoryByIdResponseDto();

                response.CategoryId = category.CategoryId;
                response.Name = category.Name;
                return Ok(response);


            }

        }

        [HttpPost]
        public IActionResult Post(CreateCategoryRequestDto request)
        {
            Category category = new Category();
            category.Name = request.Name;
            context.Categories.Add(category);
            context.SaveChanges();

            return Ok(request);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateCategoryRequestDto request)
        {

            Category category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category != null)
            {
               
                category.Name = request.Name;
                context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            List<GetAllCategoryResponseDto> response = context.Categories.Select(x => new GetAllCategoryResponseDto
            {
                CategoryId = x.CategoryId,
                Name = x.Name,
            }).ToList();
            return Ok(response);
        }
        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
           
           Category category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return NotFound(id + " No'lu id veri tabanında  bulunamamıştır.");

            }
            else
            {
                context.Categories.Remove(category);
                context.SaveChanges();
                return Ok("Delete");

            }


        }
    }
}

