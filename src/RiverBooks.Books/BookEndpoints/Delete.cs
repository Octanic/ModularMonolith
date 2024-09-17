using FastEndpoints;

namespace RiverBooks.Books.BookEndpoints;
internal class Delete(IBookService bookService) : Endpoint<DeleteBookRequest>
{
	public override void Configure()
	{
		Delete("/books/{Id}");
		AllowAnonymous();
	}
	public override async Task HandleAsync(DeleteBookRequest req, CancellationToken ct)
	{
		//TODO: notfound
		await bookService.DeleteBookAsync(req.Id);
		await SendNoContentAsync();
	}
}
