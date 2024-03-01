using Backend_RoomAr.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_RoomAr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : Controller
    {
        public static RoomArDbContext context = new RoomArDbContext();
        private readonly IConfiguration _configuration;

        public CartsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("get/{userId}")]
        public ActionResult<IEnumerable<Cart>> GetCartByUserId(int userId)
        {
            try
            {
                var selectedCart = context.Carts.Where(x => x.UserId == userId).Select(s => s.CartId).FirstOrDefault();
                if (selectedCart != 0)
                {
                    return Ok(selectedCart);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}
