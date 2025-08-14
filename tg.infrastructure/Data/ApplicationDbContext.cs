using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tg.domain.Entities;

namespace tg.infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public override DbSet<UserModel> Users { get; set; }
        public DbSet<SkillModel> Skills { get; set; }
        public DbSet<HobbyModel> Hobbies { get; set; }
        public DbSet<FollowerModel> Followers { get; set; }

        protected override void OnModelCreating(ModelBuilder modalBuilder)
        {
            base.OnModelCreating(modalBuilder);

            modalBuilder.Entity<UserModel>(builder =>
                {
                    builder
                        .ToTable("Users", tableBuilder =>
                        {
                            tableBuilder.HasCheckConstraint(
                                name: "CK_Username_NotLess_Five",
                                sql: $"LEN([{nameof(UserModel.UserName)}]) >= 5");
                        } )
                        .HasIndex(u => u.Email)
                        .IsUnique();
                    
                    builder
                        .HasIndex(u => u.UserName)
                        .IsUnique();

                    builder
                        .HasIndex(u => u.PhoneNumber)
                        .IsUnique();
                });

            modalBuilder.Entity<FollowerModel>(builder =>
            {
                builder
                    .HasOne(f => f.User)
                    .WithMany(u => u.Followers)
                    .HasForeignKey(f => f.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder
                    .HasOne(f => f.Follower)
                    .WithMany(u => u.Following)
                    .HasForeignKey(f => f.FollowerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

    }
}