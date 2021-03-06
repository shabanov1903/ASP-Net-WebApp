// <auto-generated />
using System;
using GeekBrains.TimeSheets.DB.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeekBrains.TimeSheets.DB.Migrations
{
    [DbContext(typeof(TimeSheetsDbContext))]
    [Migration("20220218092915_lesson5")]
    partial class lesson5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("GeekBrains.TimeSheets.DB.Context.EmployeeContext", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("GeekBrains.TimeSheets.DB.Context.SheetContext", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ApprovedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Sheets");
                });

            modelBuilder.Entity("GeekBrains.TimeSheets.DB.Context.UserContext", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GeekBrains.TimeSheets.DB.Context.EmployeeContext", b =>
                {
                    b.HasOne("GeekBrains.TimeSheets.DB.Context.UserContext", "User")
                        .WithOne("Employee")
                        .HasForeignKey("GeekBrains.TimeSheets.DB.Context.EmployeeContext", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GeekBrains.TimeSheets.DB.Context.SheetContext", b =>
                {
                    b.HasOne("GeekBrains.TimeSheets.DB.Context.EmployeeContext", "Employee")
                        .WithMany("Sheets")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("GeekBrains.TimeSheets.DB.Context.EmployeeContext", b =>
                {
                    b.Navigation("Sheets");
                });

            modelBuilder.Entity("GeekBrains.TimeSheets.DB.Context.UserContext", b =>
                {
                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
