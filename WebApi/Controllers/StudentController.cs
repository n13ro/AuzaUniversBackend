using BusinessLogic.Services.Stud;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentController(IStudentService studentService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync(string Name, string FirstName, string LastName, string Email, string Phone)
        {
            await studentService.AddAsync(Name, FirstName, LastName, Email, Phone);
            return Ok(new {mess = "Student is created"}); 
        }
    }
}
