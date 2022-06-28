using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Services.Organization.Client;
using Movie_Cart.Data.Static;
using Movie_Cart.Models;

namespace Movie_Cart.Data
{
    public class AppDbInitializer
    {
       

        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var Context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                Context.Database.EnsureCreated();
                
                //Cinema
                if(!Context.Cinemas.Any())
                {
                    Context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Miraj Cinemas",
                            Logo = "~/Cinema_Logos/Miraj Cinemas.jpg",
                            Description = "Miraj Cinemas is a division of Miraj Entertainment Limited."
                        },

                        new Cinema()
                        {
                            Name = "Carnival Cinemas",
                            Logo = "~/Cinema_Logos/Carnival Cinemas.jpg",
                            Description= "Carnival Cinemas is a multiplex chain in India in 120 cities at 162 locations."
                        },

                        new Cinema()
                        {
                            Name = "PVR Cinemas",
                            Logo = "~/Cinema_Logos/PVR Cinemas.jpg",
                            Description= "PVR Ltd (formerly Priya Village Roadshow Ltd), doing business as PVR Cinemas."
                        },
                    });
                    Context.SaveChanges();

                      
                }
                //Actors
                if (!Context.Actors.Any())
                {
                    Context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName="Akshay Kumar",
                            Bio="Rajiv Hari Om Bhatia (born 9 September 1967),known professionally as Akshay Kumar, is an Indian-born naturalised Canadian actor and film producer.",
                            ProfilePicureUrl="~/Actors_Picture/Akshay_Kumar.jpg"
                        },
                        new Actor()
                        {
                            FullName="Sonu Sood",
                            Bio="Sonu Sood (born 30 July 1973) is an Indian actor, film producer, model, humanitarian, and philanthropist.",
                            ProfilePicureUrl="~/Actors_Picture/Sonu_Sood.jpg"
                        },
                        new Actor()
                        {
                            FullName="Manushi Chillar",
                            Bio="Manushi Chhillar (born 14 May 1997) is an Indian actress and model.",
                            ProfilePicureUrl="~/Actors_Picture/Manushi_Chillar.jpg"
                        },
                        new Actor()
                        {
                            FullName="Sanjay Dutt",
                            Bio="Sanjay Balraj Dutt (born 29 July 1959) is an Indian actor.",
                            ProfilePicureUrl="~/Actors_Picture/Sanjay_Dutt.jpg"
                        },

                        new Actor()
                        {
                            FullName="Yash",
                            Bio="Naveen Kumar Gowda (born 8 January 1986), better known by his stage name Yash, is an Indian actor.",
                            ProfilePicureUrl="~/Actors_Picture/Yash.jpg"
                        },
                        new Actor()
                        {
                            FullName="Srinidhi Shetty",
                            Bio="Srinidhi Ramesh Shetty (born 21 October 1992) is an Indian model, actress and beauty pageant titleholder.",
                            ProfilePicureUrl="~/Actors_Picture/Srinidhi_Shetty.jpg"
                        },

                        new Actor()
                        {
                            FullName="Adivi Sesh",
                            Bio="Adivi Sesh Sunny Chandra (born 17 December 1984) is an Indian actor, director and screenwriter.",
                            ProfilePicureUrl="~/Actors_Picture/Adivi_Sesh.jpg"
                        },
                        new Actor()
                        {
                            FullName="Prakash Raj",
                            Bio="Prakash Raj (born Prakash Rai; 26 March 1965) is an Indian actor, film director, producer, television presenter, and politician.",
                            ProfilePicureUrl="~/Actors_Picture/Prakash_Raj.jpg"
                        },



                        
                        new Actor()
                        {
                            FullName="Kartik Aaryan",
                            Bio="Kartik Aaryan Tiwari (born 22 November 1990), is an Indian actor who works in Hindi films.",
                            ProfilePicureUrl="~/Actors_Picture/Kartik_Aaryan.jpg"

                        },
                        new Actor()
                        {
                            FullName="Kiara Advani",
                            Bio="Alia Advani (born 31 July 1992), known professionally as Kiara Advani, is an Indian actress.",
                            ProfilePicureUrl="~/Actors_Picture/Kiara_Advani.jpg"
                        },
                        new Actor()
                        {
                            FullName="Rajpal Yadav",
                            Bio="Rajpal Naurang Yadav (born 16 March 1971) is an Indian actor, comedian, writer, film director and producer.",
                            ProfilePicureUrl="~/Actors_Picture/Rajpal_Yadav.jpg"
                        },

                        new Actor()
                        {
                            FullName="Kriti Sanon",
                            Bio="Kriti Sanon (born 27 July 1990) is an Indian actress who appears predominantly in Hindi films.",
                            ProfilePicureUrl="~/Actors_Picture/Kriti_Sanon.jpg"
                        },

                        new Actor()
                        {
                            FullName="Vijay",
                            Bio="Joseph Vijay Chandrasekhar (born 22 June 1974), known professionally as Vijay, is an Indian actor, dancer, playback singer and philanthropist.",
                            ProfilePicureUrl="~/Actors_Picture/Vijay.jpg"

                        },
                        new Actor()
                        {
                            FullName="Pooja Hegde",
                            Bio="Pooja Hegde (born 13 October 1990) is an Indian actress who appears predominantly in Telugu films.",
                            ProfilePicureUrl="~/Actors_Picture/Pooja_Hegde.jpg"

                        }

                        
                        
                          
                    });
                    Context.SaveChanges();

                }
                //Producers
                if (!Context.Producers.Any())
                {
                    Context.Producers.AddRange(new List<Producer>() 
                    {
                        new Producer()
                        {
                            FullName="Aditya Chopra",
                            Bio="Aditya Chopra (born 21 May 1971) is an Indian filmmaker who works in Hindi cinema.",
                            ProfilePicureUrl="~/Producers_Pictures/Aditya_chopra.jpg"
                        },
                        new Producer()
                        {
                            FullName="Vijay Kiragandur",
                            Bio="Vijay Kiragandur is an Indian film Producer, who has worked predominantly in Kannada movie industry.",
                            ProfilePicureUrl="~/Producers_Pictures/vijay-kiragandur.jpg"

                        },
                        new Producer()
                        {
                            FullName="Mahesh Babu",
                            Bio="Ghattamaneni Mahesh Babu (born 9 August 1975) is an Indian actor, producer, media personality, and philanthropist.",
                            ProfilePicureUrl="~/Producers_Pictures/Mahesh_Babu.jpg"
                        },
                        new Producer()
                        {
                            FullName="Bhushan Kumar",
                            Bio="Bhushan Kumar Dua (born 27 November 1977) is an Indian film producer and music producer.",
                            ProfilePicureUrl="~/Producers_Pictures/Bhushan_Kumar.jpg"
                        },
                        new Producer()
                        {
                            FullName="Sajid Nadiadwala",
                            Bio="Sajid Nadiadwala (born 18 February 1966) is an Indian film producer and director.",
                            ProfilePicureUrl="~/Producers_Pictures/Sajid_Nadiadwala.jpg"

                        },
                        new Producer()
                        {
                            FullName="Kalanithi Maran",
                            Bio="Kalanithi Murasoli Maran is an Indian media baron who is the chairman and founder of the Sun Group.",
                            ProfilePicureUrl="~/Producers_Pictures/Kalanidhi_maran.jpg"
                        }

                    });
                    Context.SaveChanges();
                }
                //Movies
                if (!Context.Movies.Any())
                {
                    Context.Movies.AddRange(new List<Movie>() 
                    {
                        new Movie()
                        {
                            Name="Samrat Prithviraj",
                            Description="Samrat Prithviraj is a 2022 Indian Hindi-language historical action drama film.",
                            Price=520,
                            ImageUrl="~/Movie_Pictures/Prithviraj_Poster.jpg",
                            StartDate=DateTime.Now.AddDays(-7),
                            EndDate=DateTime.Now.AddDays(25),
                            CinemaId=1,
                            ProducerId=1,
                            MovieCategory=Enums.MovieCategory.Action

                        },
                        new Movie()
                        {
                            Name="Kgf Chapter-2",
                            Description="K.G.F: Chapter 2 is a 2022 Indian Kannada-language period action film.",
                            Price=400,
                            ImageUrl="~/Movie_Pictures/K.G.F_Chapter_2.jpg",
                            StartDate=DateTime.Now.AddDays(-20),
                            EndDate=DateTime.Now.AddDays(25),
                            CinemaId=2,
                            ProducerId=2,
                            MovieCategory=Enums.MovieCategory.Action

                        },
                        new Movie()
                        {
                            Name="Major",
                            Description="Major is a 2022 Indian biographical action drama film.",
                            Price=700,
                            ImageUrl="~/Movie_Pictures/Major.jpg",
                            StartDate=DateTime.Now.AddDays(-5),
                            EndDate=DateTime.Now.AddDays(25),
                            CinemaId=3,
                            ProducerId=3,
                            MovieCategory=Enums.MovieCategory.Action

                        },
                        new Movie()
                        {
                            Name="Bhool Bhulaiyaa 2",
                            Description="Bhool Bhulaiyaa 2 is a 2022 Indian Hindi-language comedy horror film.",
                            Price=250,
                            ImageUrl="~/Movie_Pictures/Bhool_Bhulaiyaa_2.jpg",
                            StartDate=DateTime.Now.AddDays(-18),
                            EndDate=DateTime.Now.AddDays(30),
                            CinemaId=1,
                            ProducerId=4,
                            MovieCategory=Enums.MovieCategory.Horror

                        },
                        new Movie()
                        {
                            Name="Bachchhan Paandey",
                            Description="Bachchhan Paandey is a 2022 Indian Hindi-language action comedy film.",
                            Price=340,
                            ImageUrl="~/Movie_Pictures/Bachchhan_Paandey.jpg",
                            StartDate=DateTime.Now.AddDays(-30),
                            EndDate=DateTime.Now.AddDays(25),
                            CinemaId=2,
                            ProducerId=5,
                            MovieCategory=Enums.MovieCategory.Comedy

                        },
                        new Movie()
                        {
                            Name="Beast",
                            Description="Beast is a 2022 Indian Tamil-language action comedy film.",
                            Price=450,
                            ImageUrl="~/Movie_Pictures/Beast.jpg",
                            StartDate=DateTime.Now.AddDays(-14),
                            EndDate=DateTime.Now.AddDays(30),
                            CinemaId=3,
                            ProducerId=6,
                            MovieCategory=Enums.MovieCategory.Action

                        }

                    });
                    Context.SaveChanges();

                }
                //Actors nd Movies
                if (!Context.Actors_Movies.Any())
                {
                    Context.Actors_Movies.AddRange(new List<Actor_Movie>() 
                    {
                        //Samrat prithiviraaj
                        new Actor_Movie()
                        {
                            ActorId=1,
                            MovieId=1

                        },
                        new Actor_Movie()
                        {
                           ActorId=2,
                           MovieId=1

                        },
                        new Actor_Movie()
                        {
                            ActorId=3,
                            MovieId=1
                        },
                        new Actor_Movie()
                        {
                            ActorId=4,
                            MovieId=1
                        },

                        //Kgf chapter 2
                        new Actor_Movie()
                        {
                            ActorId =5,
                            MovieId =2
                        },
                        new Actor_Movie()
                        {
                            ActorId=6,
                            MovieId=2

                        },

                        //Major
                        new Actor_Movie()
                        {
                            ActorId=7,
                            MovieId=3

                        },
                        new Actor_Movie()
                        {
                            ActorId=8,
                            MovieId=3
                        },

                        //Bhool Bhulaiyaa-2
                        new Actor_Movie()
                        {
                            ActorId=9,
                            MovieId=4
                        },
                        new Actor_Movie()
                        {
                            ActorId=10,
                            MovieId=4
                        },
                        new Actor_Movie()
                        {
                            ActorId=11,
                            MovieId=4
                        },

                        //Bachchhan paandey
                        new Actor_Movie()
                        {
                            ActorId=1,
                            MovieId=5
                        },
                        new Actor_Movie()
                        {
                            ActorId=12,
                            MovieId=5
                        },

                        //Beast
                        new Actor_Movie()
                        {
                            ActorId=13,
                            MovieId=6
                        },
                        new Actor_Movie()
                        {
                            ActorId=14,
                            MovieId=6
                        }

                    });
                    Context.SaveChanges();

                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if(! await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@Movie.Cart.com";
                var adminUser = await userManager.FindByNameAsync(adminUserEmail);
                if(adminUser==null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Rahul@123");
                    await userManager.AddToRoleAsync(newAdminUser,UserRoles.Admin);
                }
                
                
                string appUserEmail = "user@Movie.Cart.com";
                var appUser = await userManager.FindByNameAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "App User",
                        UserName = "user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Rahul@123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
