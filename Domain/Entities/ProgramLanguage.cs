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

        public string LanguageName { get; set; }


        public virtual ICollection<Tech> Teches { get; set; }
    }
}
