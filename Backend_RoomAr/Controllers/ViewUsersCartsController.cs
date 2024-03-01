using Backend_RoomAr.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_RoomAr.Controllers
{
    [Route("api/[controller]")]
    public class ViewUsersCartsController : Controller
    {
        public static RoomArDbContext context = new RoomArDbContext();
        private readonly IConfiguration _configuration;

        public ViewUsersCartsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("{userId}")]
        public ActionResult<IEnumerable<ViewUserCart>> GetCartByUserId(int userId)
        {
            try
            {
                var list = context.ViewUserCarts.Where(x => x.UserId == userId).ToList();
                return list.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }

    }

}
