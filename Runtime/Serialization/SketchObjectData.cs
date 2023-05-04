using UnityEngine;

namespace CENTIS.UnitySketchingKernel.Serialization
{
    /// <summary>
    /// Base class for components that are a <see cref="CENTIS.UnitySketchingKernel.SketchObjectManagement.SketchObject"/>.
    /// </summary>
    /// <remarks>
    /// Original author: tterpi
    /// Used to differentiate between group and sketch object data.
    /// </remarks>
    public abstract class SketchObjectData: SerializableComponentData
    {
    }
}