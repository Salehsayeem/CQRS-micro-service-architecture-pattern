using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using TestCQRS.DTO.DepartmentDTO;
using TestCQRS.Helper;
using TestCQRS.IRepository;

namespace TestCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _IRepository;
        public DepartmentController(IDepartment IRepository)
        {
            _IRepository = IRepository;
        }
        [HttpPost]
        [Route("CreateDepartment")]
        [SwaggerOperation(Description = "Example { }")]
        public async Task<MessageHelper> CreateDepartment(CreateDepartmentDTO objCreate)
        {
            try
            {
                var msg = await _IRepository.CreateDepartment(objCreate);
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetDepartmentById")]
        [SwaggerOperation(Description = "Example { }")]
        public async Task<IActionResult> GetDepartmentById(long departmentId)
        {
            try
            {
                var dt = await _IRepository.GetDepartmentById(departmentId);
                if (dt == null)
                {
                    return NotFound();
                }
                return Ok(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
