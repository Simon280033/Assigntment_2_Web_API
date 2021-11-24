using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Assigntment_2_Web_API
{
    public class DbAdultsService : IAdultsService
    {

        private AdultsAndUsersDbContext _adultsAndUsersDbContext;

        public DbAdultsService()
        {
            this._adultsAndUsersDbContext = new AdultsAndUsersDbContext();
        }
        
        public async Task<IList<Adult>> GetAdultsAsync()
        {
            List<Adult> tmp = new List<Adult>(_adultsAndUsersDbContext.Adults.Include(adult => adult.Job).ToList());
            Console.WriteLine("Returning all adults");
            return tmp;        
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            Console.WriteLine("Adding adult: " + adult.Id);
            _adultsAndUsersDbContext.Adults.Add(adult);
            _adultsAndUsersDbContext.SaveChanges();
            return adult;
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            Console.WriteLine("Removing adult: " + adultId);
            Adult toRemove = _adultsAndUsersDbContext.Adults.First(t => t.Id == adultId);
            _adultsAndUsersDbContext.Adults.Remove(toRemove);
            _adultsAndUsersDbContext.SaveChanges();
        }

        public async Task<Adult> UpdateAsync(Adult adult)
        {
            Console.WriteLine("Updating adult: " + adult.Id);
            Adult toUpdate = _adultsAndUsersDbContext.Adults.FirstOrDefault(t => t.Id == adult.Id);
            if(toUpdate == null) throw new Exception($"Did not find adult with id: {adult.Id}");
            // For some reason, we have to do each attribute manually, it doesn't work if we just do toUpdate = adult
            // Also, due to JobTitle being the primary key for Job, it can't be altered in this data structure
            // Therefore, editing jobs is not possible in this system.
            toUpdate.Id = toUpdate.Id; // Force the same
            toUpdate.FirstName = adult.FirstName;
            toUpdate.LastName = adult.LastName;
            toUpdate.HairColor = adult.HairColor;
            toUpdate.EyeColor = adult.EyeColor;
            toUpdate.Age = adult.Age;
            toUpdate.Weight = adult.Weight;
            toUpdate.Height = adult.Height;
            toUpdate.Sex = adult.Sex;
            _adultsAndUsersDbContext.SaveChanges();
            return toUpdate;        
        }
    }
}