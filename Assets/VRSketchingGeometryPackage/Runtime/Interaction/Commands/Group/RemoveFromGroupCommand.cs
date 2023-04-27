﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CENTIS.UnitySketchingKernel.Commands;
using CENTIS.UnitySketchingKernel.SketchObjectManagement;

namespace CENTIS.UnitySketchingKernel.Commands.Group
{
    /// <summary>
    /// Remove an object from a group.
    /// </summary>
    /// <remarks>Original author: tterpi</remarks>
    public class RemoveFromGroupCommand : ICommand
    {
        IGroupable Object;
        SketchObjectGroup OriginalParent;

        public RemoveFromGroupCommand(IGroupable Object)
        {
            this.OriginalParent = Object.ParentGroup;
            this.Object = Object;
        }

        public bool Execute()
        {
            SketchObjectGroup.RemoveFromGroup(Object);
            return true;
        }

        public void Redo()
        {
            Execute();
        }

        public void Undo()
        {
            Object.ParentGroup = OriginalParent;
            Object.resetToParentGroup();
        }
    }
}