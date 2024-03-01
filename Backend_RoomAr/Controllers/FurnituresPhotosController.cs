using Backend_RoomAr.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_RoomAr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnituresPhotosController : Controller
    {
        public static RoomArDbContext context = new RoomArDbContext();
        private readonly IConfiguration _configuration;

        public FurnituresPhotosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Photo>> Get(int id)
        {
            try
            {
                var query = from p in context.Photos
                            where context.FurnituresPhotos.Any(fp => fp.PhotoId == p.PhotoId && fp.FurnitureId == id)
                            select new Photo
                            {
                                PhotoId = p.PhotoId,
                                Photo1 = p.Photo1
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}