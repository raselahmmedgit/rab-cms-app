using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PlacovuCMS.Model
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

        //private const string connectionString = @"data source=LAPTOP-UFF1V1E7\\SQLEXPRESS2016;initial catalog=PlacovuCMS;persist security info=True;user id=sa;password=12345;MultipleActiveResultSets=True;";

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
        public DbSet<EmailSmsConfig> EmailSmsConfig { get; set; }
        public DbSet<ContactUsConfig> ContactUsConfig { get; set; }
        public DbSet<EmailSmsHistory> EmailSmsHistory { get; set; }
        public DbSet<SiteInfo> SiteInfo { get; set; }
        public DbSet<SocialMediaConfig> SocialMediaConfig { get; set; }
        public DbSet<News> News { get; set; }
        public virtual DbSet<EmploymentApplication> EmploymentApplications { get; set; }
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

            modelBuilder.Entity<EmploymentApplication>(entity =>
            {
                entity.ToTable("EmploymentApplication");
                entity.HasKey(key => key.Id);
            });

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
