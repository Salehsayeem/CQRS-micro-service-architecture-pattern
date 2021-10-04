using System.Threading.Tasks;
using TestCQRS.DTO.DepartmentDTO;
using TestCQRS.Helper;

namespace TestCQRS.IRepository
{
    public interface IDepartment
    {
        public Task<MessageHelper> CreateDepartment(CreateDepartmentDTO objCreate);
        public Task<GetDepartmentByIdDTO> GetDepartmentById(long DepartmentId);

    }
}
