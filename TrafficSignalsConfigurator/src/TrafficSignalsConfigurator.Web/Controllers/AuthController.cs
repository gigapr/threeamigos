using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrafficSignalsConfigurator.Persistence;
using TrafficSignalsConfigurator.Web.ViewModels;

namespace TrafficSignalsConfigurator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IUserRepository userRepository;
        
        public AuthController(IAuthService authService, IUserRepository userRepository)
        {
            this.authService = authService;
            this.userRepository = userRepository;
        }

        [HttpPost("login")]
        public ActionResult<AuthDataViewModel> Post([FromBody]LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = userRepository.Get(u => u.Email == model.Username);

            if (user == null) {
                return BadRequest(new { email = "no user with this email" });
            }

            var passwordValid = authService.VerifyPassword(model.Password, user.Password);
            if (!passwordValid) {
                return BadRequest(new { password = "invalid password" });
            }

            return authService.GetAuthData(user.Id);
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthDataViewModel>> PostAsync([FromBody]RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var emailUniq = await userRepository.IsEmailUnique(model.Email);
            if(!emailUniq)
            {
                return BadRequest(new { email = "user with this email already exists" });
            }

            var usernameUniq = await userRepository.IsUsernameUniqueAsync(model.Username);
            if (!usernameUniq) 
            {
                return BadRequest(new { username = "user with this email already exists" });
            }

            var id = Guid.NewGuid().ToString();
            var user = new User
            {
                Id = id,
                Username = model.Username,
                Email = model.Email,
                Password = authService.HashPassword(model.Password)
            };
            
            userRepository.Add(user);

            return authService.GetAuthData(id);
        }

    }
}
