using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using RiverBooks.Books.BookEndpoints;
using Xunit.Abstractions;

namespace RiverBooks.Books.Tests.Endpoints;

public class BookGetById(Fixture fixture, ITestOutputHelper outputHelper) :
	TestBase<Fixture>()
{
	private readonly ITestOutputHelper _outputHelper = outputHelper;

	[Theory]
	[InlineData("e47a0547-ff77-488f-9d2d-cf4ad659cf37", "A Sociedade do Anel")]
	[InlineData("79329a9f-fac7-4f86-8224-e4e3792f0ce6", "As Duas Torres")]
	[InlineData("0203517e-dc92-42c3-b6d5-267adec4faec", "O Retorno do Rei")]
	public async Task ReturnsExpectedBookGivenIdAsync(string validId, string expectedTitle)
	{
		Guid id = Guid.Parse(validId);
		var request	 = new GetBookByIdRequest { Id = id };

		var testResult = await fixture.Client.GETAsync<GetById, GetBookByIdRequest, BookDto>(request);

		testResult.Response.EnsureSuccessStatusCode();
		testResult.Result.Title.Should().Be(expectedTitle);
	}
}
