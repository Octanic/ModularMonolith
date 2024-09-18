using FastEndpoints;
using FastEndpoints.Testing;
using RiverBooks.Books.BookEndpoints;
using Xunit.Abstractions;
using FluentAssertions;

namespace RiverBooks.Books.Tests.Endpoints;
public class BookList(Fixture fixture, ITestOutputHelper outputHelper) :
	TestBase<Fixture>()
{
	private readonly ITestOutputHelper _outputHelper = outputHelper;
	[Fact]
	public async Task ReturnsThreeBooksAsync()
	{
		var testResult = await fixture.Client.GETAsync<List, ListBooksResponse>();

		testResult.Response.EnsureSuccessStatusCode();
		testResult.Result.Books.Count.Should().Be(3);
	}
}
