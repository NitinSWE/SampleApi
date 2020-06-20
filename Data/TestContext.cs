using Microsoft.EntityFrameworkCore;
using sampleapi.Models;
namespace sampleapi.Data
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> opt) : base(opt)
        {

        }
        //Make a representation of model inside database
        public DbSet<Test> Tests { get; set; }
        public DbSet<QuestionBank> Questions { get; set; }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                .HasMany(t => t.Questions)
                .WithOne(q => q.Tests)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);
        }*/
    }
}