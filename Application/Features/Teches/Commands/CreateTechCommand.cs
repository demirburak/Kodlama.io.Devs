using Application.Features.Techs.Dtos;
using Application.Features.Techs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Techs.Commands
{
    public class CreateTechCommand : IRequest<RegisterUserDto>
    {
        public string Name { get; set; }

        public int ProgramLanguageId { get; set; }

    }

    public class CreateTechCommandHandler : IRequestHandler<CreateTechCommand, RegisterUserDto>
    {
        private readonly ITechRepository _TechRepository;
        private readonly IMapper _mapper;
        private readonly TechRules _TechRules;

        public CreateTechCommandHandler(ITechRepository TechRepository, IMapper mapper, TechRules TechRules)
        {
            _TechRepository = TechRepository;
            _mapper = mapper;
            _TechRules = TechRules;
        }

        public async Task<RegisterUserDto> Handle(CreateTechCommand request, CancellationToken cancellationToken)
        {
            await _TechRules.TechNameCannotBeDublicatedWhenInserted(request.Name);
            await _TechRules.CheckProgramLanguageExistWhenTechInsertedOrUpdated(request.ProgramLanguageId);

            Tech Tech =  await _TechRepository.AddAsync(_mapper.Map<Tech>(request));
            RegisterUserDto createdTechDto = _mapper.Map<RegisterUserDto>(Tech);

            return createdTechDto;
        }
    }

    


}
