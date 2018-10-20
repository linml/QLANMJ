using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGameRESTAPI
{
    public class LogTextWrite : System.IO.TextWriter
    {
        public override Encoding Encoding => Encoding.UTF8;



    }
}
