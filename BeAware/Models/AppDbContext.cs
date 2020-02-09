using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeAware.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<FiledReport> Reports { get; set; }
        public DbSet<ValidationRequest> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FiledReport>().HasNoKey();
            modelBuilder.Entity<ValidationRequest>().HasNoKey();
            modelBuilder.Entity<Location>().HasNoKey();
            //modelBuilder.Entity<User>().HasData(SeedUserData());

            //Seed some data
            

            base.OnModelCreating(modelBuilder);
        }

        public User SeedUserData()
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
