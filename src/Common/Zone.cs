// *********************************************************************** Assembly : PathFinder
// Author : xenonsmurf Created : 04-11-2020 Created : 04-11-2020 Created : 04-11-2020 Created :
// Created : 04-11-2020 Created : 04-11-2020 Created : 04-11-2020 Created :
//
// Last Modified By : xenonsmurf Last Modified On : 04-12-2020 Last Modified On : 07-04-2020 Last
// Modified On : 07-13-2020 ***********************************************************************
// <copyright file="Zone.cs" company="Xenonsmurf">
//     Copyright © 2020
// </copyright>
// <summary>
// </summary>
// ***********************************************************************

using System.Xml.Serialization;

namespace FFXINAVBUILDER.Common
{
    /// <summary>
    /// Class Zones.
    /// </summary>
    public class Zones
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value> The identifier. </value>
        [XmlAttribute("ID")]
        public int Id { get; set; }

        [XmlAttribute("Name")] public string Name { get; set; }
        [XmlAttribute("Path")] public string Path { get; set; }
        [XmlAttribute("Type")] public int Type { get; set; }

        #endregion Public Properties

        //[XmlAttribute("GridWidth")]
        //public int gridWidth { get; set; }

        //[XmlAttribute("GridHeight")]
        //public int gridHeight { get; set; }
    }
}