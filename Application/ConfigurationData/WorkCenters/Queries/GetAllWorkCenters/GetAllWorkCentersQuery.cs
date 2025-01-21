using ProductionStructure.Application.Abstract;
using ProductionStructure.Domain.Entity.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.WorkCenters.Queries.GetAllWorkCenters
{
    public record GetAllWorkCentersQuery() : IQuery<IEnumerable<Domain.Entity.ConfigurationData.WorkCenter>>;
}
