using FastEndpoints;

namespace RiverBooks.Books.BookEndpoints;
internal class Create(IBookService bookService) : Endpoint<CreateBookRequest, BookDto>
{

	public override void Configure()
	{
		Post("/books");
		AllowAnonymous();
	}

	public override async Task HandleAsync(CreateBookRequest req, CancellationToken ct)
	{
		var newBookDto = new BookDto(req.Id ?? Guid.NewGuid(),
				req.Title,
				req.Author,
				req.Price);

		await bookService.CreateBookAsync(newBookDto);
		await SendCreatedAtAsync<GetById>(new { newBookDto.Id }, newBookDto);
	}

}
