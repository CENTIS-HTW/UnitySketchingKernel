using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CENTIS.UnitySketchingKernel.Commands;
using CENTIS.UnitySketchingKernel.SketchObjectManagement;

namespace CENTIS.UnitySketchingKernel.Commands.Line
{
    /// <summary>
    /// Refine the mesh of a line sketch object using the Parallel Transport algorithm.
    /// </summary>
    /// <remarks>Original author: tterpi</remarks>
    public class RefineMeshCommand : ICommand
    {
        LineSketchObject LineSketchObject;
        List<Vector3> OriginalControlPoints;

        public RefineMeshCommand(LineSketchObject lineSketchObject)
        {
            this.LineSketchObject = lineSketchObject;
            OriginalControlPoints = lineSketchObject.GetControlPoints();
        }

        public bool Execute()
        {
            LineSketchObject.RefineMesh();
            return true;
        }

        public void Redo()
        {
            this.Execute();
        }

        public void Undo()
        {
            this.LineSketchObject.SetControlPointsLocalSpace(OriginalControlPoints);
        }
    }
}