﻿using Microsoft.EntityFrameworkCore;
using Platenumbers.Domain;
using Platenumbers.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateNumbers.Persistence.DatabaseContext
{
    public class PlateNumberContext : DbContext
    {
        public PlateNumberContext(DbContextOptions<PlateNumberContext> options) : base(options)
        {
            
        }

        public DbSet<PlateNumber> plateNumbers { get; set; }
        public DbSet<ReserveNumber> reserveNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlateNumberContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateCreated = DateTime.Now;

                if(entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }
                          
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
