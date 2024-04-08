using MuscleMate_Gym.Data.Enum;
using MuscleMate_Gym.Models;

namespace MuscleMate_Gym.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Exercises.Any())
                {
                    context.Exercises.AddRange(new List<Exercise>()
                    {
                        new Exercise()
                        {
                            Title = "Exercises for Strengthening Every Muscle in Your Arms",
                            Image = "https://images.everydayhealth.com/images/healthy-living/fitness/best-exercises-for-stronger-arm-muscles-hero-1440x720.jpg?w=768",
                            Description = "There are three main sections of the arms, namely the anterior (front), posterior (back), and shoulders, and you want to make sure you’re training all three sections, says Mecayla Froerer, an executive at the fitness technology company iFIT and a National Academy of Sports Medicine (NASM)–certified personal trainer who is based in North Salt Lake, Utah.",
                            ExerciseCategory = ExerciseCategory.Arms,
                            Detail = new Detail()
                            {
                                    Title = "Biceps Curl",
                                    Description = "Stand with your feet shoulder-width apart, holding a weight in each hand. Starting with the weights by your thighs, palms facing forward, and elbows glued to hips, lift weights toward shoulders, keeping your shoulders stabilized. Release to start; that’s one rep. Lift and lower in a controlled manner — two seconds up, and two seconds down. Repeat.",
                                    URL = "https://images.everydayhealth.com/images/healthy-living/fitness/best-exercises-for-stronger-arm-muscles-bicep-curl.gif?w=768"
                            }
                        },
                        new Exercise()
                        {
                            Title = "Best Leg Exercises of All Time",
                            Image = "https://hips.hearstapps.com/vidthumb/images/2019-menshealth-formcheck-ep07-deadlift-sm-editorinitials-v3-1551367600.jpg?crop=1.00xw:1.00xh;0,0&resize=1200:*",
                            Description = "Master these leg exercises to pack muscle and size onto your glutes, quads, and hamstrings.",
                            ExerciseCategory = ExerciseCategory.Legs,
                                Detail = new Detail()
                                {
                                    Title = "Biceps Curl",
                                    Description = "Stand with your feet shoulder-width apart, holding a weight in each hand. Starting with the weights by your thighs, palms facing forward, and elbows glued to hips, lift weights toward shoulders, keeping your shoulders stabilized. Release to start; that’s one rep. Lift and lower in a controlled manner — two seconds up, and two seconds down. Repeat.",
                                    URL = "https://images.everydayhealth.com/images/healthy-living/fitness/best-exercises-for-stronger-arm-muscles-bicep-curl.gif?w=768"
                                },

                        },
                        new Exercise()
                        {
                            Title = "Strength Training for Legs",
                            Image = "https://www.verywellfit.com/thmb/om-wRsKSoXcrGf5ktJ92xixb5As=/768x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/GettyImages-867345580-5af1464e642dca0037da0f57-850b7a69b1e842b99ef60a5d9bf5b6a6.jpg",
                            Description = "This is a comprehensive guide to strengthen your legs through effective training exercises.",
                            ExerciseCategory = ExerciseCategory.Legs,
                            Detail = new Detail()
                            {
                                Title = "Squats",
                                Description = "Squats are one of the best exercises for building strength and muscle in the legs. Stand with your feet shoulder-width apart, lower your body as if you're sitting back into a chair, keeping your chest up and back straight. Return to standing position and repeat.",
                                URL = "https://www.verywellfit.com/thmb/b7c2g3kNePHvcJUQmpYvU56jYTI=/768x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/GettyImages-1211086106-9632288b9b3e4eb2b09ed10466d1f871.jpg"
                            }
                        },
                        new Exercise()
                        {
                            Title = "Arm Workouts for Strength and Definition",
                            Image = "https://www.verywellfit.com/thmb/dkYmv-ErQKKD5m34iZm1eT9tQO0=/768x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/GettyImages-1196831669-17d9516359a64882a50478101d3acfe4.jpg",
                            Description = "Discover effective arm workouts to build strength and define your muscles.",
                            ExerciseCategory = ExerciseCategory.Arms,
                            Detail = new Detail()
                            {
                                Title = "Biceps Curl",
                                Description = "Biceps curls target the biceps muscles in the arms. Stand with feet shoulder-width apart, hold dumbbells at your sides with palms facing forward, curl the weights toward your shoulders, then lower them back down. Repeat for desired reps.",
                                URL = "https://www.verywellfit.com/thmb/jpUx9WYj9dQjQ-9PNEPd--BXieY=/768x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/GettyImages-1177469381-f80a116ff7854df08eece6f7d3200d24.jpg"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        //        string adminUserEmail = "teddysmithdeveloper@gmail.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new AppUser()
        //            {
        //                UserName = "teddysmithdev",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Charlotte",
        //                    State = "NC"
        //                }
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //        }

        //        string appUserEmail = "user@etickets.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new AppUser()
        //            {
        //                UserName = "app-user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Charlotte",
        //                    State = "NC"
        //                }
        //            };
        //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        //}
    }
}
