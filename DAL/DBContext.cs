using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Migrations.Configuration;

namespace DAL
{
    public class DBContext : DbContext
    {
        public DBContext() : base(@"Data Source=.\SQLSERVER;Initial Catalog=EnglichForChildrens;Integrated Security=True")

        {
            Database.SetInitializer<DBContext>(new MyContextInitializer());
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Audio> Audios { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>()
                .HasMany(x => x.Words)
                .WithRequired(x => x.Topic)
                .HasForeignKey(x => x.TopicId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topic>()
                .HasMany(x => x.Audio)
                .WithRequired(x => x.Topic)
                .HasForeignKey(x => x.TopicId);

            modelBuilder.Entity<Word>()
                .HasMany(x => x.Audios)
                .WithRequired(x => x.Word)
                .HasForeignKey(x => x.WordId)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Word>()
            //    .HasRequired(x => x.Topic)
            //    .WithRequiredDependent()
            //    .WillCascadeOnDelete(false);

        }
    }
}
