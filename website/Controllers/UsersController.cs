using System;//Guid
using System.Collections.Generic;//IEnumerable
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;//ApiController
using website.Dtos;
using website.Entities;//User
using website.Repositories;//InMemUsersRepository

namespace website.Controllers
{
    [ApiController]
    [Route("users")]

    public class UsersController : ControllerBase
    {
        private readonly UUsersRepository repositoryUser;
        public UsersController(UUsersRepository repositoryUser2)
        {
            this.repositoryUser = repositoryUser2;
        }

        //GET/user
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = (await repositoryUser.GetUsersAsync())
                        .Select(user => user.AsDtoUser());
            return users;
        }

        //GET/user/{idUser}
        [HttpGet("{idUser}")]
        public async Task<ActionResult<UserDto>> GetUserAsync(Guid idUser)
        {
            var user = await repositoryUser.GetUserAsync(idUser);
            if (user is null)
            {
                return NotFound();
            }
            return user.AsDtoUser();
        }
        //POST/users
        [HttpPost]
        public async Task<ActionResult> CreateUserAsync(CreateUserDto userDto)
        {
            User user = new()
            {
                _id = Guid.NewGuid(),
                name = userDto.name,
                sdt = userDto.sdt,
                email = userDto.email,
                idAc = userDto.idAc
            };
            await repositoryUser.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserAsync), new { idUser = user._id }, user.AsDtoUser());

        }
        [HttpPut("{idUser}")]
        public async Task<ActionResult> UpdateUserAsync(Guid idUser, CreateUserDto userDto)
        {
            var existingUser = await repositoryUser.GetUserAsync(idUser);
            if (existingUser is null)
            {
                return NotFound();
            }
            User updateUser = existingUser with
            {
                name = userDto.name,
                sdt = userDto.sdt,
                email = userDto.email,
                idAc = userDto.idAc
            };
            await repositoryUser.UpdateUserAsync(updateUser);
            return NoContent();
        }

        [HttpDelete("{idUser}")]
        public async Task<ActionResult> DeleteUserAsync(Guid idUser)
        {
            var existingUser = await repositoryUser.GetUserAsync(idUser);
            if (existingUser is null)
            {
                return NotFound();
            }
            await repositoryUser.DeleteUserAsync(idUser);
            return NoContent();
        }


    }
}