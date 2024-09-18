using FastEndpoints;
using FluentValidation;

namespace RiverBooks.Books.BookEndpoints;
public record UpdateBookPriceRequest(Guid Id, decimal NewPrice);

public class UpdateBookPriceRequestValidator : Validator<UpdateBookPriceRequest>
{
	public UpdateBookPriceRequestValidator()
	{
		RuleFor(x => x.Id)
				.NotNull()
				.NotEqual(Guid.Empty)
				.WithMessage("Um Id de livro é necessário");

		RuleFor(x => x.NewPrice)
				.GreaterThanOrEqualTo(0)
				.WithMessage("Preço não pode ser negativo");

	}
}
