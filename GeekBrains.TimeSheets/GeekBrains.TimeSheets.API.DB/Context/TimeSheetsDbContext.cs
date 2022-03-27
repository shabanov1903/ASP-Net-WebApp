using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GeekBrains.TimeSheets.DB.Context
{
    public class TimeSheetsDbContext : DbContext
    {
        public TimeSheetsDbContext(DbContextOptions<TimeSheetsDbContext> options) : base(options)
        { }

        public DbSet<UserContext>? Users { get; set; }
        public DbSet<EmployeeContext>? Employees { get; set; }
        public DbSet<SheetContext>? Sheets { get; set; }
        public DbSet<InvoiceContext>? Invoices { get; set; }

        // Регистрация связей модели БД
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SheetContext>()
                .HasOne(p => p.Employee)
                .WithMany(b => b.Sheets);

            modelBuilder.Entity<SheetContext>()
                .HasOne(p => p.Invoice)
                .WithMany(b => b.Sheets);

            modelBuilder.Entity<UserContext>()
                .HasOne(p => p.Employee)
                .WithOne(b => b.User)
                .HasForeignKey<EmployeeContext>(sa => sa.UserId);

            modelBuilder.Entity<UserContext>()
                .HasOne(p => p.Invoice)
                .WithOne(b => b.User)
                .HasForeignKey<InvoiceContext>(sa => sa.UserId);
        }
    }
}
