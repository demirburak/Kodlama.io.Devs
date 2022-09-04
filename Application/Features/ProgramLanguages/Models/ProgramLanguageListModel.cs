using Application.Features.ProgramLanguages.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramLanguages.Models
{
    public class ProgramLanguageListModel : BasePageableModel
    {
        public IList<ProgramLanguageGetListDto> Items { get; set; }
    }
}
