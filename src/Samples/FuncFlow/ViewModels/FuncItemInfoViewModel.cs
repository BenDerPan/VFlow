using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncFlow
{
    public class FuncItemInfoViewModel
    {
        public string? Title { get; set; }

        public IFunc? Func { get; set; }

        public List<string?> Input { get; } = new List<string?>();
        
        public uint MinInput { get; set; }

        public uint MaxInput { get; set; }
    }
}
