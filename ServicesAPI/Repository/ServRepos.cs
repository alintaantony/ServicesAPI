using ServicesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesAPI.Repository
{
    public class ServRepos : IServRepos
    {
        private readonly CommunityGateDatabaseContext _context;

        public ServRepos()
        {

        }
        public ServRepos(CommunityGateDatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Services> GetAllServices()
        {
            return _context.Services.ToList();
        }
        public async Task<Services> PostServices(Services item)
        {
            Services service = null;
            if(item == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                service = new Services() { ServiceType = item.ServiceType, AppointmentTime = item.AppointmentTime, ServiceStatus = "Requested", ServiceMessage = item.ServiceMessage, ServicePrice = item.ServicePrice, EmployeeId = item.EmployeeId, ResidentId = item.ResidentId };
                await _context.Services.AddAsync(service);
                await _context.SaveChangesAsync();
            }
            return service;
        }

        public async Task<Services> UpdateServiceByResident(Services item,int id)
        {
            Services service = await _context.Services.FindAsync(id);
            service.ServiceType = item.ServiceType;
            service.AppointmentTime = item.AppointmentTime;
            service.ServiceMessage = item.ServiceMessage;
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<Services> UpdateServiceByEmployee(Services item, int id)
        {
            Services service = await _context.Services.FindAsync(id);
            service.ServiceStatus = item.ServiceStatus;
            service.ServicePrice = item.ServicePrice;
            await _context.SaveChangesAsync();
            return service;
        }

    }
}
