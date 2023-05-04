using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CENTIS.UnitySketchingKernel.SketchObjectManagement;
using CENTIS.UnitySketchingKernel.Serialization;

namespace CENTIS.UnitySketchingKernel.Commands {
    /// <summary>
    /// Set the brush of the sketch object.
    /// </summary>
    /// <remarks>Original author: tterpi</remarks>
    public class SetBrushCommand : ICommand
    {

        private IBrushable SketchObject;
        private Brush NewBrush;
        private Brush OriginalBrush;

        public SetBrushCommand(IBrushable sketchObject, Brush brush) {
            SketchObject = sketchObject;
            NewBrush = brush;
        }

        public bool Execute()
        {
            OriginalBrush = SketchObject.GetBrush();
            SketchObject.SetBrush(NewBrush);
            return true;
        }

        public void Redo()
        {
            this.Execute();
        }

        public void Undo()
        {
            SketchObject.SetBrush(OriginalBrush);
        }
    }
}
