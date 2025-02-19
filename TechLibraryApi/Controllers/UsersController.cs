using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;
using TechLibraryApi.UseCases.Users.Register;

namespace TechLibraryApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register(RequestUserJson request)
        {
            var useCase = new RegisterUserUseCase();
            var response = useCase.Execute(request);
            return Created(string.Empty, response);
        }
    }
}
