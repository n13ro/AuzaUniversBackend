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
        public async Task<ActionResult<IEnumerable<StudentRequest>>> GetStudents()
        {
            var query = new GetStudentsQuery();
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
