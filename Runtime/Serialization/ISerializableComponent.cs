using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CENTIS.UnitySketchingKernel.SketchObjectManagement;

namespace CENTIS.UnitySketchingKernel.Serialization
{
    /// <summary>
    /// Interface that marks Unity components that can be serialized 
    /// using <see cref="CENTIS.UnitySketchingKernel.Serialization.SerializableComponentData"/> objects.
    /// </summary>
    /// <remarks>Original author: tterpi</remarks>
    internal interface ISerializableComponent: IGroupable
    {
        SerializableComponentData GetData();
        void ApplyData(SerializableComponentData data);
    }
}
