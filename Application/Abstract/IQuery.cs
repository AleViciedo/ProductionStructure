using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ProductionStructure.Application.Abstract
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
