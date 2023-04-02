using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platenumbers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateNumbers.Persistence.Configurations
{
    public class PlateNumberConfiguration : IEntityTypeConfiguration<PlateNumber>
    {
        public void Configure(EntityTypeBuilder<PlateNumber> builder)
        {
            //builder.Property(q => q.Number)
            //    .IsRequired()
            //    .IsFixedLength(true);      
        }
    }
}
