
namespace RiverBooks.Books;

internal class BookService(IBookRepository bookRepository) : IBookService
{
	public async Task CreateBookAsync(BookDto newBook)
	{
		var book = new Book(newBook.Id, newBook.Title, newBook.Author, newBook.Price);
		await bookRepository.AddAsync(book);
		await bookRepository.SaveChangesAsync();
	}

	public async Task DeleteBookAsync(Guid id)
	{
		var book = await bookRepository.GetByIdAsync(id);
		if (book is not null)
		{
			await bookRepository.DeleteAsync(book);
		}
	}

	public async Task<BookDto> GetBookByIdAsync(Guid id)
	{
		var book = await bookRepository.GetByIdAsync(id);
		//TODO: tratar quando não encontrado
		return new BookDto(book!.Id, book.Title, book.Author, book.Price);
	}

	public async Task<List<BookDto>> ListBooksAsync()
	{
		var books = (await bookRepository.ListAsync())
														.Select(x => new BookDto(x.Id, x.Title, x.Author, x.Price))
														.ToList();
		return books;
	}

	public async Task UpdateBookPriceAsync(Guid bookId, decimal newPrice)
	{
		var book = await bookRepository.GetByIdAsync(bookId);
		//TODO: tratar quando não encontrado

		book!.UpdatePrice(newPrice);
		await bookRepository.SaveChangesAsync();

	}
}
