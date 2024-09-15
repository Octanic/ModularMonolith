using FastEndpoints;

namespace RiverBooks.Books;
internal class UpdateBookPriceEndpoint(IBookService bookService) :
	Endpoint<UpdateBookPriceRequest, BookDto>
{
	public override void Configure()
	{
		Post("/books/{Id}/pricehistory");
		AllowAnonymous();
	}

	public override async Task HandleAsync(UpdateBookPriceRequest req, CancellationToken ct)
	{
		//TODO: notfound
		await bookService.UpdateBookPriceAsync(req.Id, req.NewPrice);
		var updated = await bookService.GetBookByIdAsync(req.Id);

		await SendAsync(updated, cancellation: ct);
	}
}
