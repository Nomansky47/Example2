using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Example2
{
    public partial class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyContext")
        {
        }
        private static MyContext _context { get; set; }
        public static MyContext Get()
        {
            if (_context==null)
            {
                _context = new MyContext();
            }
            return _context;
        }
        public virtual DbSet<Citizens> Citizens { get; set; }
        public virtual DbSet<Marriages> Marriages { get; set; }
        public virtual DbSet<UserAccounts> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citizens>()
                .Property(e => e.PassportNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Citizens>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Citizens>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Citizens>()
                .Property(e => e.Patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<Citizens>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Citizens>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Citizens>()
                .Property(e => e.MaritalStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Citizens>()
                .HasMany(e => e.Marriages)
                .WithOptional(e => e.Citizens)
                .HasForeignKey(e => e.HusbandPassportNumber);

            modelBuilder.Entity<Marriages>()
                .Property(e => e.HusbandPassportNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Marriages>()
                .Property(e => e.WifePassportNumber)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccounts>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccounts>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
