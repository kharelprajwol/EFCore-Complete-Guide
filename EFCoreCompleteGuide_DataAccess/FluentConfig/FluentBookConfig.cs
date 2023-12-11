using EFCoreCompleteGuide_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCompleteGuide_DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            // Primary Key
            modelBuilder.HasKey(u => u.BookId);

            // Validations
            modelBuilder.Property(u => u.ISBN).HasMaxLength(100);
            modelBuilder.Property(u => u.ISBN).IsRequired();
            
            // Not Mapped
            modelBuilder.Ignore(u => u.PriceRange);

            // Relations
            modelBuilder.HasOne(b => b.Publisher).WithMany(b => b.Books).HasForeignKey(b => b.Publisher_Id);

        }

    }
}
