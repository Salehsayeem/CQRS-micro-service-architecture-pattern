using System.Threading.Tasks;
using TestCQRS.DTO.DepartmentDTO;
using TestCQRS.Helper;
using TestCQRS.IRepository;
using TestCQRS.Models;
using System.Linq;
namespace TestCQRS.Repository
{
    public class Department : IDepartment
    {
        private readonly CQRSDatabaseContext _context;

        public Department(CQRSDatabaseContext context)
        {
            _context = context;
        }
        public async Task<MessageHelper> CreateDepartment(CreateDepartmentDTO objCreate)
        {
            var model = new Models.Department();
            model.Name = objCreate.Name;
            model.Code = objCreate.Code;

            await _context.Department.AddAsync(model);
            await _context.SaveChangesAsync();

            var msg = new MessageHelper();
            msg.Message = "created successfully";
            msg.statuscode = 200;
            return msg;
        }

        public async Task<GetDepartmentByIdDTO> GetDepartmentById(long DepartmentId)
        {
            var data = await Task.FromResult((from a in _context.Department
                                              where a.Id == DepartmentId
                                              select new GetDepartmentByIdDTO
                                              {
                                                  Id = a.Id,
                                                  Name = a.Name,
                                                  Code = a.Code
                                              }).FirstOrDefault());
            return data;
        }
    }
}
