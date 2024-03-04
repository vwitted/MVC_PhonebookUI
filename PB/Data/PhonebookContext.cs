using Microsoft.EntityFrameworkCore;
using PB.Models;

namespace PB.Data
{

    public class PhonebookUIContext : DbContext

    {
        public PhonebookUIContext() {  }
        public virtual DbSet<Phonebook> Phonebooks { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }


        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phonebook>().ToTable("Phonebook");
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<PhoneNumber>().ToTable("PhonebookNumber");
            modelBuilder.Entity<Phonebook>().HasKey(p => p.PhonebookId);
            modelBuilder.Entity<Contact>().HasKey(c => c.ContactId);
            modelBuilder.Entity<PhoneNumber>().HasKey(p => p.PhoneNumberId);
            modelBuilder.Entity<PhoneNumber>().HasOne(c => c.Contact).WithMany(pn => pn.Numbers).HasForeignKey(p => p.ContactId);
            modelBuilder.Entity<Contact>().HasOne(p => p.Phonebook).WithMany(b => b.Contacts).HasForeignKey(p => p.PhonebookId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=PHIL\MSSQLSERVER10;Initial Catalog=PhonebookUI;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
    }

}
