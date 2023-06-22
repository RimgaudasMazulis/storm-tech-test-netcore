using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoLists;
using Todo.Models.Gravatar;
using Todo.Models.TodoLists;
using Todo.Services;

namespace Todo.Controllers
{
    public class GravatarController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUserStore<IdentityUser> userStore;

        public GravatarController(ApplicationDbContext dbContext, IUserStore<IdentityUser> userStore)
        {
            this.dbContext = dbContext;
            this.userStore = userStore;
        }

        [HttpGet]
        public async Task<GravatarProfile> GetProfile(string email)
        {
            return await Gravatar.GetProfile("https://www.gravatar.com", email);
        }        
    }
}