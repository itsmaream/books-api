using test.Models;

namespace test.Repo
{
    public class InMemBookRepo : IBook
    {
        private List<Book> _Books;
        public InMemBookRepo()
        {
            _Books = new() { new Book { Id = Guid.NewGuid(), Title = "Book 0", Description = "red Book and have one handerd pages", Price = 12 } };
        }
        public void CreateBook(Book book)
        {
           _Books.Add(book);
        }

        public void DeleteBook(Guid id)
        {
            var bookIndex = _Books.FindIndex(x => x.Id == id);
            if(bookIndex>-1)
              _Books.RemoveAt(bookIndex);
        }

        public Book GetBook(Guid id)
        {
            var book = _Books.Where(x=>x.Id==id).FirstOrDefault();
            return book;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _Books;
        }

        public void UpdateBook(Guid id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
