using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Repo;

namespace test.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController:ControllerBase
    {
        private IBook _BookRepo;
        public BookController(IBook bookRepo)
        {
            //_BookRepo = new InMemBookRepo();
            _BookRepo = bookRepo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return _BookRepo.GetBooks().ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(Guid id)
        {
            var book=_BookRepo.GetBook(id);
            if(book == null)
                return NotFound();
            return book;
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(Guid id)
        {
            var book = _BookRepo.GetBook(id);
            if(book == null) 
                return NotFound();
            _BookRepo.DeleteBook(id);
            return Ok();
        }
    }
}
