using ServicesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesAPI.Repository
{
    public interface IServRepos
    {
        IEnumerable<Services> GetAllServices();
        Task<Services> PostServices(Services item);
        Task<Services> UpdateServiceByResident(Services item, int id);
        Task<Services> UpdateServiceByEmployee(Services item, int id);


    }
}
