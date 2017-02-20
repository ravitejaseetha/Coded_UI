﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public interface IContext
    {
        void Start();
        void Execute();
        void End();
    }
}
