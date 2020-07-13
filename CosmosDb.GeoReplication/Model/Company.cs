using System;
namespace CosmosDb.GeoReplication.Model
{
    public class Company
    {
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
