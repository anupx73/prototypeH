namespace PrototypeH2.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Booking : DbContext
    {
        public Booking()
            : base("name=Booking")
        {
        }

        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credential>()
                .Property(e => e.usertype)
                .IsFixedLength();

            modelBuilder.Entity<Credential>()
                .Property(e => e.username)
                .IsFixedLength();

            modelBuilder.Entity<Credential>()
                .Property(e => e.userpwd)
                .IsFixedLength();

            modelBuilder.Entity<Guest>()
                .Property(e => e.phone)
                .IsFixedLength();

            modelBuilder.Entity<Guest>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Guest>()
                .Property(e => e.identityno)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.customerph)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.cutomername)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.roomno)
                .IsFixedLength();

            modelBuilder.Entity<Room>()
                .Property(e => e.type)
                .IsFixedLength();

            modelBuilder.Entity<Room>()
                .Property(e => e.beds)
                .IsFixedLength();
        }
    }
}
