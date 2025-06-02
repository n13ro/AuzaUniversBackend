using BusinessLogic.DTOs.Stud;
using BusinessLogic.Services.PairService;
using BusinessLogic.Services.Stud;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Stud;

namespace WebApi.Controllers.StudV1Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    
    public class StudentController(IStudentService studentService) : ControllerBase
    {

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var students = await studentService.GetAllStudentServiceAsync(cancellationToken); 
            return Ok(new {success = true, data = students });
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var oneStudent = await studentService.GetByIdStudentServiceAsync(id, cancellationToken);

            if(oneStudent == null)
            {
                return NotFound(new{ success = false, message = "Student not found" });
            }
            return Ok(new { success = true, data = oneStudent});
        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(DTOCreateStudentController createStudentController, CancellationToken cancellationToken)
        {
            try
            {
                var newStudent = new DTOCreateStudentService
                {
                    Name = createStudentController.Name,
                    FirstName = createStudentController.FirstName,
                    LastName = createStudentController.LastName,
                    Email = createStudentController.Email,
                    Phone = createStudentController.Phone,
                };
                await studentService.AddStudentServiceAsync(newStudent, cancellationToken);
                return Ok(new {success = true, data = "Student is created"});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
                 
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(DTOUpdateStudentService DTOStudentService, CancellationToken cancellationToken)
        {
            try
            {
                await studentService.UpdateStudentServiceAsync(DTOStudentService,cancellationToken);
                return Ok(new { success = true, data = "Student updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                await studentService.DeleteStudentServiceAsync(id, cancellationToken);
                return Ok(new { success = true, data = "Student deleted" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetPagination(int page, int size, CancellationToken cancellationToken)
        {
            var students = await studentService.GetByPagePaginationServiceAsync(page, size, cancellationToken);
            return Ok(new { success = true, data = students });
        }
    }
}
