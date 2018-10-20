using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGameRESTAPI
{
    public class EmptyTextWriter : System.IO.TextWriter
    {
        public override Encoding Encoding => Encoding.UTF8;

        /// <summary>
        /// 
        /// </summary>
        public override void Flush()
        {
            //base.Flush();
        }

    }
}
