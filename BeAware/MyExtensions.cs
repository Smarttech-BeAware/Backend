using BeAware.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeAware
{
    public static class MyExtensions
    {
        public static IHost MigrateDatabase(this IHost webHost)
        {
            // Manually run any outstanding migrations if configured to do so
            var envAutoMigrate = Environment.GetEnvironmentVariable("AUTO_MIGRATE");
            if (envAutoMigrate != null && envAutoMigrate == "true")
            {
                Console.WriteLine("*** AUTO MIGRATE ***");

                var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));

                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var dbContext = services.GetRequiredService<AppDbContext>();

                    var seed = Environment.GetEnvironmentVariable("SEED");
                    //seed user data
                    if(seed == "true")
                    {
                        dbContext.Database.EnsureCreated();
                        var user = SeedUserData();
                        dbContext.Users.Add(user);
                        dbContext.SaveChanges();
                    }
                    
                    //end seed

                    dbContext.Database.Migrate();
                }
            }

            return webHost;
        }

        public static User SeedUserData()
        {
            var user = new User()
            {
                Name = "Emmanuel",
                Email = "emmanuel@smart.com",
                Password = "emmanuel@smart.com",
                Devices = new List<Device>()
                {
                    new Device()
                    {
                        Name = "Rita",
                        WhatsApp = "Hello What's up",
                        Messenger = "How are you doing?",
                        Map = new List<Location>()
                        {
                            new Location()
                            {
                                Latitude = "6.5537807",
                                Longitude = "3.366543",
                                Time = "random time"
                            },
                            new Location()
                            {
                                Latitude = "6.6141927",
                                Longitude = "3.3562408",
                                Time = "random time"
                            },
                            new Location()
                            {
                                Latitude = "6.5514361",
                                Longitude = "3.3746513",
                                Time = "random time"
                            }
                        }
                    },
                    new Device()
                    {
                        Name = "Ekene",
                        WhatsApp = "Hello What's up",
                        Messenger = "How are you doing?",
                        Map = new List<Location>()
                        {
                            new Location()
                            {
                                Latitude = "7.6125908",
                                Longitude = "5.1670672",
                                Time = "random time"
                            },
                            new Location()
                            {
                                Latitude = "7.7795976",
                                Longitude = "5.3132664",
                                Time = "random time"
                            },
                            new Location()
                            {
                                Latitude = "7.5908088",
                                Longitude = "4.9778706",
                                Time = "random time"
                            }
                        }
                    },
                    new Device()
                    {
                        Name = "Doyin",
                        WhatsApp = "Hello What's up",
                        Messenger = "How are you doing?",
                        Map = new List<Location>()
                        {
                            new Location()
                            {
                                Latitude = "8.4990397",
                                Longitude = "4.5838174",
                                Time = "random time"
                            },
                            new Location()
                            {
                                Latitude = "8.4928467",
                                Longitude = "4.5940338",
                                Time = "random time"
                            },
                            new Location()
                            {
                                Latitude = "8.4822187",
                                Longitude = "4.5445378",
                                Time = "random time"
                            }
                        }
                    }

                }
            };
            return user;
        }
    }
}
