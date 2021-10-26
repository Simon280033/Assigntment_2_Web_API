using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FileData;
using Models;

namespace Assigntment_2_Web_API
{
    public class AdultsService : IAdultsService
    {
        private FileContext fc;

        public AdultsService()
        {
            this.fc = new FileContext();
        }
        
        public async Task<IList<Adult>> GetAdultsAsync()
        {
            List<Adult> tmp = new List<Adult>(fc.Adults);
            return tmp;
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            fc.Adults.Add(adult);
            fc.SaveChanges();
            return adult;
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            Adult toRemove = fc.Adults.First(t => t.Id == adultId);
            fc.Adults.Remove(toRemove);
            fc.SaveChanges();
        }

        public async Task<Adult> UpdateAsync(Adult adult)
        {
            Adult toUpdate = fc.Adults.FirstOrDefault(t => t.Id == adult.Id);
            if(toUpdate == null) throw new Exception($"Did not find adult with id: {adult.Id}");
            toUpdate = adult;
            fc.SaveChanges();
            return toUpdate;        
        }
    }
}