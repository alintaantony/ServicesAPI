using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesAPI.Models;
using ServicesAPI.Models.ViewModels;
using ServicesAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ServicesController));
        private readonly IServRepos _context;

        public ServicesController(IServRepos context)
        {
            _context = context; 
        }
        [HttpGet]
        public IEnumerable<Services> GetAllServices()
        {
            _log4net.Info("Get All Services Was Called !!");
            return _context.GetAllServices();
        }
        [HttpGet("{id}")]
        public IEnumerable<ServiceDetails> GetServicesByResidentId(int id)
        {
            _log4net.Info("Get Services For Resident With ID " + id + " Was Called !!");
            var item = _context.GetServiceByResidentId(id);
            return item;
        }
        [HttpPost]
        public async Task<IActionResult> PostServices(Services item)
        {
            _log4net.Info("Post Services Was Called !!");
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var addService = await _context.PostServices(item);
                return Ok(addService);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("ResidentItem/{id}")]
        public async Task<IActionResult> UpdateServiceByResident(Services item, int id)
        {
            _log4net.Info("Update Service By Resident Was Called !!");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updateServiceByResident = await _context.UpdateServiceByResident(item, id);
                _log4net.Info("Update Service By Resident with Id " + id + " Was Called !!");
                return Ok(updateServiceByResident);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("EmployeeItem/{id}")]
        public async Task<IActionResult> UpdateServiceByEmployee(Services item, int id)
        {
            _log4net.Info("Update Service By Employee Was Called !!");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updateServiceByEmployee = await _context.UpdateServiceByEmployee(item, id);
                _log4net.Info("Update Service By Employee with Id " + id + " Was Called !!");
                return Ok(updateServiceByEmployee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
