using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgramLanguage : Entity
    {

        public int LanguageId { get; set; }

        public string LanguageName { get; set; }
    }
}
