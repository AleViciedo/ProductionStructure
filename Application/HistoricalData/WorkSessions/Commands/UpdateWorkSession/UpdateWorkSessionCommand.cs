﻿using ProductionStructure.Application.Abstract;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.HistoricalData.WorkSessions.Commands.UpdateWorkSession
{
    public record UpdateWorkSessionCommand(WorkSession WorkSession) : ICommand;
}
