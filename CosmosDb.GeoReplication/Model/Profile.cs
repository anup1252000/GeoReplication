using System;
using System.Collections.Generic;

namespace CosmosDb.GeoReplication.Model
{
    public class Profile
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string Designation { get; set; }
        public Company CurrentCompany { get; set; }
        public string HighestEducation { get; set; }
        public ICollection<Company> PreviousCompanies { get; set; }
        public string UserId { get; set; }
    }
}
