namespace CarDealership3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Database : DbContext
    {
        public Database()
            : base("name=NewDBConnect")
        {
        }

        public virtual DbSet<make> makes { get; set; }
        public virtual DbSet<model> models { get; set; }
        public virtual DbSet<vehicle> vehicles { get; set; }
        public virtual DbSet<vehicleType> vehicleTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<make>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<model>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<model>()
                .Property(e => e.colour)
                .IsUnicode(false);

            modelBuilder.Entity<vehicle>()
                .Property(e => e.price)
                .HasPrecision(15, 2);

            modelBuilder.Entity<vehicle>()
                .Property(e => e.cost)
                .HasPrecision(15, 2);

            modelBuilder.Entity<vehicleType>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
