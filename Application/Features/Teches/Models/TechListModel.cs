using Application.Features.Techs.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Techs.Models
{
    public class TechListModel : BasePageableModel
    {
        public IList<TechGetListDto> Items { get; set; }
    }
}
