﻿using Contracts;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            if (!context.Database.CanConnect())
                context.Database.Migrate();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
