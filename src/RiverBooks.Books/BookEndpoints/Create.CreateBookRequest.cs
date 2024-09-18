using FastEndpoints;
using FluentValidation;

namespace RiverBooks.Books.BookEndpoints;
internal class CreateBookRequest
{
	public Guid? Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Author { get; set; } = string.Empty;
	public decimal Price { get; set; }
}

internal class CreateBookRequestValidator : Validator<CreateBookRequest>
{
	public CreateBookRequestValidator()
	{
		RuleFor(x => x.Id)
					.NotNull()
					.NotEqual(Guid.Empty)
					.WithMessage("Um Id de livro é necessário");

		RuleFor(x => x.Price)
				.GreaterThanOrEqualTo(0)
				.WithMessage("Preço não pode ser negativo");

		RuleFor(x => x.Title)
			.NotEmpty()
			.WithMessage("Insira o nome do livro");

		RuleFor(x => x.Author)
			.NotEmpty()
			.WithMessage("Insira o nome do autor");

	}
}
