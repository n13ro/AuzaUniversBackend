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
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var query = new GetStudentsQuery();
            var students = await _mediator.Send(query);

            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            // Пока просто заглушка
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateStudent(CreateStudentCommand command)
        {
            var studentId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetStudent), new { id = studentId }, studentId);
        }
    }
}
