﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiverBooks.Books.Data;
using Serilog;

namespace RiverBooks.Books;

public static class BookServiceExtensions
{
	public static IServiceCollection AddBookServices(
						this IServiceCollection services,
						ConfigurationManager config,
						ILogger logger)
	{
		string? connectionString = config.GetConnectionString("BooksConnectionString");

		services.AddDbContext<BookDbContext>(options => options.UseSqlServer(connectionString));
		services.AddScoped<IBookRepository, EfBookRepository>();
		services.AddScoped<IBookService, BookService>();

		logger.Information("Serviços do Módulo {Module} foram registrados.", "Books");

		return services;
	}
}
