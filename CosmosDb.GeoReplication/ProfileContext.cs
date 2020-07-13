using CosmosDb.GeoReplication.EntityConfiguration;
using CosmosDb.GeoReplication.Model;
using Microsoft.EntityFrameworkCore;

namespace CosmosDb.GeoReplication
{
    public class ProfileContext:DbContext
    {

        public DbSet<Profile> Profiles { get; set; }

        public ProfileContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfileEntityConfiguration());
        }
    }
}
