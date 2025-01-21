﻿using ProductionStructure.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.HistoricalData.WorkSessions.Commands.DeleteWorkSession
{
    public record DeleteWorkSessionCommand(Guid Id) : ICommand;
}
