using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Paramore.Brighter;
using Paramore.Darker;
using TrafficSignalsConfigurator.Domain.Commands;
using TrafficSignalsConfigurator.Domain.Queries;
using TrafficSignalsConfigurator.Web.ViewModels;

namespace TrafficSignalsConfigurator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IAmACommandProcessor _commandProcessor;
        private readonly IQueryProcessor _queryProcessor;
        private readonly string _jwtSecretKey;
        private readonly int _jwtLifespan;
        
        public AuthController(IConfiguration configuration, IAmACommandProcessor commandProcessor, IQueryProcessor  queryProcessor)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;

            _jwtSecretKey = configuration.GetValue<string>("JWTSecretKey");
            _jwtLifespan = configuration.GetValue<int>("JWTLifespan");
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthDataViewModel>> Post([FromBody]LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _queryProcessor.ExecuteAsync(new GetUserQuery(model.Email));

            if (user == null) 
            {
                return BadRequest(new { loginError = "Invalid username password combination" });
            }

            if (!user.IsOwnPassword(model.Password)) 
            {
                return BadRequest(new { loginError = "Invalid username password combination" });
            }

            return new AuthDataViewModel(_jwtSecretKey, _jwtLifespan, user.Id);
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthDataViewModel>> PostAsync([FromBody]RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var emailUnique = await _queryProcessor.ExecuteAsync(new IsEmailUniqueQuery(model.Email));
            if(!emailUnique)
            {
                return BadRequest(new { email = "User with this email already exists" });
            }

            var usernameUnique = await _queryProcessor.ExecuteAsync(new IsEmailUniqueQuery(model.Username));
            if (!usernameUnique) 
            {
                return BadRequest(new { username = "User with this username already exists" });
            }

            var command = new CreateUserCommand(model.Username, model.Email, model.Password);
            
            await _commandProcessor.SendAsync<CreateUserCommand>(command);

            return new AuthDataViewModel(_jwtSecretKey, _jwtLifespan, command.UserId);
        }
    }
}
