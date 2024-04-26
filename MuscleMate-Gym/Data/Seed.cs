using Microsoft.AspNetCore.Identity;
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
                                    Title = "Front Squat",
                                    Description = "Set a barbell on a power rack at about shoulder height. Grab the power with an overhand grip at shoulder width and raise your elbows until your upper arms are parallel to the floor. Take the bar out of the rack and let it rest on your fingertips. Your elbows should be all the way up throughout the movement. Step back and set your feet at shoulder width with toes turned out slightly. Squat as low as you can without losing the arch in your lower back.",
                                    URL = "https://i0.wp.com/www.muscleandfitness.com/wp-content/uploads/2015/09/Bulgarian-Split-Squat.jpg?quality=86&strip=all"
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
                                Title = "Deadlift",
                                Description = "Stand straight up with feet hip-width apart and shins one inch away from the bar. Grip the bar with a double pronated or reverse grip, bend knees and push them into your straight arms. Bring your chest up as much as possible and look straight ahead. Keeping your back flat, extend your hips to stand up, pulling the bar up along your legs to lockout.",
                                URL = "https://i0.wp.com/www.muscleandfitness.com/wp-content/uploads/2015/09/Deadlift-30bestlegexercises.jpg?quality=86&strip=all"
                            }
                        },
                        new Exercise()
                        {
                            Title = "BEST ARMS EXERCISES OF ALL TIME",
                            Image = "https://i0.wp.com/www.muscleandfitness.com/wp-content/uploads/2018/12/1109-Muscluar-Arms.jpg?quality=86&strip=all",
                            Description = "Compound barbell movements are necessary for building overall strength and a solid foundation for the rest of your body. But if you’re trying to focus on getting bigger arms and shoulders, squats and deadlifts alone aren’t enough to get you there because they aren’t targeting the triceps, biceps, forearms, and shoulders.",
                            ExerciseCategory = ExerciseCategory.Arms,
                            Detail = new Detail()
                            {
                                Title = "Chinup",
                                Description = "Grab the bar at (or slightly inside) shoulder width, with a supinated grip. While keeping core tight, pull yourself up until your chin is over the bar. Try not to use momentum to get your chin over the bar.",
                                URL = "https://i0.wp.com/www.muscleandfitness.com/wp-content/uploads/2018/03/1109-chinup0.jpg?quality=86&strip=all"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "ilyawebdeveloper@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "ilyshadev",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Detail = new Detail()
                        {
                            Title = "Chinup",
                            Description = "Grab the bar at (or slightly inside) shoulder width, with a supinated grip. While keeping core tight, pull yourself up until your chin is over the bar. Try not to use momentum to get your chin over the bar.",
                            URL = "https://i0.wp.com/www.muscleandfitness.com/wp-content/uploads/2018/03/1109-chinup0.jpg?quality=86&strip=all"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "@Coding1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "defaultuser@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "default-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Detail = new Detail()
                        {
                            Title = "Chinup",
                            Description = "Grab the bar at (or slightly inside) shoulder width, with a supinated grip. While keeping core tight, pull yourself up until your chin is over the bar. Try not to use momentum to get your chin over the bar.",
                            URL = "https://i0.wp.com/www.muscleandfitness.com/wp-content/uploads/2018/03/1109-chinup0.jpg?quality=86&strip=all"
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "@Coding1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
