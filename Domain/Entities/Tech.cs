using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tech : Entity
    {

        public int ProgramLanguageId { get; set; }

        public string Name { get; set; }



        public virtual ProgramLanguage? ProgramLanguage { get; set; }
    }

}
