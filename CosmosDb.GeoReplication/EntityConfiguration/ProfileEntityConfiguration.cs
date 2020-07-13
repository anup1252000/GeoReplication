using System;
using CosmosDb.GeoReplication.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CosmosDb.GeoReplication.EntityConfiguration
{
    public class ProfileEntityConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.HasPartitionKey(x => x.UserId);
            builder.OwnsOne(x => x.CurrentCompany);
            builder.OwnsMany(x => x.PreviousCompanies);
        }
    }
}
