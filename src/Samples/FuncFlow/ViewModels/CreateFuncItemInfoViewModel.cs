using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FuncFlow
{
    public class CreateFuncItemInfoViewModel
    {
        public FuncItemInfoViewModel Info { get; }
        public Point Location { get; }
        public CreateFuncItemInfoViewModel(FuncItemInfoViewModel info,Point location)
        {
            Info = info;
            Location = location;
        }
    }
}
