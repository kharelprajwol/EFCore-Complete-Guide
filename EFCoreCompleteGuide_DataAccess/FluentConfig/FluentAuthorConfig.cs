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
    public class FluentAuthorConfig : IEntityTypeConfiguration<Fluent_Author>
    {
        public void Configure(EntityTypeBuilder<Fluent_Author> modelBuilder)
        {
            // Primary Key
            modelBuilder.HasKey(u => u.Author_Id);

            // Validations
            modelBuilder.Property(u => u.FirstName).HasMaxLength(100);
            modelBuilder.Property(u => u.FirstName).IsRequired();
            modelBuilder.Property(u => u.LastName).IsRequired();|
            
            // Not Mapped
            modelBuilder.Ignore(u => u.FullName);

        }

    }
}
