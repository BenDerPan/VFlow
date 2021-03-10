using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFlow
{
   public interface IFunction
    {
        object Execute(params object[] paramters);
    }
}
