using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Domain.Dto
{
    public class SortDto
    {
        public string? SortBy { get; set; }
        public bool IsDescending { get; set; } = false;
    }
}
