using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignerPals.Models
{
    public class Q
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Question { get; set; }
        public IList<A> Answers { get; set; }
    }
}
