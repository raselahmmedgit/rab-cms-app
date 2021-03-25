using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using CMS.App.ViewModels;
using System.IO;

namespace CMS.App.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //private const string connectionString = @"data source=LAPTOP-UFF1V1E7\\SQLEXPRESS2016;initial catalog=ContactProfileApp;persist security info=True;user id=sa;password=12345;MultipleActiveResultSets=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogCategory> BlogCategory { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<Order> Order { get; set; }

        //public DbSet<MediaDate> MediaDate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Non mapped database property so column in database table will not create for it*/
            modelBuilder.Entity<Blog>().Ignore(e => e.PrimaryImageUrl);
            modelBuilder.Entity<Media>().Ignore(e => e.ThumbUrl);
            modelBuilder.Entity<Media>().Ignore(e => e.MediaDate);
            modelBuilder.Entity<Media>().Ignore(e => e.Result);
            modelBuilder.Entity<Media>().Ignore(e => e.DisplayUrl);
            modelBuilder.Entity<Media>().Ignore(e => e.FileSize);
            modelBuilder.Entity<Media>().Ignore(e => e.FileType);
            modelBuilder.Entity<Media>().Ignore(e => e.Dimension);
            modelBuilder.Entity<Order>().Ignore(e => e.UserName);
            modelBuilder.Entity<Order>().Ignore(e => e.Email);
            modelBuilder.Entity<Order>().Ignore(e => e.PhoneNumber);
            modelBuilder.Entity<Order>().Ignore(e => e.CourseName);
            modelBuilder.Entity<Order>().Ignore(e => e.CourseUrl);
            //modelBuilder.Ignore<MediaDate>();
            /*End*/

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.AddedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.MetaDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MetaKeyword)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BlogCategory>(entity =>
            {
                entity.Property(e => e.AddedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.MetaDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MetaKeyword)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.Property(e => e.AddedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Alt)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.AddedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.Property(e => e.AddedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.MetaDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MetaKeyword)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.AddedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CourseId)
                    .IsRequired();

                entity.Property(e => e.ValidatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(true);
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
