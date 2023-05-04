using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Xml.Serialization;
using CENTIS.UnitySketchingKernel.SketchObjectManagement;

namespace CENTIS.UnitySketchingKernel.Serialization
{
    /// <summary>
    /// Data class for <see cref="CENTIS.UnitySketchingKernel.SketchObjectManagement.SketchObjectGroup"/>.
    /// </summary>
    /// <remarks>Original author: tterpi</remarks>
    public class SketchObjectGroupData : SerializableComponentData
    {
        /// <summary>
        /// List of the sketch objects in this group.
        /// </summary>
        /// <remarks>XmlArrayItem attribute is required for correct deserialization of derived classes.</remarks>
        [XmlArrayItem(typeof(SketchObjectData)), XmlArrayItem(typeof(LineSketchObjectData)), XmlArrayItem(typeof(PatchSketchObjectData)), 
            XmlArrayItem(typeof(RibbonSketchObjectData))]
        public List<SketchObjectData> SketchObjects;
        public List<SketchObjectGroupData> SketchObjectGroups;

        public SketchObjectGroupData() { }

        internal override ISerializableComponent InstantiateComponent(DefaultReferences defaults) {
            return GameObject.Instantiate(defaults.SketchObjectGroupPrefab).GetComponent<SketchObjectGroup>();
        }
    }
}
