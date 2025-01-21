using Contracts;
using ProductionStructure.Application.Abstract;
using ProductionStructure.Application.ConfigurationData.Areas.Commands.CreateWorkCenter;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Areas.Commands.CreateArea
{
    public class CreateAreaCommandHandler : ICommandHandler<CreateAreaCommand, Area>
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAreaCommandHandler(IAreaRepository areaRepository, IUnitOfWork unitOfWork)
        {
            _areaRepository = areaRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Area> Handle(CreateAreaCommand request, CancellationToken cancellationToken)
        {
            Area result = new Area(request.Name, request.Site);
            _areaRepository.AddArea(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
