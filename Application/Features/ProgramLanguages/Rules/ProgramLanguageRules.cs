using Application.Features.ProgramLanguages.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramLanguages.Rules
{
    public class ProgramLanguageRules
    {
        private readonly IProgramLanguageRepository _programLanguageRepository;

        public ProgramLanguageRules(IProgramLanguageRepository programLanguageRepository)
        {
            _programLanguageRepository = programLanguageRepository;
        }

        public async Task LanguageNameCannotBeDublicatedWhenInserted(string name)
        {
            IPaginate<ProgramLanguage> results = await _programLanguageRepository.GetListAsync(x => x.LanguageName == name);
            if (results.Count != 0) throw new BusinessException(ProgramLanguageMessages.PLNameExists);
        }

        public async Task LanguageNameCannotBeEmpty(string? name)
        {
            if (string.IsNullOrEmpty(name)) throw new BusinessException(ProgramLanguageMessages.PLNameEmpty);
        }

        public async Task LanguageNameCannotBeDublicatedWhenUpdated(string name, int id)
        {
            IPaginate<ProgramLanguage> results = await _programLanguageRepository.GetListAsync(x => x.LanguageName == name && x.LanguageId != id);
            if (results.Count != 0) throw new BusinessException(ProgramLanguageMessages.PLNameExists);
        }

        public async Task CheckLanguageExist(ProgramLanguage? programLanguage)
        {
            if (programLanguage == null) throw new BusinessException(ProgramLanguageMessages.PLDoesNotExist);
        }
    }
}
