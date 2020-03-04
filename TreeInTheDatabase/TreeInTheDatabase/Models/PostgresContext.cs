using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeInTheDatabase.Models
{
    public class PostgresContext: DbContext
    {
        public DbSet<Node> Nodes { get; set; }
        public DbSet<ChangesNode> ChangesNodes { get; set; }

        public PostgresContext(DbContextOptions<PostgresContext> options)
            :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>()
                .HasMany(x => x.ChangesNodes)
                .WithOne(x => x.Node)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
