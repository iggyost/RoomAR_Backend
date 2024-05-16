using Backend_RoomAr.ApplicationData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_RoomAr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        public static RoomArDbContext context = new RoomArDbContext();
        [HttpGet]
        [Route("get")]
        public ActionResult<IEnumerable<Category>> Get()
        {
            try
            {
                var data = context.Categories.ToList();
                return data;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }

    }
}