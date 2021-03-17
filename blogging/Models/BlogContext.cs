namespace blogging.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogContext : DbContext
    {
        public BlogContext()
            : base("name=BlogContext")
        {
        }

        public virtual DbSet<ARTICLE> ARTICLEs { get; set; }
        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<COMMENT> COMMENTs { get; set; }
        public virtual DbSet<FOLLOWINGAUTHOR> FOLLOWINGAUTHORs { get; set; }
        public virtual DbSet<PICTURE> PICTUREs { get; set; }
        public virtual DbSet<ROLE> ROLEs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAG> TAGs { get; set; }
        public virtual DbSet<USER> USERs { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ARTICLE>()
                .HasMany(e => e.COMMENTs)
                .WithRequired(e => e.ARTICLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ARTICLE>()
                .HasMany(e => e.PICTUREs)
                .WithOptional(e => e.ARTICLE)
                .HasForeignKey(e => e.ArticleID);

            modelBuilder.Entity<ARTICLE>()
                .HasMany(e => e.TAGs)
                .WithMany(e => e.ARTICLEs)
                .Map(m => m.ToTable("ArticleTag").MapLeftKey("ArticleID").MapRightKey("TagID"));

            modelBuilder.Entity<CATEGORY>()
                .HasMany(e => e.ARTICLEs)
                .WithRequired(e => e.CATEGORY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PICTURE>()
                .HasMany(e => e.ARTICLEs)
                .WithOptional(e => e.PICTURE)
                .HasForeignKey(e => e.PictureID);

            modelBuilder.Entity<PICTURE>()
                .HasMany(e => e.FOLLOWINGAUTHORs)
                .WithRequired(e => e.PICTURE)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROLE>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.ROLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.ARTICLEs)
                .WithOptional(e => e.USER)
                .HasForeignKey(e => e.WriterID);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.FOLLOWINGAUTHORs)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);
        }
    }
}
