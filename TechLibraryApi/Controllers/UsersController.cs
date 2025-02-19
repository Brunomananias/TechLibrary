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
        public IActionResult Create(RequestUserJson request) 
        {
            try
            {
                RegisterUserUseCase useCase = new RegisterUserUseCase();
                var response = useCase.Execute(request);
                return Created(string.Empty, response);
            }
            catch(TechLibraryException ex)
            {
                return BadRequest(new ResponseErrorMessagesJson
                {
                    Errors = ex.GetErrorMessages()
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson
                {
                    Errors = ["Erro Desconhecido"]
                });
            }
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Created();
        }
    }
}
