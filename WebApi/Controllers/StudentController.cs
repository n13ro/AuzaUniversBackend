using BusinessLogic.Services.Stud;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StudentController(IStudentService studentService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task GetAll(CancellationToken cancellationToken)
        {
            await studentService.GetAllStudentServiceAsync(cancellationToken);
        }
        [HttpGet("GetById")]
        public async Task GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            await studentService.GetByIdStudentServiceAsync(id, cancellationToken);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(string Name, string FirstName, string LastName, string Email, string Phone, CancellationToken cancellationToken)
        {
            await studentService.AddStudentServiceAsync(Name, FirstName, LastName, Email, Phone, cancellationToken);
            return Ok(new {mess = "Student is created"}); 
        }
        //[HttpPut("Update")]
        //public async Task UpdateAsync(Student student, CancellationToken cancellationToken)
        //{
        //    await studentService.UpdateAsync();
        //}
        [HttpDelete("Delete")]
        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await studentService.DeleteStudentServiceAsync(id, cancellationToken);
        }
    }
}
