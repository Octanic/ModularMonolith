namespace RiverBooks.Books;

//Referências estão internas para não precisar expor a DI do BookService
//Isso é discutível, pois ultimamente, quanto menos mágica, melhor para se manter.
//Mas vou atender à literatura e manter isto internal.
internal interface IBookService
{
    List<BookDto> ListBooks();
}
