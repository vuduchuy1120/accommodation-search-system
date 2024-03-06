﻿// <auto-generated />
using System;
using ASSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoJWT.Migrations
{
    [DbContext(typeof(AccommodationSearchSystemContext))]
    partial class AccommodationSearchSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DemoJWT.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"), 1L, 1);

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("date")
                        .HasColumnName("deleteAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "Username", "Phone", "Email" }, "IX_Account")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("DemoJWT.Models.Convenient", b =>
                {
                    b.Property<int>("ConvenientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ConvenientID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConvenientId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ConvenientId");

                    b.ToTable("Convenient", (string)null);
                });

            modelBuilder.Entity("DemoJWT.Models.Motel", b =>
                {
                    b.Property<int>("MotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MotelID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MotelId"), 1L, 1);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    b.Property<string>("Address")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("City")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Contact")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Country")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime")
                        .HasColumnName("deleteAt");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("District")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal?>("MaxPrice")
                        .HasColumnType("money");

                    b.Property<decimal?>("MinPrice")
                        .HasColumnType("money");

                    b.Property<int?>("QuantityEmptyRooms")
                        .HasColumnType("int");

                    b.Property<string>("Tittle")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MotelId");

                    b.ToTable("Motel", (string)null);
                });

            modelBuilder.Entity("DemoJWT.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .HasColumnType("int")
                        .HasColumnName("PaymentID");

                    b.Property<int?>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("date");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("RoomID");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PaymentId");

                    b.HasIndex("AccountId");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("DemoJWT.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("DemoJWT.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoomID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"), 1L, 1);

                    b.Property<string>("Acreage")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("date");

                    b.Property<int?>("MotelId")
                        .HasColumnType("int")
                        .HasColumnName("MotelID");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.Property<int?>("Quanlity")
                        .HasColumnType("int");

                    b.Property<string>("UnitPrice")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("RoomId");

                    b.HasIndex("MotelId");

                    b.ToTable("Room", (string)null);
                });

            modelBuilder.Entity("DemoJWT.Models.RoomImage", b =>
                {
                    b.Property<int>("RoomImageId")
                        .HasColumnType("int")
                        .HasColumnName("RoomImageID");

                    b.Property<string>("ImageDetail")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("imageDetail");

                    b.Property<string>("PathImageDetail")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("pathImageDetail");

                    b.Property<int>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("roomID");

                    b.HasKey("RoomImageId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomImage", (string)null);
                });

            modelBuilder.Entity("DemoJWT.Models.Vote", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    b.Property<int>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("RoomID");

                    b.Property<string>("ReviewStar")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.HasKey("AccountId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("Vote", (string)null);
                });

            modelBuilder.Entity("Facility", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("RoomID");

                    b.Property<int>("Covenient")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "Covenient")
                        .HasName("PK_Facility_1");

                    b.HasIndex("Covenient");

                    b.ToTable("Facility", (string)null);
                });

            modelBuilder.Entity("DemoJWT.Models.Account", b =>
                {
                    b.HasOne("DemoJWT.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_Account_Role");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DemoJWT.Models.Payment", b =>
                {
                    b.HasOne("DemoJWT.Models.Account", "Account")
                        .WithMany("Payments")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_Payment_Account");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DemoJWT.Models.Room", b =>
                {
                    b.HasOne("DemoJWT.Models.Motel", "Motel")
                        .WithMany("Rooms")
                        .HasForeignKey("MotelId")
                        .HasConstraintName("FK_Room_Motel");

                    b.Navigation("Motel");
                });

            modelBuilder.Entity("DemoJWT.Models.RoomImage", b =>
                {
                    b.HasOne("DemoJWT.Models.Room", "Room")
                        .WithMany("RoomImages")
                        .HasForeignKey("RoomId")
                        .IsRequired()
                        .HasConstraintName("FK_RoomImage_Room");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("DemoJWT.Models.Vote", b =>
                {
                    b.HasOne("DemoJWT.Models.Account", "Account")
                        .WithMany("Votes")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK_Vote_Account");

                    b.HasOne("DemoJWT.Models.Room", "Room")
                        .WithMany("Votes")
                        .HasForeignKey("RoomId")
                        .IsRequired()
                        .HasConstraintName("FK_Vote_Room");

                    b.Navigation("Account");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Facility", b =>
                {
                    b.HasOne("DemoJWT.Models.Convenient", null)
                        .WithMany()
                        .HasForeignKey("Covenient")
                        .IsRequired()
                        .HasConstraintName("FK_Facility_Convenient");

                    b.HasOne("DemoJWT.Models.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .IsRequired()
                        .HasConstraintName("FK_Facility_Room");
                });

            modelBuilder.Entity("DemoJWT.Models.Account", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Votes");
                });

            modelBuilder.Entity("DemoJWT.Models.Motel", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("DemoJWT.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("DemoJWT.Models.Room", b =>
                {
                    b.Navigation("RoomImages");

                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
