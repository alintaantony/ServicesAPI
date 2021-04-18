using ServicesAPI.Models;
using ServicesAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesAPI.Repository
{
    public interface IServRepos
    {
        IEnumerable<ServiceDetails> GetAllServices();
        Services GetServiceByServiceId(int id);
        Task<Services> PostServices(Services item);
        Task<Services> UpdateServiceByResident(Services item, int id);
        Task<Services> UpdateServiceByEmployee(Services item, int id);

        IEnumerable<ServiceDetails> GetServiceByResidentId(int id);

        Task<Services> UpdateServiceStatusByEmployee(Services item, int id);


    }
}
