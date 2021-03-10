using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFlow
{
    public class InputFunction : IFunction
    {
        public object Execute(params object[] paramters)
        {
            return string.Join("|",paramters);
        }
    }
}
