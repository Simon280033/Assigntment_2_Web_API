using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Models;

namespace Assigntment_2_Web_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //SeedDbFromJson();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        
        private static async void SeedDbFromJson()
        {

            FileContext fc = new FileContext();
            Console.WriteLine("Adults in FC: " + fc.Adults.Count); 

            

                IList<Adult> adults = fc.Adults;

                List<string> jobtitles = new List<string>();
                List<int> ids = new List<int>();


                for (int i = 0; i < adults.Count; i++)
                {
                    if (ids.Contains(adults[i].Id))
                    {
                        Console.WriteLine("ID " + adults[i].Id + "is already used!");
                    }
                    else
                    {
                        using AdultsAndUsersDbContext lb = new AdultsAndUsersDbContext();

                        await lb.Adults.AddAsync(adults[i]);
                        await lb.SaveChangesAsync();
                        ids.Add(adults[i].Id);
                    }
                }
                
            Console.WriteLine("running");
            using (AdultsAndUsersDbContext lb = new AdultsAndUsersDbContext())
            {
                List<Adult> families = lb.Adults.ToList();
                Console.WriteLine("Adults: " + families.Count); 
            }
        }
    }
    
    
}