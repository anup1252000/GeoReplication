using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosDb.GeoReplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CosmosDb.GeoReplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController:ControllerBase
    {
        private readonly ProfileContext profileContext;
        private readonly IConfiguration configuration;

        public ProfileController(ProfileContext profileContext,IConfiguration configuration)
        {
            this.profileContext = profileContext;
            this.configuration = configuration;
            profileContext.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult GetApiLocation()
        {
            return Ok(configuration.GetValue<string>("ApiServerRegion"));
        }

        [HttpGet("/profile")]
        public ActionResult<IEnumerable<Profile>> GetAllProfiles()
        {
            return Ok(profileContext.Profiles.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfile(Profile profile)
        {
            await profileContext.Profiles.AddAsync(profile);
            await profileContext.SaveChangesAsync();
            return Ok();
        }
    }
}
