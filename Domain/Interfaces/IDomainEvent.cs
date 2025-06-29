using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDomainEvent
    {
        DateTime Occurred { get; }
        string EventType { get; }
    }
}
