using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assigntment_2_Web_API
{
    public interface IAdultsService
    {
        Task<IList<Adult>> GetAdultsAsync();
        Task<Adult>   AddAdultAsync(Adult adult);
        Task   RemoveAdultAsync(int todoId);
        Task<Adult>   UpdateAsync(Adult adult);
    }
}