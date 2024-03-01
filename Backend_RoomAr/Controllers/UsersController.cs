using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend_RoomAr.ApplicationData;
using System.Text.Json.Serialization;

namespace Backend_RoomAr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        public static RoomArDbContext context = new RoomArDbContext();
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("phone/{phone}")]
        public ActionResult<IEnumerable<User>> GetByPhone(string phone)
        {
            var user = context.Users.Where(x => x.PhoneNum == phone).FirstOrDefault();
            if (user != null)
            {
                return Ok(user.PhoneNum);
            }
            else
            {
                return BadRequest(phone);
            }
        }
        [HttpGet]
        [Route("login/{phone}/{password}")]
        public ActionResult<IEnumerable<User>> GetByPassword(string phone, string password)
        {
            try
            {
                var user = context.Users.Where(x => x.PhoneNum == phone && x.Password == password).FirstOrDefault();
                if (user != null)
                {
                    return Ok(user);
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

        //[HttpPost]
        //[Route("login")]
        //public async Task<ActionResult<User>> AuthenticateUser([FromBody] User credentials)
        //{
        //    if (credentials == null || string.IsNullOrWhiteSpace(credentials.Email) || string.IsNullOrWhiteSpace(credentials.Password))
        //    {
        //        return BadRequest("Invalid credentials");
        //    }
        //    var user = await context.Users.FirstOrDefaultAsync(u => u.Email == credentials.Email && u.Password == credentials.Password);
        //    if (user == null)
        //    {

        //    }
        //    return Ok(user);
        //}

        [HttpPost]
        [Route("reg")]
        public ActionResult<IEnumerable<User>> RegistrateUser([FromBody] User user)
        {
            try
            {
                var checkAvail = context.Users.Where(x => x.PhoneNum == user.PhoneNum).FirstOrDefault();
                if (checkAvail == null)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    Cart newCart = new Cart()
                    {
                        UserId = user.UserId,
                    };
                    context.Add(newCart);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Пользователь с таким номером уже есть");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}
