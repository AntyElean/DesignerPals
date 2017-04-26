using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using DesignerPals.Models;
using System.Collections.Generic;

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
                 new Q
                 {
                     Name = "ThimbleGirl",
                     Question = "What is a quicker way to tie thread when sewing by hand?",
                     Answers = new List<A>{
                         new A {
                             Name = "SewSarah",
                             Answer = " Wrap the thread around your finger four to five times with the end sticking out. Pull it off your finger and the end up by rubbing it."
                            },
                         new A {
                             Name = "BabySeamstress",
                             Answer = "Wrap thread around finger 3 - 5 times with with end sticking out. Pull thread through the loop after you slide it off your fingerand pull until knot forms"
                            }
                     }
                 },
                new Q
                {
                    Name = "SewSarah",
                    Question = "How do I get this darn thread through the eye of the needle?!",
                    Answers = new List<A> {
                            new A {
                                Name = "ThimbleGirl",
                                Answer =  " Make sure you trim the end of the thread with fabric scissors!"
                            }
                        }
                }
               );
                // Ensure Anty (IsAdmin)
                var anty = await userManager.FindByNameAsync("ThatsSewAnty@CoderCamps.com");
                if (anty == null)
                {
                    // create user
                    anty = new ApplicationUser
                    {
                        UserName = "ThatsSewAnty",
                        Email = "ThatsSewAnty@CoderCamps.com"
                    };
                    await userManager.CreateAsync(anty, "Secret123!");

                    // add claims
                    await userManager.AddClaimAsync(anty, new Claim("IsAdmin", "true"));
                }

                // Ensure Thimblina (not IsAdmin)
                var thimblina = await userManager.FindByNameAsync("Thimblegirl87@CoderCamps.com");
                if (thimblina == null)
                {
                    // create user
                    thimblina = new ApplicationUser
                    {
                        UserName = "Thimblegirl",
                        Email = "Thimblegirl87@CoderCamps.com"
                    };
                    await userManager.CreateAsync(thimblina, "Secret123!");
                }

                context.SaveChanges();
            }

        }
    }
}

