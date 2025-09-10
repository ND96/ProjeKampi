using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CategoryWithCountDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BlogCount { get; set; }
    }
}
