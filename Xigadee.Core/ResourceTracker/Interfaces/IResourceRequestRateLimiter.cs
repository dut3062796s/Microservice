﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xigadee
{
    public interface IResourceRequestRateLimiter: IResourceBase
    {
        double RateLimitAdjustmentPercentage { get; }

    }
}