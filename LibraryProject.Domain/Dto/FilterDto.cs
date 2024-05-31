using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Domain.Dto
{
    public class FilterDto
    {
        public string? Title { get; set; }        
        public string? Genre { get; set; }
        public int? MinNumberOfPages { get; set; }
        public int? MaxNumberOfPages { get; set; }
        public int? PublishingYearMin { get; set; }
        public int? PublishingYearMax { get; set; }
        public string? Author { get; set; }        
    }
}
