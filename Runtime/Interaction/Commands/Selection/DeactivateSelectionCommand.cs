using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CENTIS.UnitySketchingKernel.SketchObjectManagement;
using CENTIS.UnitySketchingKernel.Commands;

namespace CENTIS.UnitySketchingKernel.Commands.Selection
{
    /// <summary>
    /// Deactivate the selection.
    /// </summary>
    /// <remarks>Original author: tterpi</remarks>
    public class DeactivateSelectionCommand : ICommand
    {
        private SketchObjectSelection Selection;

        public DeactivateSelectionCommand(SketchObjectSelection selection)
        {
            this.Selection = selection;
        }

        public bool Execute()
        {
            this.Selection.Deactivate();
            return true;
        }

        public void Redo()
        {
            Execute();
        }

        public void Undo()
        {
            this.Selection.Activate();
        }
    }
}