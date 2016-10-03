﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xigadee
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class CommandInAttribute:Attribute
    {
    }

    [AttributeUsage(AttributeTargets.ReturnValue, AllowMultiple = false)]
    public class CommandOutAttribute: Attribute
    {
    }
}
