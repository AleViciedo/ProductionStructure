using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductionStructure.Application.Abstract;
using ProductionStructure.Domain.Entity.ConfigurationData;

namespace ProductionStructure.Application.ConfigurationData.Areas.Queries.GetAreaById
{
    public record GetAreaByIdQuery(Guid Id) : IQuery<Area?>;
}
