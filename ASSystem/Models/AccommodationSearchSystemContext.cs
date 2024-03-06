using Microsoft.EntityFrameworkCore;

namespace ASSystem.Models
{
    public partial class AccommodationSearchSystemContext : DbContext
    {
        public AccommodationSearchSystemContext()
        {
        }

        public AccommodationSearchSystemContext(DbContextOptions<AccommodationSearchSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Convenient> Convenients { get; set; } = null!;
        public virtual DbSet<Motel> Motels { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomImage> RoomImages { get; set; } = null!;
        public virtual DbSet<Vote> Votes { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => new { e.Username, e.Phone, e.Email }, "IX_Account")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.DeleteAt)
                    .HasColumnType("date")
                    .HasColumnName("deleteAt");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Convenient>(entity =>
            {
                entity.ToTable("Convenient");

                entity.Property(e => e.ConvenientId).HasColumnName("ConvenientID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Motel>(entity =>
            {
                entity.ToTable("Motel");

                entity.Property(e => e.MotelId).HasColumnName("MotelID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Address).HasMaxLength(1000);

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.Contact).HasMaxLength(255);

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.DeleteAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleteAt");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.District).HasMaxLength(255);

                entity.Property(e => e.MaxPrice).HasColumnType("money");

                entity.Property(e => e.MinPrice).HasColumnType("money");

                entity.Property(e => e.Tittle).HasMaxLength(255);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId)
                    .ValueGeneratedNever()
                    .HasColumnName("PaymentID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Payment_Account");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.Acreage).HasMaxLength(200);

                entity.Property(e => e.DeleteAt).HasColumnType("date");

                entity.Property(e => e.MotelId).HasColumnName("MotelID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.UnitPrice).HasMaxLength(255);

                entity.HasOne(d => d.Motel)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.MotelId)
                    .HasConstraintName("FK_Room_Motel");

                entity.HasMany(d => d.Covenients)
                    .WithMany(p => p.Rooms)
                    .UsingEntity<Dictionary<string, object>>(
                        "Facility",
                        l => l.HasOne<Convenient>().WithMany().HasForeignKey("Covenient").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Facility_Convenient"),
                        r => r.HasOne<Room>().WithMany().HasForeignKey("RoomId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Facility_Room"),
                        j =>
                        {
                            j.HasKey("RoomId", "Covenient").HasName("PK_Facility_1");

                            j.ToTable("Facility");

                            j.IndexerProperty<int>("RoomId").HasColumnName("RoomID");
                        });
            });

            modelBuilder.Entity<RoomImage>(entity =>
            {
                entity.ToTable("RoomImage");

                entity.Property(e => e.RoomImageId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoomImageID");

                entity.Property(e => e.ImageDetail)
                    .HasMaxLength(255)
                    .HasColumnName("imageDetail");

                entity.Property(e => e.PathImageDetail)
                    .HasMaxLength(255)
                    .HasColumnName("pathImageDetail");

                entity.Property(e => e.RoomId).HasColumnName("roomID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomImages)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomImage_Room");
            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.RoomId });

                entity.ToTable("Vote");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.ReviewStar)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vote_Account");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vote_Room");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
