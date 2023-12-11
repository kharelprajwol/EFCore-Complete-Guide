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
    public class FluentBookAuthorMapConfig : IEntityTypeConfiguration<Fluent_BookAuthorMap>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthorMap> modelBuilder)
        {
            // Primary Key
            modelBuilder.HasKey(u => new { u.Author_Id, u.Book_Id });

            // Relations
            modelBuilder.HasOne(b => b.Book).WithMany(b => b.BookAuthorMap).HasForeignKey(b => b.Book_Id);
            modelBuilder.HasOne(b => b.Author).WithMany(b => b.BookAuthorMap).HasForeignKey(b => b.Author_Id);

        }

    }
}
