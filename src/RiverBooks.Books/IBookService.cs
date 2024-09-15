namespace RiverBooks.Books;

//Referências estão internas para não precisar expor a DI do BookService
//Isso é discutível, pois ultimamente, quanto menos mágica, melhor para se manter.
//Mas vou atender à literatura e manter isto internal.
internal interface IBookService
{
	Task<List<BookDto>> ListBooksAsync();
	Task<BookDto> GetBookByIdAsync(Guid id);
	Task CreateBookAsync(BookDto newBook);
	Task DeleteBookAsync(Guid id);
	Task UpdateBookPriceAsync(Guid bookId, decimal newPrice);
}
