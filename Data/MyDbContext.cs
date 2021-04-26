using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Data
{
    public class MyDbContext : IdentityDbContext
    {
        private readonly DbContextOptions<MyDbContext> _options;

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>().ToTable("Books");

            builder.Entity<Book>()
                .HasKey(b => b.Id);

            builder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(c => c.CategoryId)
                .IsRequired();

            //--------------------------------------
            
            builder.Entity<User>().ToTable("Users");

            builder.Entity<User>()
                .HasKey(u => u.Id);

            //--------------------------------------

            builder.Entity<Category>().ToTable("Categories");

            builder.Entity<Category>()
                .HasKey(c => c.Id);

            //--------------------------------------

            builder.Entity<BorrowRequest>().ToTable("BorrowRequests");

            builder.Entity<BorrowRequest>()
                .HasKey(b => b.Id);

            builder.Entity<BorrowRequest>()
                .HasOne(b => b.User)
                .WithMany(u => u.BorrowRequests)
                .HasForeignKey(u => u.UserId)
                .IsRequired();

            //--------------------------------------

            builder.Entity<BorrowRequestDetail>().ToTable("BorrowRequestDetails");

            builder.Entity<BorrowRequestDetail>()
                .HasKey(b => new { b.BorrowRequestId, b.BookId });

            builder.Entity<BorrowRequestDetail>()
                .HasOne(br => br.Book)
                .WithMany(b => b.BorrowRequestDetails)
                .HasForeignKey(b => b.BookId)
                .IsRequired();

            builder.Entity<BorrowRequestDetail>()
                .HasOne(brd => brd.BorrowRequest)
                .WithMany(br => br.BorrowRequestDetails)
                .HasForeignKey(br => br.BorrowRequestId)
                .IsRequired();
        }
    }
}