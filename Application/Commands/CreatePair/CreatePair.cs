using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CreatePair
{
    public class CreatePairCommand : IRequest<int>
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Auditorium { get; set; }

        public int GroupId { get; set; }
    }
}
