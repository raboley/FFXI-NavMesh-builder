// *********************************************************************** Assembly : PathFinder
// Author : vulture Created : 04-10-2020 Created : 04-10-2020 Created : 04-10-2020 Created : 04-10-2020
//
// Last Modified By : xenonsmurf Last Modified On : 24-01-2021 ***********************************************************************
// <copyright file="dat.cs" company="Xenonsmurf">
//     Copyright © 2020
// </copyright>
// <summary>
// </summary>
// ***********************************************************************

//#define WRITE_CHUNKS_TO_DISK

#define WRITE_COLLISION_MESH_TO_DISK
// other things comment/uncomment as desired whatever

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace FFXINAVBUILDER.Common
{
    /// <summary>
    /// Class CHUNK.
    /// </summary>
    public class Chunk
    {
        /// <summary>
        /// The key tabl e1
        /// </summary>
        private static readonly byte[] KeyTable1 =
        {
            0xE2, 0xE5, 0x06, 0xA9, 0xED, 0x26, 0xF4, 0x42,
            0x15, 0xF4, 0x81, 0x7F, 0xDE, 0x9A, 0xDE, 0xD0,
            0x1A, 0x98, 0x20, 0x91, 0x39, 0x49, 0x48, 0xA4,
            0x0A, 0x9F, 0x40, 0x69, 0xEC, 0xBD, 0x81, 0x81,
            0x8D, 0xAD, 0x10, 0xB8, 0xC1, 0x88, 0x15, 0x05,
            0x11, 0xB1, 0xAA, 0xF0, 0x0F, 0x1E, 0x34, 0xE6,
            0x81, 0xAA, 0xCD, 0xAC, 0x02, 0x84, 0x33, 0x0A,
            0x19, 0x38, 0x9E, 0xE6, 0x73, 0x4A, 0x11, 0x5D,
            0xBF, 0x85, 0x77, 0x08, 0xCD, 0xD9, 0x96, 0x0D,
            0x79, 0x78, 0xCC, 0x35, 0x06, 0x8E, 0xF9, 0xFE,
            0x66, 0xB9, 0x21, 0x03, 0x20, 0x29, 0x1E, 0x27,
            0xCA, 0x86, 0x82, 0xE6, 0x45, 0x07, 0xDD, 0xA9,
            0xB6, 0xD5, 0xA2, 0x03, 0xEC, 0xAD, 0x62, 0x45,
            0x2D, 0xCE, 0x79, 0xBD, 0x8F, 0x2D, 0x10, 0x18,
            0xE6, 0x0A, 0x6F, 0xAA, 0x6F, 0x46, 0x84, 0x32,
            0x9F, 0x29, 0x2C, 0xC2, 0xF0, 0xEB, 0x18, 0x6F,
            0xF2, 0x3A, 0xDC, 0xEA, 0x7B, 0x0C, 0x81, 0x2D,
            0xCC, 0xEB, 0xA1, 0x51, 0x77, 0x2C, 0xFB, 0x49,
            0xE8, 0x90, 0xF7, 0x90, 0xCE, 0x5C, 0x01, 0xF3,
            0x5C, 0xF4, 0x41, 0xAB, 0x04, 0xE7, 0x16, 0xCC,
            0x3A, 0x05, 0x54, 0x55, 0xDC, 0xED, 0xA4, 0xD6,
            0xBF, 0x3F, 0x9E, 0x08, 0x93, 0xB5, 0x63, 0x38,
            0x90, 0xF7, 0x5A, 0xF0, 0xA2, 0x5F, 0x56, 0xC8,
            0x08, 0x70, 0xCB, 0x24, 0x16, 0xDD, 0xD2, 0x74,
            0x95, 0x3A, 0x1A, 0x2A, 0x74, 0xC4, 0x9D, 0xEB,
            0xAF, 0x69, 0xAA, 0x51, 0x39, 0x65, 0x94, 0xA2,
            0x4B, 0x1F, 0x1A, 0x60, 0x52, 0x39, 0xE8, 0x23,
            0xEE, 0x58, 0x39, 0x06, 0x3D, 0x22, 0x6A, 0x2D,
            0xD2, 0x91, 0x25, 0xA5, 0x2E, 0x71, 0x62, 0xA5,
            0x0B, 0xC1, 0xE5, 0x6E, 0x43, 0x49, 0x7C, 0x58,
            0x46, 0x19, 0x9F, 0x45, 0x49, 0xC6, 0x40, 0x09,
            0xA2, 0x99, 0x5B, 0x7B, 0x98, 0x7F, 0xA0, 0xD0
        };

        /// <summary>
        /// The key tabl e2
        /// </summary>
        private static byte[] _keyTable2 =
        {
            0xB8, 0xC5, 0xF7, 0x84, 0xE4, 0x5A, 0x23, 0x7B,
            0xC8, 0x90, 0x1D, 0xF6, 0x5D, 0x09, 0x51, 0xC1,
            0x07, 0x24, 0xEF, 0x5B, 0x1D, 0x73, 0x90, 0x08,
            0xA5, 0x70, 0x1C, 0x22, 0x5F, 0x6B, 0xEB, 0xB0,
            0x06, 0xC7, 0x2A, 0x3A, 0xD2, 0x66, 0x81, 0xDB,
            0x41, 0x62, 0xF2, 0x97, 0x17, 0xFE, 0x05, 0xEF,
            0xA3, 0xDC, 0x22, 0xB3, 0x45, 0x70, 0x3E, 0x18,
            0x2D, 0xB4, 0xBA, 0x0A, 0x65, 0x1D, 0x87, 0xC3,
            0x12, 0xCE, 0x8F, 0x9D, 0xF7, 0x0D, 0x50, 0x24,
            0x3A, 0xF3, 0xCA, 0x70, 0x6B, 0x67, 0x9C, 0xB2,
            0xC2, 0x4D, 0x6A, 0x0C, 0xA8, 0xFA, 0x81, 0xA6,
            0x79, 0xEB, 0xBE, 0xFE, 0x89, 0xB7, 0xAC, 0x7F,
            0x65, 0x43, 0xEC, 0x56, 0x5B, 0x35, 0xDA, 0x81,
            0x3C, 0xAB, 0x6D, 0x28, 0x60, 0x2C, 0x5F, 0x31,
            0xEB, 0xDF, 0x8E, 0x0F, 0x4F, 0xFA, 0xA3, 0xDA,
            0x12, 0x7E, 0xF1, 0xA5, 0xD2, 0x22, 0xA0, 0x0C,
            0x86, 0x8C, 0x0A, 0x0C, 0x06, 0xC7, 0x65, 0x18,
            0xCE, 0xF2, 0xA3, 0x68, 0xFE, 0x35, 0x96, 0x95,
            0xA6, 0xFA, 0x58, 0x63, 0x41, 0x59, 0xEA, 0xDD,
            0x7F, 0xD3, 0x1B, 0xA8, 0x48, 0x44, 0xAB, 0x91,
            0xFD, 0x13, 0xB1, 0x68, 0x01, 0xAC, 0x3A, 0x11,
            0x78, 0x30, 0x33, 0xD8, 0x4E, 0x6A, 0x89, 0x05,
            0x7B, 0x06, 0x8E, 0xB0, 0x86, 0xFD, 0x9F, 0xD7,
            0x48, 0x54, 0x04, 0xAE, 0xF3, 0x06, 0x17, 0x36,
            0x53, 0x3F, 0xA8, 0x11, 0x53, 0xCA, 0xA1, 0x95,
            0xC2, 0xCD, 0xE6, 0x1F, 0x57, 0xB4, 0x7F, 0xAA,
            0xF3, 0x6B, 0xF9, 0xA0, 0x27, 0xD0, 0x09, 0xEF,
            0xF6, 0x68, 0x73, 0x60, 0xDC, 0x50, 0x2A, 0x25,
            0x0F, 0x77, 0xB9, 0xB0, 0x04, 0x0B, 0xE1, 0xCC,
            0x35, 0x31, 0x84, 0xE6, 0x22, 0xF9, 0xC2, 0xAB,
            0x95, 0x91, 0x61, 0xD9, 0x2B, 0xB9, 0x72, 0x4E,
            0x10, 0x76, 0x31, 0x66, 0x0A, 0x0B, 0x2E, 0x83
        };

        /// <summary>
        /// The data
        /// </summary>
        public readonly byte[] Data;

        /// <summary>
        /// The four cc
        /// </summary>
        public readonly string FourCc;

        /// <summary>
        /// The length
        /// </summary>
        private uint Length;

        /// <summary>
        /// The number
        /// </summary>
        public int Number;

        /// <summary>
        /// The type
        /// </summary>
        public uint Type;

        /// <summary>
        /// Initializes a new instance of the <see cref="Chunk"/> class.
        /// </summary>
        /// <param name="s"> The s. </param>
        public Chunk(Stream s)
        {
            var br = new BinaryReader(s);

            var fcc = br.ReadBytes(4);
            var fcclen = 0;
            while (fcclen < fcc.Length && fcc[fcclen] != 0) fcclen++;
            FourCc = Encoding.ASCII.GetString(fcc, 0, fcclen);
            Length = br.ReadUInt32() & 0xfffffff;
            Type = Length & 0x7f;
            Length = ((Length >> 7) << 4) - 0x10;
            br.ReadUInt32();
            br.ReadUInt32();

            Data = br.ReadBytes((int)Length);
        }

        /// <summary>
        /// Decrypt05s the specified data.
        /// </summary>
        /// <param name="data"> The data. </param>
        public static void Decrypt05(byte[] data)
        {
            var len = BitConverter.ToInt32(data, 0) & 0xffffff;
            var key1 = data[5] ^ 0xf0;
            int key2 = KeyTable1[key1];
            var counter = 0;

            for (var pos = 8; pos < len; pos++)
            {
                var x = (key2 & 0xff) * 0x0101;
                key2 += ++counter;

                data[pos] ^= (byte)(x >> (key2 & 7)); // I guess these together are supposed to be some hacky rotate?
                key2 += ++counter;
            }
        }

        /// <summary>
        /// Decrypts the FFFF.
        /// </summary>
        /// <param name="data"> The data. </param>
        public static void DecryptFfff(byte[] data)
        {
            var len = BitConverter.ToInt32(data, 0) & 0xffffff;
            var key1 = data[5] ^ 0xf0;
            int key2 = KeyTable1[key1];
            var len2 = ((len - 8) & ~0xf) >> 1;

            var offset1 = 8;
            var offset2 = offset1 + len2;

            var tmp = new byte[8];

            for (var i = 0; i < len2; i += 8)
            {
                if ((key2 & 1) == 1)
                {
                    Array.Copy(data, offset1, tmp, 0, 8);
                    Array.Copy(data, offset2, data, offset1, 8);
                    Array.Copy(tmp, 0, data, offset2, 8);
                }

                key1 += 9;
                key2 += key1; // seems like this would just swap, swap, notswap, notswap, repeat; with first swap position determined by key2 initial value
                offset1 += 8;
                offset2 += 8;
            }
        }

        /// <summary>
        /// Decrypt1s the b.
        /// </summary>
        /// <param name="data"> The data. </param>
        public static void Decrypt1B(byte[] data)
        {
            var len = BitConverter.ToInt32(data, 0) & 0xffffff;
            int key = KeyTable1[data[7] ^ 0xff];
            var keyCounter = 0;

            for (var pos = 8; pos < len;)
            {
                var xorLength = ((key >> 4) & 7) + 0x10;

                if ((key & 1) == 1 && pos + xorLength < len)
                    for (var i = 0; i < xorLength; i++)
                        data[pos + i] ^= 0xff;

                key += ++keyCounter;
                pos += xorLength;
            }

            var nodeCount = BitConverter.ToInt32(data, 4) & 0xffffff;

            for (var i = 0; i < nodeCount; i++)
                for (var j = 0; j < 0x10; j++)
                    data[0x20 + i * 0x64 + j] ^= 0x55; // each node is 0x64 bytes?
        }

        /// <summary>
        /// Decrypts the specified data.
        /// </summary>
        /// <param name="data"> The data. </param>
        public static void Decrypt(byte[] data)
        {
            if (data.Length < 8) return;
            if (data[3] == 0x05) Decrypt05(data);
            if (data[3] == 0x1b) Decrypt1B(data);
            if (BitConverter.ToUInt16(data, 6) == 0xffff) DecryptFfff(data);
        }
    }

    /// <summary>
    /// Class DAT.
    /// </summary>
    public class Dat
    {
        /// <summary>
        /// The byte cover
        /// </summary>
        public static Dictionary<int, int> ByteCover = new Dictionary<int, int>();

        /// <summary>
        /// The byte cover name
        /// </summary>
        public static Dictionary<int, string> ByteCoverName = new Dictionary<int, string>();

        /// <summary>
        /// All normals
        /// </summary>
        public List<Normal> AllNormals = new List<Normal>();

        /// <summary>
        /// All triangles
        /// </summary>
        public List<Triangle> AllTriangles = new List<Triangle>();

        /// <summary>
        /// All vertices
        /// </summary>
        public List<Vertex> AllVertices = new List<Vertex>();

        /// <summary>
        /// The chunks
        /// </summary>
        public List<Chunk> Chunks = new List<Chunk>();

        /// <summary>
        /// The vismapid
        /// </summary>
        private Dictionary<int, int> Vismapid = new Dictionary<int, int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Dat"/> class.
        /// </summary>
        /// <param name="chr">   The character. </param>
        /// <param name="mf">    </param>
        /// <param name="fn">    The function. </param>
        /// <param name="fid">   </param>
        /// <param name="dtype"> </param>
        public Dat(MainForm mf, string fn, int fid, int dtype)
        {
            Mainform = mf;
            FileName = fn;
            FileId = fid;
            DType = dtype;
        }

        private Dat(Stream s)
        {
            Chunks.Clear();
            ByteCover.Clear();
            ByteCoverName.Clear();
            AllVertices.Clear();
            AllNormals.Clear();
            AllTriangles.Clear();
            Vismapid.Clear();
            Br = new BinaryReader(s);
            while (s.Position < s.Length)
            {
                var offset = s.Position;
                var c = new Chunk(s);
                var d1 = c.Data.Length >= 4 ? BitConverter.ToUInt32(c.Data, 0) : 0;
                var d2 = c.Data.Length >= 8 ? BitConverter.ToUInt32(c.Data, 4) : 0;
                ////Console.WriteLine("chunk: {0,8:x8} : {1}:{2,2:x2} {3,8:x8} bytes / {4,8:x8} {5,8:x8}", offset, c.FourCC, c.Type, c.Length, d1, d2);

                //File.WriteAllBytes(string.Format("{0,4:x4}{1}.enc", Chunks.Count, c.FourCC), c.data);
                Chunk.Decrypt(c.Data);
                var filename = $"{Chunks.Count,4:x4}-{c.FourCc}-{c.Type,2:x2}.dec";
#if WRITE_CHUNKS_TO_DISK
                if (!File.Exists(filename)) File.WriteAllBytes(filename, c.data);
#endif
                c.Number = Chunks.Count;

                Chunks.Add(c);
            }

            s.Dispose();
            Br.Close();
            Br.Dispose();
        }

        /// <summary>
        /// Gets or sets the character.
        /// </summary>
        /// <value> The character. </value>
        public MainForm Mainform { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value> The name of the file. </value>
        private string FileName { get; set; }

        private int FileId { get; set; }
        private int DType { get; set; }

        /// <summary>
        /// Gets or sets the s.
        /// </summary>
        /// <value> The s. </value>
        public FileStream S { get; set; }

        /// <summary>
        /// Gets or sets the br.
        /// </summary>
        /// <value> The br. </value>
        private BinaryReader Br { get; set; }

        private int Gridwidth { get; set; }
        private int Gridheight { get; set; }

        /// <summary>
        /// Parses the map identifier structure.
        /// </summary>
        /// <param name="data"> The data. </param>
        /// <param name="pos">  The position. </param>
        /// <returns> System.Int32. </returns>
        private static int ParseMapIdStruct(byte[] data, int pos)
        {
            var f = new float[0x29];

            for (var i = 0; i < f.Length; i++) f[i] = BitConverter.ToSingle(data, pos + i * 4);
            var mapidencoded = BitConverter.ToUInt32(data, pos + 0x29 * 4);
            var objvisoffset = BitConverter.ToInt32(data, pos + 0x2a * 4);
            var objviscount = BitConverter.ToInt32(data, pos + 0x2b * 4);
            // 0x2c = 0
            var x = BitConverter.ToSingle(data, pos + 0x2d * 4);
            var y = BitConverter.ToSingle(data, pos + 0x2e * 4);
            // 0x2f = 0

            var mapid = ((mapidencoded >> 3) & 0x7) | (((mapidencoded >> 26) & 0x3) << 3);

            //Console.Write("{0,7:0.00},{1,7:0.00} | {2,2:x2} |", x, y, mapid);
            // for (int i = 0; i < f.Length; i++) Console.Write(" {0,7:0.00}", f[i]);
            //Console.WriteLine();

            return (int)mapid;
        }

        /// <summary>
        /// Adds the byte cover.
        /// </summary>
        /// <param name="name">   The name. </param>
        /// <param name="pos">    The position. </param>
        /// <param name="length"> The length. </param>
        private static void AddByteCover(string name, int pos, int length)
        {
            ByteCover[pos] = length;
            ByteCoverName[pos] = name;
        }

        /// <summary>
        /// Prints the byte cover.
        /// </summary>
        private static void PrintByteCover()
        {
            var lastname = "";
            var lastpos = 0;
            var lastlen = 0;

            foreach (var kvp in ByteCover.OrderBy(x => x.Key))
            {
                var pos = kvp.Key;
                var len = kvp.Value;
                var name = ByteCoverName[pos];

                if (name == lastname && pos == lastpos + lastlen)
                {
                    // combine
                    lastlen += len;
                }
                else
                {
                    //if (lastlen > 0) Console.WriteLine("{0,20} : {1}-{2} ({3})", lastname, lastpos.ToString("x8"), (lastpos + lastlen).ToString("x8"), lastlen.ToString("x8"));

                    //if (lastpos + lastlen != pos) Console.WriteLine("{0,20} : {1}-{2} ({3})", "[[skipped]]", (lastpos + lastlen).ToString("x8"), pos.ToString("x8"), (pos - (lastpos + lastlen)).ToString("x8"));

                    lastname = name;
                    lastpos = pos;
                    lastlen = len;
                }
            }

            //if (lastlen > 0) Console.WriteLine("{0,20} : {1}-{2} ({3})", lastname, lastpos.ToString("x8"), (lastpos + lastlen).ToString("x8"), lastlen.ToString("x8"));
        }

        /// <summary>
        /// Parses the quad tree.
        /// </summary>
        /// <param name="data">  The data. </param>
        /// <param name="pos">   The position. </param>
        /// <param name="level"> The level. </param>
        /// <returns> BBT. </returns>
        private Bbt ParseQuadTree(byte[] data, int pos, int level)
        {
            var bb = new float[8 * 3];
            var children = new int[4];

            for (var i = 0; i < 8 * 3; i++) bb[i] = BitConverter.ToSingle(data, pos + i * 4);
            var vislistoffset = BitConverter.ToInt32(data, pos + 8 * 3 * 4);
            var vislistcount = BitConverter.ToInt32(data, pos + 8 * 3 * 4 + 4);
            for (var i = 0; i < 4; i++) children[i] = BitConverter.ToInt32(data, pos + 8 * 3 * 4 + 4 + 4 + i * 4);

            AddByteCover("QuadTree", pos, 8 * 3 * 4 + 4 + 4 + 4 * 4 + 8);

            //Console.Write("{0}", new string(' ', level * 8));
            for (var i = 0; i < 8 * 3; i++)
            {
                //Console.Write(" {0,7:0.00}", BB[i]);
            }

            var b = new Bbt(bb);

            var visset = new HashSet<int>();

            if (vislistcount > 0)
            {
                //Console.Write("    vis:");

                AddByteCover("Vis", vislistoffset, vislistcount * 4);

                for (var i = 0; i < vislistcount; i++)
                {
                    var node = BitConverter.ToInt32(data, vislistoffset + i * 4);
                    //Console.Write(" {0,4:x4}", node);
                    b.Matchids.Add(node);

                    var mapid = Vismapid[node];
                    if (!visset.Contains(mapid)) visset.Add(mapid);
                }

                //Console.Write(" | all mapids:");
                foreach (var mapid in visset)
                    //Console.Write(" {0}", mapid);
                    b.Matches.Add(mapid);
            }
            //Console.WriteLine();

            for (var i = 0; i < 4; i++)
                if (children[i] != 0)
                {
                    var child = ParseQuadTree(data, children[i], level + 1);
                    b.Children.Add(child);
                }

            return b;
        }

        /// <summary>
        /// Parse1s the c.
        /// </summary>
        /// <param name="c"> The c. </param>
        private void Parse1C(Chunk c)
        {
            var mOffset = 8;
            var tryAgain = true;
            var byone = false;
            switch (DType)
            {
                case 0:
                    mOffset = 8;
                    break;

                case 1:
                    mOffset = 0;
                    break;
            }

            Gridwidth = 10 * c.Data[0x0c];
            Gridheight = 10 * c.Data[0x0d];
            while (tryAgain)
                try
                {

                    var meshoffset = BitConverter.ToInt32(c.Data, mOffset); // stores info about the collision mesh
                    int bucketwidth = c.Data[0x0e]; // almost always 40?
                    int bucketheight = c.Data[0x0f]; // stored mul 10; so 40 = 4 yalms; probably baked in so gridwidth*bucketwidth = mapwidth
                    var quadtreeoffset = BitConverter.ToInt32(c.Data, 0x10);
                    const int objectsoffset = 0x20;
                    var objectsendoffset = BitConverter.ToInt32(c.Data, 0x14);
                    var objectscount = (objectsendoffset - objectsoffset) / 0x64;
                    var shortnameoffset = BitConverter.ToInt32(c.Data, 0x18);
                    var shortnamescount = (meshoffset - shortnameoffset) / 0x4c;
                    AddByteCover("header", 0, 0x20);

                    // collision mesh
                    // - use the grid for fast location-based queries, or
                    // - use the list directly if you want to enumerate all the meshes (grid is also fine
                    // for this, just skip over the null pointers)
                    // - dont use the mesh data directly because it stores grid-local coordinates
                    //   and also lacks transformations
                    var meshmodelcount = BitConverter.ToInt32(c.Data, meshoffset + 0x00);
                    var meshmodeldata = BitConverter.ToInt32(c.Data, meshoffset + 4);

                    var meshgridbucketlistscount = BitConverter.ToInt32(c.Data, meshoffset + 0x08);
                    var meshgridbucketlists =
                        BitConverter.ToInt32(c.Data,
                            meshoffset +
                            0x0c); // each bucket has a list of {meshdata,transformation} and the list is zero terminated
                    var gridoffset =
                        BitConverter.ToInt32(c.Data,
                            meshoffset +
                            0x10); // whole map is divided into a grid; each bucket points to its list entry

                    ////Console.WriteLine("mesh: {0} {1} {2} {3} {4}", meshmodelcount.ToString("x8"), meshmodeldata.ToString("x8"), meshgridbucketlistscount.ToString("x8"), meshgridbucketlists.ToString("x8"), gridoffset.ToString("x8"));

                    var mapidlistoffset = BitConverter.ToInt32(c.Data, meshoffset + 0x14);
                    var mapidlistcount = BitConverter.ToInt32(c.Data, meshoffset + 0x18);
                    AddByteCover("meshheader", meshoffset, 0x20);

                    //Console.WriteLine("meshes:");
                    var j = meshmodeldata;
                    Console.WriteLine(j);
                    for (var i = 0; i < meshmodelcount; i++)
                    {
                        ////Console.Write("{0,4:x4} |", i);
                        var retj = ParseMesh(c.Data, j);
                        AddByteCover("meshes", j, retj - j);
                        j = retj;
                    }

                    // this loop populates global AllVertices AllNormals AllTriangles (sorry for statics; if you plan on using this for more than one map at a time, rewrite to be less staticy)
                    //Console.WriteLine("grid:");
                    if (FileName == "Chateau_dOraguille" || FileId == 233)
                    {
                        Gridheight += 100;
                        Gridwidth += 100;
                        Mainform.Logger.AddDebugText(Mainform.rtbDebug,
                            $@"Failed: increase GridHeight & GridWidth {Gridheight.ToString()}/{Gridwidth.ToString()}");
                    }

                    if (FileName == "Port_Jeuno" || FileId == 246)
                    {
                        Gridheight += 200;
                        Gridwidth += 200;
                        Mainform.Logger.AddDebugText(Mainform.rtbDebug,
                            $@"Failed: increase GridHeight & GridWidth {Gridheight.ToString()}/{Gridwidth.ToString()}");
                    }

                    for (var y = 0; y < Gridheight; y++)
                        for (var x = 0; x < Gridwidth; x++)
                        {
                            var offs = (y * Gridwidth + x) * 4;
                            if (gridoffset + offs < c.Data.Length)
                            {
                                var entryoffs = BitConverter.ToInt32(c.Data, gridoffset + offs);
                                if (entryoffs >= c.Data.Length) continue;
                                if (entryoffs != 0) ParseGridEntry(c.Data, entryoffs, x, y);
                                AddByteCover("grid", gridoffset + offs, 4);
                            }
                            else
                            {
                                break;
                            }
                        }

#if WRITE_COLLISION_MESH_TO_DISK
                    // write out the collision mesh in some format

                    using (var sw = new StreamWriter(
                        $@"{Application.StartupPath}\Map Collision obj files\{FileName}.obj"))
                    {
                        foreach (var v in AllVertices) sw.WriteLine("v {0} {1} {2}", v.X, v.Y, -v.Z);
                        foreach (var n in AllNormals) sw.WriteLine("vn {0} {1} {2}", n.Nx, n.Ny, -n.Nz);

                        foreach (var t in AllTriangles)
                            sw.WriteLine("f {0}//{1} {2}//{3} {4}//{5}",
                                1 + t.Iv0, 1 + t.In0,
                                1 + t.Iv1, 1 + t.In0,
                                1 + t.Iv2, 1 + t.In0
                            );
                        tryAgain = false;
                    }

#endif

                    //Console.WriteLine("shortnames:");
                    for (var i = 0; i < shortnamescount; i++)
                    {
                        var name = Encoding.ASCII.GetString(c.Data, shortnameoffset + i * 0x4c, 0x20);
                        ////Console.Write("{0,4:x4} | {1}", i, name);
                        AddByteCover("shortnames", shortnameoffset + i * 0x4c, 0x4c);
                    }
                    //Console.WriteLine();

                    //Console.WriteLine("objects:");
                    for (var i = 0; i < objectscount; i++)
                    {
                        //Console.Write("{0,4:x4} |", i);
                        ParseObject(c.Data, objectsoffset + i * 0x64);
                        AddByteCover("objects", objectsoffset + i * 0x64, 0x64);
                    }

                    //Console.WriteLine("vislist:");
                    for (var i = 0; i < mapidlistcount; i++)
                    {
                        //Console.Write("{0,4:x4} |", i);
                        var mapid = ParseMapIdStruct(c.Data, mapidlistoffset + 0xc0 * i);
                        Vismapid.Add(i, mapid);
                        AddByteCover("vislist", mapidlistoffset + 0xc0 * i, 0xc0);
                    }

                    // quadtree does multiple things:
                    // - given a position, traverse down to some bucket
                    // - each bucket tells you what things are visible, which improves speed of game by limiting objects/polygons drawn
                    // - also tells you the 2D sub map id for a given 3D point (to pull up the proper 2D image when you open up /map)
                    // quadtree volumes have some transformations that I haven't bothered to apply
                    // quadtree stores entire vertical column (i.e. it is not really an octree)
                    //Console.WriteLine("quadtree:");
                    var root = ParseQuadTree(c.Data, quadtreeoffset, 1);

#if false
            // query position to mapid(s)
            BBT found = root.find(-30, 0, 380);
            foreach (int node in found.matchids) Console.WriteLine("{0}", node);
            foreach (int mapid in found.matches) Console.WriteLine("{0}", mapid);
#endif

                    AddByteCover("EOF", c.Data.Length, 1);

                    PrintByteCover();
                }
                catch (Exception)
                {
                    if (!byone) mOffset += 2;
                    if (mOffset > 32 && !byone)
                    {
                        byone = true;
                        mOffset = 0;
                    }

                    if (byone) mOffset += 1;
                    Mainform.Logger.AddDebugText(Mainform.rtbDebug,
                        @"Failed: Trying new offset, DO NOT CLOSE");
                }
        }

        /// <summary>
        /// Parses the grid entry.
        /// </summary>
        /// <param name="data">      The data. </param>
        /// <param name="entryoffs"> The entryoffs. </param>
        /// <param name="x">         The x. </param>
        /// <param name="y">         The y. </param>
        private void ParseGridEntry(byte[] data, int entryoffs, int x, int y)
        {
            {
                if (entryoffs <= 0) return;
                var entries = new List<int>();
                while (true)
                {
                    var c = BitConverter.ToInt32(data, entryoffs);
                    AddByteCover("gridlist", entryoffs, 4);
                    if (c == 0) break;
                    entries.Add(c);
                    entryoffs += 4;
                }

                var pos = (uint)entries[0];
                var xx = (int)((pos >> 14) & 0x1ff);
                var yy = (int)((pos >> 23) & 0x1ff);
                var flags = (int)(pos & 0x3fff);

                //Console.Write("{0} [{1}] : {2},{3} :", entryoffs.ToString("x8"), flags.ToString(), x.ToString(), y.ToString());
                for (var i = 1; i < entries.Count; i += 2)
                {
                    ////Console.Write(" {0}", entries[i].ToString("x8"));
                    var visentryoffset = entries[i + 0]; // points to a raw transformation matrix[4][4]
                    var geometryoffset = entries[i + 1]; // mesh data
                    if (visentryoffset > 0 && geometryoffset > 0 && visentryoffset < data.Length &&
                        geometryoffset < data.Length)
                        ParseGridMesh(data, x, y, visentryoffset, geometryoffset);
                    else break;
                }

                //Console.WriteLine();
            }
        }

        /// <summary>
        /// Parses the grid mesh.
        /// </summary>
        /// <param name="data">           The data. </param>
        /// <param name="_x">             The x. </param>
        /// <param name="_y">             The y. </param>
        /// <param name="visentryoffset"> The visentryoffset. </param>
        /// <param name="geometryoffset"> The geometryoffset. </param>
        private void ParseGridMesh(byte[] data, int x, int y, int visentryoffset, int geometryoffset)
        {
            var m1 = new float[16]; //Transformation matrix
            var m = new Matrix4x4();
            var m2 = new float[9];
            for (var i = 0; i < 16; i++)
            {
                var currValue = BitConverter.ToSingle(data, visentryoffset + i * 4);
                m1[i] = currValue;
                switch (i)
                {
                    case 0:
                        m.M11 = currValue;
                        m2[0] = currValue;
                        break;

                    case 1:
                        m.M12 = currValue;
                        m2[1] = currValue;
                        break;

                    case 2:
                        m.M13 = currValue;
                        m2[2] = currValue;
                        break;

                    case 3:
                        m.M14 = currValue;
                        break;

                    case 4:
                        m.M21 = currValue;
                        m2[3] = currValue;
                        break;

                    case 5:
                        m.M22 = currValue;
                        m2[4] = currValue;
                        break;

                    case 6:
                        m.M23 = currValue;
                        m2[5] = currValue;
                        break;

                    case 7:
                        m.M24 = currValue;
                        break;

                    case 8:
                        m.M31 = currValue;
                        m2[6] = currValue;
                        break;

                    case 9:
                        m.M32 = currValue;
                        m2[7] = currValue;
                        break;

                    case 10:
                        m.M33 = currValue;
                        m2[8] = currValue;
                        break;

                    case 11:
                        m.M34 = currValue;
                        break;

                    case 12:
                        m.M41 = currValue;
                        break;

                    case 13:
                        m.M42 = currValue;
                        break;

                    case 14:
                        m.M43 = currValue;
                        break;

                    case 15:
                        m.M44 = currValue;
                        break;

                    default:
                        break;
                }
            }

            //float tx = M[12];
            //float ty = M[13];
            //float tz = M[14];

            var vertices = BitConverter.ToInt32(data, geometryoffset + 0x00);
            var normals = BitConverter.ToInt32(data, geometryoffset + 0x04);
            var tris = BitConverter.ToInt32(data, geometryoffset + 0x08);
            int tricount = BitConverter.ToInt16(data, geometryoffset + 0x0c);
            int flags = BitConverter.ToInt16(data,
                geometryoffset +
                0x0e); // 0 = block pathing and line of sight; 1 = only blocks pathing (not line of sight)

            var doesntBlockLineOfSight = (flags & 1) != 0;
            //if (doesntBlockLineOfSight) return;

            var numvert = (normals - vertices) / 12;
            if (numvert <= 0) return;
            {
                var numnorm = (tris - normals) / 12;

                // append new verts/norms/tris to end of current set
                var basevert = AllVertices.Count;
                var basenorm = AllNormals.Count;
                var basetri = AllTriangles.Count;

                // d = ad - bc in | a b |
                //                | c d |
                //var determ = M.GetDeterminant();
                var determ = m2[0] * (m2[4] * m2[8] - m2[5] * m2[7]) - m2[1] * (m2[3] * m2[8] - m2[5] * m2[6]) +
                             m2[2] * (m2[3] * m2[7] - m2[4] * m2[6]);
                var multiBy = 1;

                if (determ < 0) multiBy = -1;
                //Console.WriteLine("Determ {0}", determ);
                for (var i = 0; i < numvert; i++)
                    if (vertices > 0)
                    {
                        var x1 = BitConverter.ToSingle(data, vertices + (i * 3 + 0) * 4);
                        var y1 = BitConverter.ToSingle(data, vertices + (i * 3 + 1) * 4);
                        var z1 = BitConverter.ToSingle(data, vertices + (i * 3 + 2) * 4);
                        var w1 = 1.0f;

                        //if(Math.Abs((M[0] * x + M[4] * y + M[8] * z + M[12] * w) - (-135.1522)) < 0.001) System.Diagnostics.Debugger.Break();
                        AllVertices.Add(new Vertex()
                        {
                            X = m1[0] * x1 + m1[4] * y1 + m1[8] * z1 + m1[12] * w1,
                            Y = -(m1[1] * x1 + m1[5] * y1 + m1[9] * z1 + m1[13] * w1),
                            Z = m1[2] * x1 + m1[6] * y1 + m1[10] * z1 + m1[14] * w1
                            //x = M.M11 * x + M.M21 * y + M.M31 * z + M.M41 * w,
                            //y = -(M.M12 * x + M.M22 * y + M.M32 * z + M.M42 * w),
                            //z = M.M13 * x + M.M23 * y + M.M33 * z + M.M43 * w,
                        });
                    }

                if (numnorm > 0)
                    for (var i = 0; i < numnorm; i++)
                        AllNormals.Add(new Normal()
                        {
                            Nx = BitConverter.ToSingle(data, normals + (i * 3 + 0) * 4),
                            Ny = -BitConverter.ToSingle(data, normals + (i * 3 + 1) * 4),
                            Nz = BitConverter.ToSingle(data, normals + (i * 3 + 2) * 4)
                        });
                if (tricount > 0)
                    for (var i = 0; i < tricount; i++)
                        //if (basevert + (BitConverter.ToUInt16(data, tris + (i * 4 + 1) * 2) & 0x3fff) == 14783) System.Diagnostics.Debugger.Break();

                        if (determ > 0)
                            AllTriangles.Add(new Triangle()
                            {
                                Iv0 = basevert + (BitConverter.ToUInt16(data, tris + (i * 4 + 2) * 2) & 0x3fff),
                                Iv1 = basevert + (BitConverter.ToUInt16(data, tris + (i * 4 + 1) * 2) & 0x3fff),
                                Iv2 = basevert + (BitConverter.ToUInt16(data, tris + (i * 4 + 0) * 2) & 0x3fff),
                                In0 = basenorm + (BitConverter.ToUInt16(data, tris + (i * 4 + 3) * 2) & 0x3fff)
                            });
                        else
                            AllTriangles.Add(new Triangle()
                            {
                                Iv0 = basevert + (BitConverter.ToUInt16(data, tris + (i * 4 + 0) * 2) & 0x3fff),
                                Iv1 = basevert + (BitConverter.ToUInt16(data, tris + (i * 4 + 1) * 2) & 0x3fff),
                                Iv2 = basevert + (BitConverter.ToUInt16(data, tris + (i * 4 + 2) * 2) & 0x3fff),
                                In0 = basenorm + (BitConverter.ToUInt16(data, tris + (i * 4 + 3) * 2) & 0x3fff)
                            });
            }
        }

        /// <summary>
        /// Parses the mesh.
        /// </summary>
        /// <param name="data"> The data. </param>
        /// <param name="pos">  The position. </param>
        /// <returns> System.Int32. </returns>
        private int ParseMesh(byte[] data, int pos)
        {
            {
                // Char.Logger.AddDebugText(Char.Tc.rtbDebug, string.Format(@"{0} out of {1}",
                // pos.ToString(), data.Count().ToString())); ;
                if (pos < data.Length)
                {
                    var vertices = BitConverter.ToInt32(data, pos + 0x00);
                    var normals = BitConverter.ToInt32(data, pos + 0x04);
                    var tris = BitConverter.ToInt32(data, pos + 0x08);
                    int tricount = BitConverter.ToInt16(data, pos + 0x0c);
                    int unk2 = BitConverter.ToInt16(data, pos + 0x0e);
                    ////Console.WriteLine(" {0} {1} {2} {3} {4}", vertices.ToString("x8"), normals.ToString("x8"), tris.ToString("x8"), tricount.ToString("x4"), unk2.ToString("x4"));

                    return tris + tricount * 2 * 4;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Parses the object.
        /// </summary>
        /// <param name="data"> The data. </param>
        /// <param name="pos">  The position. </param>
        private void ParseObject(byte[] data, int pos)
        {
            var modelname = Encoding.ASCII.GetString(data, pos, 0x10);
            var position = new float[3]
            {
                BitConverter.ToSingle(data, pos + 0x10 + 0),
                BitConverter.ToSingle(data, pos + 0x10 + 4),
                BitConverter.ToSingle(data, pos + 0x10 + 8)
            };
            var rotation = new float[3]
            {
                BitConverter.ToSingle(data, pos + 0x10 + 0x0c),
                BitConverter.ToSingle(data, pos + 0x10 + 0x10),
                BitConverter.ToSingle(data, pos + 0x10 + 0x14)
            };
            var scale = new float[3]
            {
                BitConverter.ToSingle(data, pos + 0x10 + 0x18),
                BitConverter.ToSingle(data, pos + 0x10 + 0x1c),
                BitConverter.ToSingle(data, pos + 0x10 + 0x20)
            };
            var ingamename = Encoding.ASCII.GetString(data, pos + 0x34, 4);
            if (ingamename[0] == 0) ingamename = "    ";
            // 0x38, 0x3c, 0x40 -- 10.0, 100.0, 1000.0 0x44 -- flags? bigendian 1? 0x48 -- offset to
            // list of indices
            var listoffset = BitConverter.ToInt32(data, pos + 0x48);
            // 0x4c, 0x50 -- 0?
            var m = new int[4]
            {
                BitConverter.ToInt32(data, pos + 0x54 + 0),
                BitConverter.ToInt32(data, pos + 0x54 + 4),
                BitConverter.ToInt32(data, pos + 0x54 + 8),
                BitConverter.ToInt32(data, pos + 0x54 + 0xc)
            };
            // 64 -- end

            /* Console.Write("{0} @ {1,6} {2,6} {3,6} | {4} {5} {6} | {7,5} {8,5} {9,5} | {10} | {11} | {12} {13} {14} {15}", modelname,
                position[0].ToString("N1"), position[1].ToString("N1"), position[2].ToString("N1"),
                rotation[0].ToString("N2"), rotation[1].ToString("N2"), rotation[2].ToString("N2"),
                scale[0].ToString("N2"), scale[1].ToString("N2"), scale[2].ToString("N2"),
                ingamename,
                listoffset.ToString("x8"),
                m[0].ToString("x4"), m[1].ToString("x4"), m[2], m[3]); */

            if (listoffset > 0) ParseObjectListOffset(data, listoffset);
            //else Console.WriteLine();
        }

        /// <summary>
        /// Parses the object list offset.
        /// </summary>
        /// <param name="data"> The data. </param>
        /// <param name="pos">  The position. </param>
        private void ParseObjectListOffset(byte[] data, int pos)
        {
            //Console.Write(" |");
            // # of entries => n
            // n times int index (mapidlistcount)
            var length = BitConverter.ToInt32(data, pos);
            for (var i = 0; i < length; i++)
            {
                if (i >= 5)
                {
                    Console.Write(@" ...");
                    break;
                }

                var j = BitConverter.ToInt32(data, pos + 4 + i * 4);
                //Console.Write(" {0}", j.ToString("x4"));
            }
            //Console.WriteLine();

            AddByteCover("objectlist", pos, length * 4 + 4);
        }

        /// <summary>
        /// Parse2s the e.
        /// </summary>
        /// <param name="c"> The c. </param>
        public void Parse2E(Chunk c)
        {
            int hcount = c.Data[0x20];
            //if (maxcount != 0 && maxcount != 1) //Console.WriteLine("{0,4:x4}", c.Number);
            if (hcount == 0) return; // whatever
            //if (c.data[0x60] != 'm') //Console.WriteLine("{0,4:x4}", c.Number);
            // type at [0x60..0x67] is "warp    " or "model   " or "        "

            var numpoints = BitConverter.ToInt32(c.Data, 0x70);
            for (var i = 0; i < numpoints; i++)
            {
            }
        }

        /// <summary>
        /// Parse20s the specified c.
        /// </summary>
        /// <param name="c"> The c. </param>
        public void Parse20(Chunk c)
        {
            //Debugger.Break();
            var filename = $"{c.Number,4:x4}-{c.FourCc}-{c.Type,2:x2}.dec";
            var filenamepng = $"{c.Number,4:x4}-{c.FourCc}-{c.Type,2:x2}.png";
#if false
            var psi = new ProcessStartInfo("dxt3.exe", "\"" + filename + "\"");
            var p = Process.Start(psi);
            p.WaitForExit();
            if (!Directory.Exists("out")) Directory.CreateDirectory("out");
            if (File.Exists("out.png")) File.Move("out.png", Path.Combine("out", filenamepng));
#endif
        }

        /// <summary>
        /// Rotxes the specified x.
        /// </summary>
        /// <param name="x">     The x. </param>
        /// <param name="y">     The y. </param>
        /// <param name="theta"> The theta. </param>
        /// <returns> System.Double. </returns>
        public double Rotx(float x, float y, float theta)
        {
            return x * Math.Cos(theta) - y * Math.Sin(theta);
        }

        /// <summary>
        /// Roties the specified x.
        /// </summary>
        /// <param name="x">     The x. </param>
        /// <param name="y">     The y. </param>
        /// <param name="theta"> The theta. </param>
        /// <returns> System.Double. </returns>
        public double Roty(float x, float y, float theta)
        {
            return x * Math.Sin(theta) + y * Math.Cos(theta);
        }

        /// <summary>
        /// Parse36s the specified c.
        /// </summary>
        /// <param name="c"> The c. </param>
        public void Parse36(Chunk c)
        {
            // if .zoneid same as current zone, region is probably a "zone line"
            // - if srcordst is 0, the volume zones out
            // - if srcordst is 1, the volume is the random region where you zone in (but your
            // rotation will come from zone out)

            var l = new Subregion();

            var count = BitConverter.ToInt32(c.Data, 0x30);

            for (var i = 0; i < count; i++)
            {
                var o = new Subregion
                {
                    X = BitConverter.ToSingle(c.Data, 0x40 + i * 0x40 + 0x00),
                    Y = BitConverter.ToSingle(c.Data, 0x40 + i * 0x40 + 0x04),
                    Z = BitConverter.ToSingle(c.Data, 0x40 + i * 0x40 + 0x08),
                    Rx = BitConverter.ToSingle(c.Data, 0x40 + i * 0x40 + 0x0c),
                    Ry = BitConverter.ToSingle(c.Data, 0x40 + i * 0x40 + 0x10),
                    Rz = BitConverter.ToSingle(c.Data, 0x40 + i * 0x40 + 0x14),
                    Vx = BitConverter.ToSingle(c.Data, 0x40 + i * 0x40 + 0x18),
                    Vy = BitConverter.ToSingle(c.Data, 0x40 + i * 0x40 + 0x1c),
                    Vz = BitConverter.ToSingle(c.Data, 0x40 + i * 0x40 + 0x20)
                };

                var namebytes = new byte[8];
                Array.Copy(c.Data, 0x40 + i * 0x40 + 0x24, namebytes, 0, 8);
                var len = 0;
                while (len < namebytes.Length && namebytes[len] != 0) len++;
                len = 8;
                o.Name = Encoding.ASCII.GetString(namebytes, 0, len);

                o.Zoneid = BitConverter.ToInt32(c.Data, 0x40 + i * 0x40 + 0x2c);
                o.Srcordst = BitConverter.ToInt32(c.Data, 0x40 + i * 0x40 + 0x30);

#if true
                /*Console.WriteLine("{0,8} {1} {2} : {3,8},{4,8},{5,8} : {6,8},{7,8},{8,8} : {9,8},{10,8},{11,8}",
                    o.name, o.srcordst, o.zoneid.ToString("x4"),
                    o.x.ToString("N2"), o.y.ToString("N2"), o.z.ToString("N2"),
                    o.rx.ToString("N2"), o.ry.ToString("N2"), o.rz.ToString("N2"),
                    o.vx.ToString("N2"), o.vy.ToString("N2"), o.vz.ToString("N2")
                );*/
#endif

                if (true || o.Srcordst == 0)
                {
                    var vx = o.Vx / 2;
                    var vy = o.Vy / 2;
                    var vz = o.Vz / 2;
                    var ry = -o.Ry;

                    //Console.WriteLine("{0} {1} {2} {3} {4} {5} 0.5", o.x + rotx(-vx, vz, ry), o.z + roty(-vx, vz, ry), o.y, o.x + rotx(vx, vz, ry), o.z + roty(vx, vz, ry), o.y);
                    //Console.WriteLine("{0} {1} {2} {3} {4} {5} 0.5", o.x + rotx(vx, vz, ry), o.z + roty(vx, vz, ry), o.y, o.x + rotx(vx, -vz, ry), o.z + roty(vx, -vz, ry), o.y);
                    //Console.WriteLine("{0} {1} {2} {3} {4} {5} 0.5", o.x + rotx(vx, -vz, ry), o.z + roty(vx, -vz, ry), o.y, o.x + rotx(-vx, -vz, ry), o.z + roty(-vx, -vz, ry), o.y);
                    //Console.WriteLine("{0} {1} {2} {3} {4} {5} 0.5", o.x + rotx(-vx, -vz, ry), o.z + roty(-vx, -vz, ry), o.y, o.x + rotx(-vx, vz, ry), o.z + roty(-vx, vz, ry), o.y);

                    ////Console.WriteLine("{0} {1} {2} {3} {4} {5} 0.5", o.x + rotx(-vx, -vz, ry), o.z + roty(-vx, -vz, ry), o.y, o.x + rotx(vx, vz, ry), o.z + roty(vx, vz, ry), o.y);
                    ////Console.WriteLine("{0} {1} {2} {3} {4} {5} 0.5", o.x + rotx(vx, -vz, ry), o.z + roty(vx, -vz, ry), o.y, o.x + rotx(-vx, -vz, ry), o.z + roty(-vx, -vz, ry), o.y);
                }

                l = o;
            }
        }

        /// <summary>
        /// Loads the specified arguments.
        /// </summary>
        /// <param name="args"> The arguments. </param>
        public void Load(string[] args)
        {
            //var file = File.ReadAllBytes(args[0]);
            //CHUNK.Decrypt1B(file);
            //string filename = string.Format("{0}-decrypted", args[0]);
            //if (!File.Exists(filename)) File.WriteAllBytes(filename, file);

            var dat = new Dat(File.OpenRead(args[0]));

            foreach (var c in dat.Chunks)
                if (false)
                {
                }
                else if (c.Type == 0x1c)
                {
                    Parse1C(c);
                }

            //  else if (c.Type == 0x36) Parse36(c);
            //else if (c.Type == 0x2e) Parse2E(c);
            // else if (c.Type == 0x20) Parse20(c);

            dat.Chunks = null;
            dat.Vismapid = null;
            dat.S = null;
            dat.Br = null;
            dat = null;
        }

        /// <summary>
        /// Class BBT.
        /// </summary>
        public class Bbt
        {
            /// <summary>
            /// The children
            /// </summary>
            public List<Bbt> Children = new List<Bbt>();

            /// <summary>
            /// The matches
            /// </summary>
            public List<int> Matches = new List<int>();

            /// <summary>
            /// The matchids
            /// </summary>
            public List<int> Matchids = new List<int>();

            /// <summary>
            /// The x1
            /// </summary>
            public float X1 = 99999, Y1 = 99999, Z1 = 99999;

            /// <summary>
            /// The x2
            /// </summary>
            public float X2 = -99999, Y2 = -99999, Z2 = -99999;

            /// <summary>
            /// Initializes a new instance of the <see cref="Bbt"/> class.
            /// </summary>
            /// <param name="f"> The f. </param>
            public Bbt(float[] f)
            {
                for (var i = 0; i < 4; i++)
                {
                    // not exactly the most efficient way to do this
                    X1 = Math.Min(X1, f[i * 4 + 0]);
                    X2 = Math.Max(X2, f[i * 4 + 0]);
                    Y1 = Math.Min(Y1, f[i * 4 + 1]);
                    Y2 = Math.Max(Y2, f[i * 4 + 1]);
                    Z1 = Math.Min(Z1, f[i * 4 + 2]);
                    Z2 = Math.Max(Z2, f[i * 4 + 2]);
                }
            }

            /// <summary>
            /// Finds the specified x.
            /// </summary>
            /// <param name="x"> The x. </param>
            /// <param name="y"> The y. </param>
            /// <param name="z"> The z. </param>
            /// <returns> BBT. </returns>
            public Bbt Find(float x, float y, float z)
            {
                foreach (var child in Children.Where(child => x >= child.X1 && x <= child.X2 && y >= child.Y1 && y <= child.Y2 && z >= child.Z1 &&
                                                              z <= child.Z2))
                    return child.Find(x, y, z);

                if (x >= X1 && x <= X2 && y >= Y1 && y <= Y2 && z >= Z1 && z <= Z2)
                    return this;
                else
                    return null;
            }
        }

        /// <summary>
        /// Struct vertex
        /// </summary>
        public struct Vertex
        {
            /// <summary>
            /// The x
            /// </summary>
            public float X, Y, Z;
        }

        /// <summary>
        /// Struct normal
        /// </summary>
        public struct Normal
        {
            /// <summary>
            /// The nx
            /// </summary>
            public float Nx, Ny, Nz;
        }

        /// <summary>
        /// Struct triangle
        /// </summary>
        public struct Triangle
        {
            /// <summary>
            /// The iv0
            /// </summary>
            public int Iv0, Iv1, Iv2;

            /// <summary>
            /// The in0
            /// </summary>
            public int In0;
        }

        /// <summary>
        /// Struct Subregion
        /// </summary>
        private struct Subregion
        {
            /// <summary>
            /// The x
            /// </summary>
            public float X;

            /// <summary>
            /// The y
            /// </summary>
            public float Y;

            /// <summary>
            /// The z
            /// </summary>
            public float Z;

            /// <summary>
            /// The rx
            /// </summary>
            public float Rx;

            /// <summary>
            /// The ry
            /// </summary>
            public float Ry;

            /// <summary>
            /// The rz
            /// </summary>
            public float Rz;

            /// <summary>
            /// The vx
            /// </summary>
            public float Vx;

            /// <summary>
            /// The vy
            /// </summary>
            public float Vy;

            /// <summary>
            /// The vz
            /// </summary>
            public float Vz;

            /// <summary>
            /// The name
            /// </summary>
            public string Name;

            /// <summary>
            /// The zoneid
            /// </summary>
            public int Zoneid;

            /// <summary>
            /// The srcordst
            /// </summary>
            public int Srcordst;
        }
    }
}
