using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncFlow
{
    public class WriteLogFunc:IFunc
    {
        public object Execute(params object[] parameters)
        {
            var msg = $"WriteLog: {string.Join(" ",parameters)}";
            Console.WriteLine(msg);
            return msg;
        }
    }
}
