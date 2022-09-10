using Application.Features.ProgramLanguages.Constants;
using Application.Features.Techs.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Techs.Rules
{
    public class TechRules
    {
        private readonly ITechRepository _TechRepository;
        private readonly IProgramLanguageRepository _programLanguageRepository;

        public TechRules(ITechRepository TechRepository, IProgramLanguageRepository programLanguageRepository)
        {
            _TechRepository = TechRepository;
            _programLanguageRepository = programLanguageRepository;
        }

        public async Task TechNameCannotBeDublicatedWhenInserted(string name)
        {
            IPaginate<Tech> results = await _TechRepository.GetListAsync(x => x.Name == name);
            if (results.Count != 0) throw new BusinessException(TechMessages.NameExists);
        }

        public async Task TechNameCannotBeEmpty(string? name)
        {
            if (string.IsNullOrEmpty(name)) throw new BusinessException(TechMessages.NameEmpty);
        }


        public async Task TechNameCannotBeDublicatedWhenUpdated(string name, int id)
        {
            IPaginate<Tech> results = await _TechRepository.GetListAsync(x => x.Name == name && x.Id != id);
            if (results.Count != 0) throw new BusinessException(TechMessages.NameExists);
        }

        public async Task CheckTechExist(Tech? Tech)
        {
            if (Tech == null) throw new BusinessException(TechMessages.DoesNotExist);
        }

        public async Task CheckProgramLanguageExistWhenTechInsertedOrUpdated(int id)
        {
            ProgramLanguage programLanguage = await _programLanguageRepository.GetAsync(x => x.Id == id);
            if (programLanguage == null) throw new BusinessException(ProgramLanguageMessages.PLDoesNotExist);

        }
    }
}
