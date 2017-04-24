using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using DesignerPals.Models;

namespace DesignerPals.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();
            //Sample Q
            if (!context.Qs.Any())
            {
                context.Qs.AddRange(
                 new Q { UserName = "ThimbleGirl", Question = "What is a quicker way to tie thread when sewing by hand?" },
                new Q { UserName = "SewSarah", Question = "How do I get this darn thread through the eye of the needle?!" },
                new Q { UserName = "ThatsSewAnty", Question= "Can you name a project you thought was the hardest thing ever and then you realized it was easy when you became more experienced(Mine was a vogue pattern dress with a million pleats)?"}
                );
                context.SaveChanges();
               
            }
            // Ensure Stephen (IsAdmin)
            var anty = await userManager.FindByNameAsync("ThatsSewAnty@CoderCamps.com");
            if (anty == null)
            {
                // create user
                anty = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "ThatsSewAnty@CoderCamps.com"
                };
                await userManager.CreateAsync(anty, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(anty, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var thimblina = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (thimblina == null)
            {
                // create user
                thimblina = new ApplicationUser
                {
                    UserName = "Thimblegirl87@CoderCamps.com",
                    Email = "Thimblegirl87@CoderCamps.com"
                };
                await userManager.CreateAsync(thimblina, "Secret123!");
            }


        }

    }
}
