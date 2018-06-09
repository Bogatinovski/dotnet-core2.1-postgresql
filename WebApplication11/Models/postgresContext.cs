using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication11.Models
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Albums> Albums { get; set; }
        public virtual DbSet<ArticleCategories> ArticleCategories { get; set; }
        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<ArticleTags> ArticleTags { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<EventSports> EventSports { get; set; }
        public virtual DbSet<EventUsers> EventUsers { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Sports> Sports { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForNpgsqlHasEnum(null, "cover_media_type", new[] { "none", "photo", "video" })
                .ForNpgsqlHasEnum("so", "cover_media_type", new[] { "none", "photo", "video" })
                .HasPostgresExtension("adminpack");

            modelBuilder.Entity<Albums>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("nextval('so.albums_id_seq'::regclass)");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<ArticleCategories>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("nextval('so.article_categories_id_seq'::regclass)");
            });

            modelBuilder.Entity<Articles>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("nextval('so.articles_id_seq'::regclass)");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("fk_articles_albums");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_articles_article_categories");
            });

            modelBuilder.Entity<ArticleTags>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("nextval('so.article_tags_id_seq'::regclass)");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleTags)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_article_tags_articles");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ArticleTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_article_tags_tags");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("nextval('so.comments_id_seq'::regclass)");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_comments_articles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_comments_users");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasIndex(e => e.ReportId)
                    .HasName("unique_report_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('so.events_id_seq'::regclass)");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Announcement)
                    .WithMany(p => p.EventsAnnouncement)
                    .HasForeignKey(d => d.AnnouncementId)
                    .HasConstraintName("fk_events_articles");

                entity.HasOne(d => d.Report)
                    .WithOne(p => p.EventsReport)
                    .HasForeignKey<Events>(d => d.ReportId)
                    .HasConstraintName("fk_events_reports");

                entity.HasOne(d => d.Sport)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.SportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_events_sports");
            });

            modelBuilder.Entity<EventSports>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("nextval('so.event_sports_id_seq'::regclass)");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventSports)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_event_sports_events");

                entity.HasOne(d => d.Sport)
                    .WithMany(p => p.EventSports)
                    .HasForeignKey(d => d.SportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_event_sports_sports");
            });

            modelBuilder.Entity<EventUsers>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("nextval('so.event_users_id_seq'::regclass)");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventUsers)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_event_users_events");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_event_users_users");
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("nextval('so.images_id_seq'::regclass)");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_images_albums");
            });

            modelBuilder.Entity<Sports>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("nextval('so.sports_id_seq'::regclass)");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasIndex(e => e.Title)
                    .HasName("unique_tags_title")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('so.tags_id_seq'::regclass)");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("nextval('so.users_id_seq'::regclass)");
            });

            modelBuilder.HasSequence<int>("albums_id_seq");

            modelBuilder.HasSequence<int>("article_categories_id_seq");

            modelBuilder.HasSequence<int>("article_tags_id_seq");

            modelBuilder.HasSequence<int>("articles_id_seq");

            modelBuilder.HasSequence<int>("comments_id_seq");

            modelBuilder.HasSequence<int>("event_sports_id_seq");

            modelBuilder.HasSequence<int>("event_users_id_seq");

            modelBuilder.HasSequence<int>("events_id_seq");

            modelBuilder.HasSequence<int>("images_id_seq");

            modelBuilder.HasSequence<int>("sports_id_seq");

            modelBuilder.HasSequence<int>("tags_id_seq");

            modelBuilder.HasSequence<int>("users_id_seq");
        }
    }
}
