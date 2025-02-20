using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechLibraryApi.Services;
using TechLibraryApi.UseCases.Checkouts;

namespace TechLibraryApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CheckoutsController : ControllerBase
    {
        [HttpPost]
        [Route("{bookId}")]
        [Authorize]
        public IActionResult BookCheckout(Guid bookId)
        {
            var loggedUser = new LoggedUserService(HttpContext);

            var useCase = new RegisterBookCheckoutUseCase(loggedUser);

            useCase.Execute(bookId);

            return NoContent();
        }
    }
}
