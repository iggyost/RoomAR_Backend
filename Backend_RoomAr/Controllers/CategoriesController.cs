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
        private readonly IConfiguration _configuration;

        public CategoriesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return context.Categories;
        }

    }
}