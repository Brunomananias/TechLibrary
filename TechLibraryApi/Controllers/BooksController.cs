using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibraryApi.UseCases.Books.Filter;

namespace TechLibraryApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet("Filter")]
        [ProducesResponseType(typeof(ResponseBooksJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]        
        public IActionResult Filter(int pageNumber, string? title)
        {
            var useCase = new FilterBookUseCase();

            var result = useCase.Execute(new RequestFilterBooksJson
            {
                PageNumber = pageNumber,
                Title = title
            });

                return Ok(result);
        }
    }
}
