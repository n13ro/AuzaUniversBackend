using DataAccess.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Features.PairR.Querys
{
    record class GetAllPairsQuery : IRequest<IEnumerable<Pair>>;

    //public class GetAllPairsHandle : IRequestHandler<GetAllPairsQuery, IEnumerable<Pair>>
    //{

    //}
}
