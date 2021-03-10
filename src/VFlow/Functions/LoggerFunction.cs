using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFlow
{
    public class LoggerFunction:IFunction
    {
        public object Execute(params object[] parameters)
        {
            var msg = $"{string.Join(" ",parameters)}";
            Console.WriteLine(msg);
            return msg;
        }
    }
}
