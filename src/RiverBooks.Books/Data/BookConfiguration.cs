using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Books.Data;
internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
	internal static readonly Guid Sample1 = new Guid("E47A0547-FF77-488F-9D2D-CF4AD659CF37");
	internal static readonly Guid Sample2 = new Guid("79329A9F-FAC7-4F86-8224-E4E3792F0CE6");
	internal static readonly Guid Sample3 = new Guid("0203517E-DC92-42C3-B6D5-267ADEC4FAEC");
	public void Configure(EntityTypeBuilder<Book> builder)
	{
		builder.Property(p => p.Title)
			.HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
			.IsRequired();

		builder.Property(p => p.Author)
			.HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
			.IsRequired();

		builder.HasData(GetSampleBookData());
	}

	private IEnumerable<Book> GetSampleBookData()
	{
		var tolkien = "J.R.R. Tolkien";
		yield return new Book(Sample1, "A Sociedade do Anel", tolkien, 10.99m);
		yield return new Book(Sample2, "As Duas Torres", tolkien, 14.99m);
		yield return new Book(Sample3, "O Retorno do Rei", tolkien, 19.99m);
	}
}
