using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RiverBooks.Books;
internal class EfBookRepository : IBookRepository
{
	private readonly BookDbContext _dbContext;

	public EfBookRepository(BookDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task AddAsync(Book book)
	{
		await _dbContext.AddAsync(book);
	}

	public Task DeleteAsync(Book book)
	{
		_dbContext.Remove(book);
		return Task.CompletedTask;
	}

	public async Task<Book?> GetByIdAsync(Guid id)
	{
		return await _dbContext.Books.FindAsync(id);

	}

	public async Task<List<Book>> ListAsync()
	{
		return await _dbContext.Books.ToListAsync();
	}

	public async Task SaveChangesAsync()
	{
		await _dbContext.SaveChangesAsync();
	}
}
