using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.DataAccess.Repositories.Common
{
    public abstract class RepositoryBase
    {
        protected ApplicationContext _context;
        protected RepositoryBase(ApplicationContext context)
        {
            _context = context;
        }
    }
}
