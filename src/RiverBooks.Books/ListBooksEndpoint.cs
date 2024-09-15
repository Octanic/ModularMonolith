using FastEndpoints;

namespace RiverBooks.Books;
// https://fast-endpoints.com
internal class ListBooksEndpoint(IBookService bookService) :
        EndpointWithoutRequest<ListBooksResponse>
{
    private readonly IBookService _bookService = bookService;
    public override void Configure()
    {
        Get("/books");
        AllowAnonymous();
    }

    // REPR
    public override async Task HandleAsync(CancellationToken ct = default)
    {
        var books = await _bookService.ListBooksAsync();

        await SendAsync(new ListBooksResponse()
        {
            Books = books
        });
    }

}
