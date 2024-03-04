using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Status
    {
        public int IdStatus {  get; set; }
        public string Estado {  get; set; }
        public List<Status> Statuss { get; set;}
    }
}
