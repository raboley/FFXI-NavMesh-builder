// *********************************************************************** Assembly : PathFinder
// Author : xenonsmurf Created : 04-03-2020 Created : 04-03-2020 Created : 04-03-2020 Created :
// Created : 04-03-2020 Created : 04-03-2020 Created : 04-03-2020 Created :
//
// Last Modified By : xenonsmurf Last Modified On : 04-04-2020 Last Modified On : 04-12-2020 Last
// Last Modified On : 07-14-2020 ***********************************************************************
// <copyright file="Imports.cs" company="Xenonsmurf">
//     Copyright © 2020
// </copyright>
// <summary>
// </summary>
// ***********************************************************************

using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace FFXINAVBUILDER.Common
{
    /// <summary>
    /// Class FFXINAV. Implements the <see cref="System.IDisposable"/>
    /// </summary>
    /// <seealso cref="System.IDisposable"/>
    public class Ffxinav : IDisposable
    {
        #region Public Fields

        /// <summary>
        /// The old string
        /// </summary>
        public string OldString = string.Empty;

        #endregion Public Fields

        #region Private Fields

        /// <summary>
        /// The m p native object
        /// </summary>
        private IntPtr _mPNativeObject;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Ffxinav"/> class.
        /// </summary>
        public Ffxinav()
        {
            // We have to Create an instance of this class through an exported function
            _mPNativeObject = CreateFFXINavClass();
            Waypoints = new List<PositionT>();
        }

        #endregion Public Constructors

        #region Private Destructors

        /// <summary>
        /// Finalizes an instance of the <see cref="Ffxinav"/> class.
        /// </summary>
        ~Ffxinav()
        {
            Dispose(false);
        }

        #endregion Private Destructors

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [dumping mesh].
        /// </summary>
        /// <value> <c> true </c> if [dumping mesh]; otherwise, <c> false </c>. </value>
        public bool DumpingMesh { get; set; } = false;

        /// <summary>
        /// Gets or sets the waypoints.
        /// </summary>
        /// <value> The waypoints. </value>
        public List<PositionT> Waypoints { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Determines whether this instance [can see destination] the specified p ffxi nav class object.
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <param name="start">               The start. </param>
        /// <param name="end">                 The end. </param>
        /// <returns>
        /// <c> true </c> if this instance [can see destination] the specified p ffxi nav class
        /// object; otherwise, <c> false </c>.
        /// </returns>
        [DllImport("FFXINAV.dll", EntryPoint = "CanSeeDestination", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CanSeeDestination(IntPtr pFfxiNavClassObject, PositionT start, PositionT end);

        /// <summary>
        /// Disposes the FFXINav class.
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        [DllImport("FFXINAV.dll", EntryPoint = "DisposeFFXINavClass", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void DisposeFFXINavClass(IntPtr pFfxiNavClassObject);

        /// <summary>
        /// Dumps the nav mesh.
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <param name="path">                The path. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        [DllImport("FFXINAV.dll", EntryPoint = "DumpNavMesh", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool DumpNavMesh(IntPtr pFfxiNavClassObject, string path);

        [DllImport("FFXINAV.dll", EntryPoint = "EnableNearestPoly", CharSet = CharSet.Auto,
                    CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool EnableNearestPoly(IntPtr pFfxiNavClassObject, PositionT pos, bool enable,
                    bool useCustomMesh);

        /// <summary>
        /// Finds the closest path.
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <param name="start">               The start. </param>
        /// <param name="end">                 The end. </param>
        /// <param name="useCustomNavMesh">   
        /// if set to &lt;c&gt;true&lt;/c&gt; [use Custom NavMesh] set true if you are using meshes
        /// made with noesis obj files. if set to &lt;c&gt;false&lt;/c&gt; [use Custom NavMesh] set
        /// false if using meshes made with FFXINAV using pathfinder obj files
        /// </param>
        [DllImport("FFXINAV.dll", EntryPoint = "FindClosestPath", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void FindClosestPath(IntPtr pFfxiNavClassObject, PositionT start, PositionT end,
            bool useCustomNavMesh);

        /// <summary>
        /// Finds the path.
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <param name="start">               The start. </param>
        /// <param name="end">                 The end. </param>
        /// <param name="useCustomNavMesh">   
        /// if set to &lt;c&gt;true&lt;/c&gt; [use Custom NavMesh] set true if you are using meshes
        /// made with noesis obj files. if set to &lt;c&gt;false&lt;/c&gt; [use Custom NavMesh] set
        /// false if using meshes made with FFXINAV using pathfinder obj files
        /// </param>
        [DllImport("FFXINAV.dll", EntryPoint = "FindPath", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void findPath(IntPtr pFfxiNavClassObject, PositionT start, PositionT end,
            bool useCustomNavMesh);

        /// <summary>
        /// Finds the random path.
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <param name="start">               The start. </param>
        /// <param name="maxRadius">           The maximum radius. </param>
        /// <param name="maxTurns">            The maximum turns. </param>
        /// <param name="useCustom">          
        /// if set to &lt;c&gt;true&lt;/c&gt; [use custom] set true if you are using meshes made
        /// with noesis obj files. if set to &lt;c&gt;false&lt;/c&gt; [use custom] set false if
        /// using meshes made with FFXINAV using pathfinder obj files
        /// </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        [DllImport("FFXINAV.dll", EntryPoint = "FindRandomPath", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool FindRandomPath(IntPtr pFfxiNavClassObject, PositionT start, float maxRadius,
            sbyte maxTurns, bool useCustom);

        /// <summary>
        /// Gets the distance to wall.
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <param name="start">               The start. </param>
        /// <returns> System.Double. </returns>
        [DllImport("FFXINAV.dll", EntryPoint = "GetDistanceToWall", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern double GetDistanceToWall(IntPtr pFfxiNavClassObject, PositionT start);

        /// <summary>
        /// Gets the log message.
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <returns> System.String. </returns>
        [DllImport("FFXINAV.dll", EntryPoint = "GetLogMessage", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string getLogMessage(IntPtr pFfxiNavClassObject);

        /// <summary>
        /// Gets the rotation.
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <param name="start">               The start. </param>
        /// <param name="end">                 The end. </param>
        /// <returns> System.SByte. </returns>
        [DllImport("FFXINAV.dll", EntryPoint = "GetRotation", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern sbyte GetRotation(IntPtr pFfxiNavClassObject, PositionT start, PositionT end);

        /// <summary>
        /// Initializes the specified p ffxi nav class object.
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <param name="logFileName">         Name of the log file. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        [DllImport("FFXINAV.dll", EntryPoint = "Initialize", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool initialize(IntPtr pFfxiNavClassObject, string logFileName);

        /// <summary>
        /// Determines whether [is nav mesh enabled] [the specified p ffxi nav class object].
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <returns>
        /// <c> true </c> if [is nav mesh enabled] [the specified p ffxi nav class object];
        /// otherwise, <c> false </c>.
        /// </returns>
        [DllImport("FFXINAV.dll", EntryPoint = "isNavMeshEnabled", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool isNavMeshEnabled(IntPtr pFfxiNavClassObject);

        /// <summary>
        /// Determines whether [is valid position] [the specified p ffxi nav class object].
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <param name="start">               The start. </param>
        /// <param name="useCustom">           if set to <c> true </c> [use custom]. </param>
        /// <returns>
        /// <c> true </c> if [is valid position] [the specified p ffxi nav class object]; otherwise,
        /// <c> false </c>.
        /// </returns>
        [DllImport("FFXINAV.dll", EntryPoint = "IsValidPosition", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsValidPosition(IntPtr pFfxiNavClassObject, PositionT start, bool useCustom);

        /// <summary>
        /// Loads the specified p ffxi nav class object.
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <param name="path">                The path. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        [DllImport("FFXINAV.dll", EntryPoint = "load", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool load(IntPtr pFfxiNavClassObject, string path);

        /// <summary>
        /// Loads the object file.
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <param name="path">                The path. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        [DllImport("FFXINAV.dll", EntryPoint = "LoadOBJFile", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool LoadOBJFile(IntPtr pFfxiNavClassObject, string path);

        /// <summary>
        /// Navs the mesh settings.
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <param name="cellSize">            Size of the cell. </param>
        /// <param name="cellHeight">          Height of the cell. </param>
        /// <param name="agentHight">          The agent hight. </param>
        /// <param name="agentRadius">         The agent radius. </param>
        /// <param name="maxClimb">            The maximum climb. </param>
        /// <param name="maxSlope">            The maximum slope. </param>
        /// <param name="tileSize">            Size of the tile. </param>
        /// <param name="regionMinSize">       Minimum size of the region. </param>
        /// <param name="regionMergeSize">     Size of the region merge. </param>
        /// <param name="edgeMaxLen">          Maximum length of the edge. </param>
        /// <param name="edgeError">           The edge error. </param>
        /// <param name="vertsPp">             The verts pp. </param>
        /// <param name="detailSampDistance">  The detail samp distance. </param>
        /// <param name="detailMaxError">      The detail maximum error. </param>
        [DllImport("FFXINAV.dll", EntryPoint = "NavMeshSettings", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void navMeshSettings(IntPtr pFfxiNavClassObject, double cellSize, double cellHeight,
            double agentHight, double agentRadius, double maxClimb,
            double maxSlope, double tileSize, double regionMinSize, double regionMergeSize, double edgeMaxLen,
            double edgeError, double vertsPp,
            double detailSampDistance, double detailMaxError);

        /// <summary>
        /// Pathpointses the specified p ffxi nav class object.
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <returns> System.Int32. </returns>
        [DllImport("FFXINAV.dll", EntryPoint = "Pathpoints", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern int pathpoints(IntPtr pFfxiNavClassObject);

        /// <summary>
        /// Releases the items.
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <param name="itemsHandle">         The items handle. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        [DllImport("FFXINAV.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl,
            SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern unsafe bool ReleaseItems(IntPtr pFfxiNavClassObject, ItemsSafeHandle itemsHandle);

        /// <summary>
        /// Converts to single.
        /// </summary>
        /// <param name="value"> The value. </param>
        /// <returns> System.Single. </returns>
        public static float ToSingle(double value)
        {
            return (float)value;
        }

        /// <summary>
        /// Unloads meshes
        /// </summary>
        [DllImport("FFXINAV.dll", EntryPoint = "unload", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern bool unload(IntPtr pFfxiNavClassObject);

        [DllImport("FFXINAV.dll", EntryPoint = "unloadMeshBuilder", CharSet = CharSet.Auto,
                    CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern bool unloadMeshBuilder(IntPtr pFfxiNavClassObject);

        /// <summary>
        /// Determines whether this instance [can we see destination] the specified start.
        /// </summary>
        /// <param name="start"> The start. </param>
        /// <param name="end">   The end. </param>
        /// <returns>
        /// <c> true </c> if this instance [can we see destination] the specified start; otherwise,
        /// <c> false </c>.
        /// </returns>
        public bool CanWeSeeDestination(PositionT start, PositionT end)
        {
            return CanSeeDestination(_mPNativeObject, start, end);
        }

        /// <summary>
        /// Changes the nav mesh settings.
        /// </summary>
        /// <param name="cellSize">           Size of the cell. </param>
        /// <param name="cellHeight">         Height of the cell. </param>
        /// <param name="agentHeight">        Height of the agent. </param>
        /// <param name="agentRadius">        The agent radius. </param>
        /// <param name="maxClimb">           The maximum climb. </param>
        /// <param name="maxSlope">           The maximum slope. </param>
        /// <param name="tileSize">           Size of the tile. </param>
        /// <param name="regionMinSize">      Minimum size of the region. </param>
        /// <param name="regionMergeSize">    Size of the region merge. </param>
        /// <param name="edgeMaxLen">         Maximum length of the edge. </param>
        /// <param name="edgeError">          The edge error. </param>
        /// <param name="vertsPp">            The verts pp. </param>
        /// <param name="detailSampDistance"> The detail samp distance. </param>
        /// <param name="detailMaxError">     The detail maximum error. </param>
        public void ChangeNavMeshSettings(double cellSize, double cellHeight, double agentHeight, double agentRadius,
            double maxClimb,
            double maxSlope, double tileSize, double regionMinSize, double regionMergeSize, double edgeMaxLen,
            double edgeError, double vertsPp,
            double detailSampDistance, double detailMaxError)
        {
            navMeshSettings(_mPNativeObject, cellSize, cellHeight, agentHeight, agentRadius, maxClimb, maxSlope,
                tileSize,
                regionMinSize, regionMergeSize, edgeMaxLen, edgeError, vertsPp, detailSampDistance, detailMaxError);
        }

        // Variable to hold the C++ class's this pointer
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Distances to wall.
        /// </summary>
        /// <param name="start"> The start. </param>
        /// <returns> System.Double. </returns>
        public double DistanceToWall(PositionT start)
        {
            try
            {
                if (start.X != 0 && start.Z != 0)
                    return GetDistanceToWall(_mPNativeObject, start);
                else
                    return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }

        /// <summary>
        /// Dumps the nav mesh.
        /// </summary>
        /// <param name="file"> The file. </param>
        public bool Dump_NavMesh(string file)
        {
            if (DumpingMesh == false)
            {
                DumpingMesh = true;
                if (UnloadMeshBuilder())
                {
                    if (DumpNavMesh(_mPNativeObject, file))
                    {
                        DumpingMesh = false;
                        return true;
                    }
                }
                else
                {
                    DumpingMesh = false;
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Enables the or disable nearest poly.
        /// </summary>
        /// <param name="pos">       The position. </param>
        /// <param name="enable">    if set to <c> true </c> [enable]. </param>
        /// <param name="useCustom">
        /// if set to <c> true </c> to use meshes made with noesis data [use custom].
        /// </param>
        /// <returns>
        /// <c> true </c> if XXXX, <c> false </c> Always Set to false if using my meshes
        /// </returns>
        public bool EnableOrDisableNearestPoly(PositionT pos, bool enable, bool useCustom)
        {
            return EnableNearestPoly(_mPNativeObject, pos, enable, useCustom);
        }

        /// <summary>
        /// Finds the closest path.
        /// </summary>
        /// <param name="start">              The start. </param>
        /// <param name="end">                The end. </param>
        /// <param name="useCustonNavMeshes"> if set to <c> true </c> [use custon nav meshes]. </param>
        public void FindClosestPath(PositionT start, PositionT end, bool useCustonNavMeshes)
        {
            //set false if using DSP Nav files or meshes made with PathFinder & FFXINAV.dll
            //set true if using Meshes made with Noesis map data
            FindClosestPath(_mPNativeObject, start, end, useCustonNavMeshes);
        }

        /// <summary>
        /// Finds the path to posi.
        /// </summary>
        /// <param name="start">              The start. </param>
        /// <param name="end">                The end. </param>
        /// <param name="useCustonNavMeshes"> if set to <c> true </c> [use custon nav meshes]. </param>
        public void FindPathToPosi(PositionT start, PositionT end, bool useCustonNavMeshes)
        {
            //set false if using DSP Nav files or meshes made with PathFinder & FFXINAV.dll
            //set true if using Meshes made with Noesis map data
            findPath(_mPNativeObject, start, end, useCustonNavMeshes);
        }

        /// <summary>
        /// Finds the random path.
        /// </summary>
        /// <param name="start">     The start. </param>
        /// <param name="maxRadius"> The maximum radius. </param>
        /// <param name="maxTurns">  The maximum turns. </param>
        /// <param name="useCustom"> if set to <c> true </c> [use custom]. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public bool FindRandomPath(PositionT start, float maxRadius, sbyte maxTurns, bool useCustom)
        {
            return FindRandomPath(_mPNativeObject, start, maxRadius, maxTurns, useCustom);
        }

        /// <summary>
        /// Gets the way points wrapper.
        /// </summary>
        /// <param name="xitems">     The xitems. </param>
        /// <param name="zitems">     The zitems. </param>
        /// <param name="itemsCount"> The items count. </param>
        /// <returns> ItemsSafeHandle. </returns>
        /// <exception cref="System.InvalidOperationException"> </exception>
        public unsafe ItemsSafeHandle Get_WayPoints_Wrapper(out double* xitems, out double* zitems, out int itemsCount)
        {
            ItemsSafeHandle itemsHandle;
            if (!Get_WayPoints(_mPNativeObject, out itemsHandle, out var itemsHandle2, out xitems, out zitems,
                out itemsCount)) throw new InvalidOperationException();
            return itemsHandle;
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <returns> System.String. </returns>
        public string GetErrorMessage()
        {
            return getLogMessage(_mPNativeObject).ToString();
        }

        /// <summary>
        /// Getrotations the specified start.
        /// </summary>
        /// <param name="start"> The start. </param>
        /// <param name="end">   The end. </param>
        /// <returns> System.SByte. </returns>
        public sbyte Getrotation(PositionT start, PositionT end)
        {
            return GetRotation(_mPNativeObject, start, end);
        }

        /// <summary>
        /// Gets the waypoints.
        /// </summary>
        public unsafe void GetWaypoints()
        {
            Waypoints.Clear();
            if (pathpoints(_mPNativeObject) > 0)
            {
                double* xitems;
                double* zitems;
                int itemsCount;

                using (Get_WayPoints_Wrapper(out xitems, out zitems, out itemsCount))
                {
                    for (var i = 0; i < itemsCount; i++)
                    {
                        var position = new PositionT { X = (float)xitems[i], Z = (float)zitems[i] };
                        Waypoints.Add(position);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes the specified pathsize.
        /// </summary>
        /// <param name="logFileName"> Name of the log file. </param>
        public bool Initialize(string logFileName)
        {
            return initialize(_mPNativeObject, logFileName);
        }

        /// <summary>
        /// Determines whether [is nav mesh enabled].
        /// </summary>
        /// <returns> <c> true </c> if [is nav mesh enabled]; otherwise, <c> false </c>. </returns>
        public bool IsNavMeshEnabled()
        {
            if (isNavMeshEnabled(_mPNativeObject) == false) return false;
            return isNavMeshEnabled(_mPNativeObject) == true;
        }

        /// <summary>
        /// Determines whether [is valid position] [the specified start].
        /// </summary>
        /// <param name="start">     The start. </param>
        /// <param name="useCustom"> if set to <c> true </c> [use custom]. </param>
        /// <returns>
        /// <c> true </c> if [is valid position] [the specified start]; otherwise, <c> false </c>.
        /// </returns>
        public bool IsValidPosition(PositionT start, bool useCustom)
        {
            return IsValidPosition(_mPNativeObject, start, useCustom);
        }

        /// <summary>
        /// Loads the specified file.
        /// </summary>
        /// <param name="file"> The file. </param>
        public void Load(string file)
        {
            load(_mPNativeObject, file);
        }

        /// <summary>
        /// Loads the ob jfile.
        /// </summary>
        /// <param name="file"> The file. </param>
        public void LoadObJfile(string file)
        {
            Thread.Sleep(2000);
            LoadOBJFile(_mPNativeObject, file);
        }

        /// <summary>
        /// Pathes the count.
        /// </summary>
        /// <returns> System.Int32. </returns>
        public int PathCount()
        {
            return pathpoints(_mPNativeObject);
        }

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public bool Unload()
        {
            return unload(_mPNativeObject);
        }

        public bool UnloadMeshBuilder()
        {
            return unloadMeshBuilder(_mPNativeObject);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="bDisposing">
        /// <c> true </c> to release both managed and unmanaged resources; <c> false </c> to release
        /// only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool bDisposing)
        {
            if (_mPNativeObject != IntPtr.Zero)
            {
                // Call the DLL Export to dispose this class
                DisposeFFXINavClass(_mPNativeObject);
                _mPNativeObject = IntPtr.Zero;
            }

            if (bDisposing)
                // No need to call the finalizer since we've now cleaned up the unmanaged memory
                GC.SuppressFinalize(this);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Creates the FFXINav class.
        /// </summary>
        /// <returns> IntPtr. </returns>
        [DllImport("FFXINAV.dll", EntryPoint = "CreateFFXINavClass", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern IntPtr CreateFFXINavClass();

        /// <summary>
        /// Gets the way points.
        /// </summary>
        /// <param name="pFfxiNavClassObject"> The p ffxi nav class object. </param>
        /// <param name="itemsHandle">         The items handle. </param>
        /// <param name="itemsHandle2">        The items handle2. </param>
        /// <param name="xitems">              The xitems. </param>
        /// <param name="zitems">              The zitems. </param>
        /// <param name="itemCount">           The item count. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        [DllImport("FFXINAV.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl,
            SetLastError = true)]
        private static extern unsafe bool Get_WayPoints(IntPtr pFfxiNavClassObject, out ItemsSafeHandle itemsHandle,
            out ItemsSafeHandle itemsHandle2,
            out double* xitems, out double* zitems, out int itemCount);

        #endregion Private Methods

        #region Public Classes

        /// <summary>
        /// Class ItemsSafeHandle. Implements the <see cref="Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid"/>
        /// </summary>
        /// <seealso cref="Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid"/>
        public class ItemsSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="ItemsSafeHandle"/> class.
            /// </summary>
            public ItemsSafeHandle()
                : base(true)
            {
            }

            #endregion Public Constructors

            #region Protected Methods

            /// <summary>
            /// When overridden in a derived class, executes the code required to free the handle.
            /// </summary>
            /// <returns>
            /// <see langword="true"/> if the handle is released successfully; otherwise, in the
            /// event of a catastrophic failure, <see langword="false"/>. In this case, it generates
            /// a releaseHandleFailed Managed Debugging Assistant.
            /// </returns>
            protected override bool ReleaseHandle()
            {
                return true;
            }

            #endregion Protected Methods
        }

        #endregion Public Classes
    }
}