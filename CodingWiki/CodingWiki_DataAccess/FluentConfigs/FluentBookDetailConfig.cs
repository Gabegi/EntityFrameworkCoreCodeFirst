using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki_DataAccess.FluentConfigs
{
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            // no need to have Entity<Fluent_BookDetail>() anymore as we are using IEntityTypeConfiguration
            modelBuilder.HasOne(b => b.Book)
                        .WithOne(bd => bd.BookDetail)
                        .HasForeignKey<Fluent_BookDetail>(b => b.BookId);
        }
    }
}
