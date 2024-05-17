using Backend_RoomAr.ApplicationData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_RoomAr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnituresCartsController : Controller
    {
        public static RoomArDbContext context = new RoomArDbContext();
        private readonly IConfiguration _configuration;
        public FurnituresCartsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public class CounterList
        {
            public int Count { get; set; }
            public int FurnitureId { get; set; }
            public int CartId { get; set; }
        };
        [HttpDelete]
        [Route("delete/{furnitureCartId}")]
        public ActionResult<IEnumerable<FurnituresCart>> RemoveFurnitureCart(int furnitureCartId)
        {
            try
            {
                var furnitureCart = context.FurnituresCarts.Where(x => x.Id == furnitureCartId).FirstOrDefault();
                if (furnitureCart != null)
                {
                    context.FurnituresCarts.Remove(furnitureCart);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpGet]
        [Route("delete/all/{userCartId}")]
        public ActionResult<IEnumerable<FurnituresCart>> RemoveAllFromUser(int userCartId)
        {
            try
            {
                var userFurnituresCart = context.FurnituresCarts.Where(x => x.CartId == userCartId).ToList();
                foreach (var item in userFurnituresCart)
                {
                    context.Remove(item);
                    context.SaveChanges();
                }
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpPut]
        [Route("putcount/{furnitureCartId}/{count}")]
        public ActionResult<IEnumerable<FurnituresCart>> PutCountFurnituresCart(int furnitureCartId, int count)
        {
            try
            {
                var furnitureCart = context.FurnituresCarts.Where(x => x.Id == furnitureCartId).FirstOrDefault();
                if (furnitureCart != null)
                {
                    var selectedFurniture = context.Furnitures.Where(x => x.FurnitureId == furnitureCart.FurnitureId).FirstOrDefault();
                    furnitureCart.Count = count;
                    furnitureCart.TotalCost = furnitureCart.Count * selectedFurniture.Cost;
                    context.Entry(furnitureCart).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpPost]
        [Route("addtocart/{furnitureId}/{cartId}/{count}")]
        public ActionResult<IEnumerable<FurnituresCart>> AddFurnitureToCart(int furnitureId, int cartId, int count)
        {
            try
            {
                var selectedFurniture = context.Furnitures.Where(x => x.FurnitureId == furnitureId).FirstOrDefault();
                if (selectedFurniture != null)
                {
                    FurnituresCart newFurnituresCart = new FurnituresCart()
                    {
                        CartId = cartId,
                        FurnitureId = furnitureId,
                        Count = count,
                        TotalCost = selectedFurniture.Cost * count
                    };
                    context.FurnituresCarts.Add(newFurnituresCart);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpGet]
        [Route("check/{furnitureId}/{cartId}")]
        public ActionResult<IEnumerable<FurnituresCart>> CheckFurnitureInCart(int furnitureId, int cartId)
        {
            try
            {
                var selectedFurnitureCart = context.FurnituresCarts.Where(x => x.FurnitureId == furnitureId && x.CartId == cartId).FirstOrDefault();
                if (selectedFurnitureCart == null)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }


    }
}
