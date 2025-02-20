using TechLibrary.Exception;
using TechLibraryApi.Domain.Entities;
using TechLibraryApi.Infrastructure.DataAccess;
using TechLibraryApi.Services;

namespace TechLibraryApi.UseCases.Checkouts
{
    public class RegisterBookCheckoutUseCase
    {
        private const int MAX_LOAN_DAYS = 7;
        private readonly LoggedUserService _loggedUserService;

        public RegisterBookCheckoutUseCase(LoggedUserService loggedUser)
        {
            _loggedUserService = loggedUser;
        }
        public void Execute(Guid bookId)
        {
            var dbContext = new TechLibraryDbContext();

            Validate(bookId, dbContext);

            var user = _loggedUserService.User(dbContext);

            var entity = new Checkout
            {
                UserId = user.Id,
                BookId = bookId,
                ExpectedReturnDate = DateTime.UtcNow.AddDays(MAX_LOAN_DAYS),
            };

            dbContext.Checkouts.Add(new Checkout
            {

            });

            dbContext.SaveChanges();
        }

        private void Validate(Guid bookId, TechLibraryDbContext dbContext) 
        {
            var book = dbContext.Books.FirstOrDefault(book => book.Id == bookId);

            if (book == null) 
            {
                throw new NotFoundException("Livro não encontrado. ");
            }

            var amountBookNotReturned = dbContext
                .Checkouts
                .Count(checkout => book.Id == bookId && checkout.ReturnedDate == null);

            if (amountBookNotReturned < book.Amount) 
            {
                throw new ConflictException("Livro não está disponível para emprestímo.");
            }
        
        } 
    }
}
