namespace RiverBooks.Books;

internal class BookService : IBookService
{
    public List<BookDto> ListBooks()
    {
        return [
            new BookDto(Guid.NewGuid(), "Don't make me think", "Steve Krug"),
            new BookDto(Guid.NewGuid(), "What if?", "Ranfall Munroe"),
        ];
    }
}
