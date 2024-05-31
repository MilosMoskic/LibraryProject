using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Domain.Dto
{
    public class FilterAndSortDto
    {
        public FilterDto FilterDto { get; set; }
        public SortDto SortDto { get; set; }
    }
}
