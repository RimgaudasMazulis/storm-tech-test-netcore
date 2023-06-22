using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.Interfaces.Cache;
using Todo.Models.Gravatar;
using Todo.Services;

namespace Todo.Controllers
{
    public class GravatarController : Controller
    {
        private readonly ICache cache;
        public GravatarController(ICache cache)
        {
            this.cache = cache;
        }

        [HttpGet]
        public async Task<GravatarProfile> GetProfile(string email)
        {
            var profile = cache.Get<GravatarProfile>(email);

            if (profile == null)
            {
                profile = await Gravatar.GetProfile("https://www.gravatar.com", email);
                cache.Set(email, profile, TimeSpan.FromHours(1));
            }

            return profile;
        }        
    }
}