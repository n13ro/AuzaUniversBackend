using Application.Commands.CreateStudent;
using Application.DTOs;
using Application.Queries.GetStudents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UniversSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentRequest>>> GetStudents([FromBody] int page = 1, [FromBody] int size = 20)
        {
            var query = new GetStudentsQuery { Page = page, Size = size };
            var students = await _mediator.Send(query);

            return Ok(students);
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateStudent(CreateStudentCommand command)
        {
            var studentId = await _mediator.Send(command);
            return Ok(studentId);
        }
    }
}
