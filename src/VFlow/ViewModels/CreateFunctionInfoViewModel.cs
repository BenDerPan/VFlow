using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VFlow
{
    public class CreateFunctionInfoViewModel
    {
        public FunctionInfoViewModel Info { get; }
        public Point Location { get; }
        public CreateFunctionInfoViewModel(FunctionInfoViewModel info,Point location)
        {
            Info = info;
            Location = location;
        }
    }
}
