﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncFlow
{
    public interface IFunc
    {
        object Execute(params object[] parameters);
    }
}
