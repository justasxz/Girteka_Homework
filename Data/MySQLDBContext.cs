using Girteka_Homework.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Girteka_Homework.Data;

public class MySqlDBContext : DbContext
{
    public MySqlDBContext() { }
    public MySqlDBContext(DbContextOptions<MySqlDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Session>()
        //    .HasOne(session => session.CreatedByUser)
        //    .WithMany(user => user.Sessions);

        //modelBuilder.Entity<User>()
        //    .HasIndex(user => user.Email)
        //    .IsUnique();
    }

    public DbSet<Electronic_Data> Electronic_Data { get; set; }

}