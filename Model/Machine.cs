using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendMock.Model
{
    public class Machine
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public EState State { get; set; }
    }
}