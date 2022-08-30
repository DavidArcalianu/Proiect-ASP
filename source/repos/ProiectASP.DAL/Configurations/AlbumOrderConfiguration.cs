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
    public class AlbumOrderConfiguration : IEntityTypeConfiguration<AlbumOrder>
    {
        public void Configure(EntityTypeBuilder<AlbumOrder> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Album)
                 .WithMany(x => x.AlbumOrders)
                 .HasForeignKey(x => x.AlbumId);

            builder.Property(x => x.Quantity)
                .HasPrecision(5, 0)
                .IsRequired();

            builder.HasOne(x => x.Order)
                .WithMany(x => x.AlbumOrders)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
