using System.Threading.Tasks;
using API.ApiModels;
using API.Result;
using AutoMapper;
using Domain.Auth;
using Domain.User.Entity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        
        private readonly ILoginUseCase _loginUseCase;
        private readonly IRegistrationUseCase _registrationUseCase;
        private readonly IMapper _mapper;

        public AuthController(
            ILoginUseCase loginUseCase,
            IRegistrationUseCase registrationUseCase,
            IMapper mapper)
        {
            _loginUseCase = loginUseCase;
            _registrationUseCase = registrationUseCase;
            _mapper = mapper;
        }

        [HttpPost("signIn")]
        public async Task<ActionResult<LoginResponseModel>> Login(UserDTO dto)
        {
            var (status, accessToken, message) = await _loginUseCase.Invoke(new LoginCommand(dto.Email, dto.Password));
            var responseData = new LoginResponseModel(accessToken);
            return ApiResult.Send(status, responseData, message, ModelState);
        }
        
        [HttpPost("Registration")]
        public async Task<ActionResult<UserResponseModel>> Registration(UserDTO dto)
        {
            var (status, user, message) = await _registrationUseCase.Invoke(new RegistrationCommand
            {
                User = new User { Email = dto.Email, Password = dto.Password }
            });
            var responseData = _mapper.Map<UserResponseModel>(user);
            return ApiResult.Send(status, responseData, message, ModelState, 200);
        }
    }
}