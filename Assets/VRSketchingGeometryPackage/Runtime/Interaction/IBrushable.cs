﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CENTIS.UnitySketchingKernel.Serialization;

namespace CENTIS.UnitySketchingKernel.SketchObjectManagement
{
    /// <summary>
    /// Classes that implement this interface can work with Brush objects.
    /// </summary>
    /// <remarks>Original author: tterpi</remarks>
    public interface IBrushable
    {
        Brush GetBrush();
        void SetBrush(Brush brush);
    }
}
