using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Sites.Queries.GetSiteById
{
    public record GetSiteById(Guid Id) : IQuery<Site?>;
}
