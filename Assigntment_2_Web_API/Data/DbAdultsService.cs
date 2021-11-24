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
            return tmp;        
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            Console.WriteLine("Adding adult " + adult.Id);
            _adultsAndUsersDbContext.Adults.Add(adult);
            _adultsAndUsersDbContext.SaveChanges();
            return adult;
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            Adult toRemove = _adultsAndUsersDbContext.Adults.First(t => t.Id == adultId);
            _adultsAndUsersDbContext.Adults.Remove(toRemove);
            _adultsAndUsersDbContext.SaveChanges();
        }

        public async Task<Adult> UpdateAsync(Adult adult)
        {
            Adult toUpdate = _adultsAndUsersDbContext.Adults.FirstOrDefault(t => t.Id == adult.Id);
            if(toUpdate == null) throw new Exception($"Did not find adult with id: {adult.Id}");
            toUpdate = adult;
            _adultsAndUsersDbContext.SaveChanges();
            return toUpdate;        
        }
    }
}