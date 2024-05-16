using Backend_RoomAr.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_RoomAr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnituresModelController : Controller
    {
        public static RoomArDbContext context = new RoomArDbContext();

        [HttpGet]
        [Route("get/{furnitureId}")]
        public ActionResult<FurnituresModel> Get(int furnitureId)
        {
            try
            {
                var selectedFurnitureModel = context.FurnituresModels.Where(x => x.FurnitureId == furnitureId).FirstOrDefault();
                if (selectedFurnitureModel != null)
                {
                    return selectedFurnitureModel;
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