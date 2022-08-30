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
    public class InfoConfiguration : IEntityTypeConfiguration<Info>
    {
        public void Configure(EntityTypeBuilder<Info> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Information)
              .HasColumnType("nvarchar(500)")
              .HasMaxLength(500);

            builder.Property(x => x.LastUpdate)
               .HasColumnType("date");

            builder.HasOne(x => x.Album)
              .WithOne(x => x.Info)
              .HasForeignKey<Info>(x => x.AlbumId);
        }
    }
}
