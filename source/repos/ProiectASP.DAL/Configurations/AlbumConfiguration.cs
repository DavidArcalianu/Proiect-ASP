using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProiectASP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectASP.DAL.Configurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Genre)
                .HasColumnType("nvarchar(15)")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.Image)
             .HasColumnType("nvarchar(500)")
             .HasMaxLength(500);
        }
    }
}
