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
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        
        public AuthController(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public ActionResult<AuthDataViewModel> Post([FromBody]LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = _userRepository.Get(u => u.Email == model.Email);
            if (user == null) 
            {
                return BadRequest(new { email = "no user with this email" });
            }

            var passwordValid = _authService.VerifyPassword(model.Password, user.Password);
            if (!passwordValid) 
            {
                return BadRequest(new { password = "invalid password" });
            }

            return _authService.GetAuthData(user.Id);
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthDataViewModel>> PostAsync([FromBody]RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var emailUnique = await _userRepository.IsEmailUnique(model.Email);
            if(!emailUnique)
            {
                return BadRequest(new { email = "user with this email already exists" });
            }

            var usernameUnique = await _userRepository.IsUsernameUnique(model.Username);
            if (!usernameUnique) 
            {
                return BadRequest(new { username = "user with this email already exists" });
            }

            var id = Guid.NewGuid().ToString();
            
            var user = new User
            {
                Id = id,
                Username = model.Username,
                Email = model.Email,
                Password = _authService.HashPassword(model.Password)
            };
            
            _userRepository.Add(user);

            return _authService.GetAuthData(id);
        }

    }
}
