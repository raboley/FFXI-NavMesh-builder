using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FFXINAVBUILDER.Common;

namespace FFXINAVBUILDER
{
    public partial class MainForm : Form
    {
        public Log Logger { get; set; }
        public List<Zones> Zones { get; set; }
        public List<PointsOfInterest> Points { get; set; }
        public DAT Dat { get; set; }
        public FFXINAV NavBuilder { get; set; }
        public string Filename { get; set; }
        public bool DumpingMapDats { get; set; } = false;

        public MainForm()
        {
            InitializeComponent();
            Logger = new Log();
            Points = new List<PointsOfInterest>();
            Zones = new List<Zones>();
            Logger.AddDebugText(rtbDebug, string.Format(@"Please Note: You may need to edit ZoneList.xml if your installation of Final Fantasy XI is not C:/Program Files (x86)/PlayOnline/SquareEnix/FINAL FANTASY XI/"));
            CreateFolders();
        }

        public void CreateFolders()
        {
            if (!System.IO.Directory.Exists(string.Format(@"{0}\\Map Collision obj files", Application.StartupPath)))
            {
                System.IO.Directory.CreateDirectory(string.Format(@"{0}\\Map Collision obj files", Application.StartupPath));
            }
            if (!System.IO.Directory.Exists(string.Format(@"{0}\\Dumped NavMeshes", Application.StartupPath)))
            {
                System.IO.Directory.CreateDirectory(string.Format(@"{0}\\Dumped NavMeshes", Application.StartupPath));
            }
            if (!System.IO.Directory.Exists(string.Format("{0}\\Log Configs", Application.StartupPath)))
            {
                System.IO.Directory.CreateDirectory(string.Format("{0}\\Log Configs", Application.StartupPath));
            }
            if (!System.IO.Directory.Exists(string.Format("{0}\\Logs", Application.StartupPath)))
            {
                System.IO.Directory.CreateDirectory(string.Format("{0}\\Logs", Application.StartupPath));
            }
            string NetVersion = Environment.Version.ToString();
            Logger.AddDebugText(rtbDebug, string.Format(@".NetFramework v  = ({0})", NetVersion));
            if (!NetVersion.Contains("4."))
            {
                Logger.AddDebugText(rtbDebug, "Please Update your .Net framework, https://www.microsoft.com/en-us/download/details.aspx?id=53344");
            }
            if (File.Exists((string.Format("{0}\\FFXINAV.dll", Application.StartupPath))))
            {
                FileVersionInfo FFXINAVversion = FileVersionInfo.GetVersionInfo("FFXINAV.dll");
                Logger.AddDebugText(rtbDebug, string.Format(@"FFXINAV.dll Found: Version: ({0})", FFXINAVversion.FileVersion));
                NavBuilder = new FFXINAV();
            }
            if (!File.Exists((string.Format("{0}\\FFXINAV.dll", Application.StartupPath))))
            {
                Logger.AddDebugText(rtbDebug, string.Format(@"FFXINAV.dll Missing, Please download the latest version from my GitHub,https://github.com/xenonsmurf/FFXI-NavMesh-builder"));
            }

            string ConfigPath = string.Format("{0}\\Log Configs\\Default_Config.conf", Application.StartupPath);
            if (!System.IO.Directory.Exists(ConfigPath))
            {
                using (StreamWriter sw = File.CreateText(ConfigPath))
                {
                    sw.WriteLine("* GLOBAL:");
                    sw.WriteLine(" FORMAT                  =   \"%datetime | %level | %logger | %msg\"");
                    sw.WriteLine(" FILENAME                =  \"Logs\\FFXINAV-Info.log\"");
                    sw.WriteLine(" ENABLED                 =   true");
                    sw.WriteLine(" TO_FILE                 =   true");
                    sw.WriteLine(" TO_STANDARD_OUTPUT      =   true");
                    sw.WriteLine(" SUBSECOND_PRECISION     =   3");
                    sw.WriteLine(" PERFORMANCE_TRACKING    =   false");
                    sw.WriteLine(" MAX_LOG_FILE_SIZE       =   2097152 ## Throw log files away after 2MB");
                    sw.Dispose();
                }
            }
            try
            {
                if (NavBuilder.Initialize(ConfigPath))
                {
                    Logger.AddDebugText(rtbDebug, "FFXINAV: Initialized");
                }
                if (!NavBuilder.Initialize(ConfigPath))
                {
                    Logger.AddDebugText(rtbDebug, "FFXINAV: Unable to Initialize");
                }
            }
            catch (Exception ex)
            {
                Logger.AddDebugText(rtbDebug, ex.ToString());
            }
        }

        public void LoadZones()
        {
            OpenFileDialog OpenDialog = new OpenFileDialog();
            string PATH = (string.Format(Application.StartupPath));
            OpenDialog.InitialDirectory = PATH;
            OpenDialog.FilterIndex = 0;

            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                string ZoneFilename = OpenDialog.FileName;
                Logger.AddDebugText(rtbDebug, string.Format(@"Nav file loaded = {0}", ZoneFilename));
                try
                {
                    Zones = XmlSerializationHelper.Deserialize<List<Zones>>(ZoneFilename) ?? new List<Zones>();

                    OpenDialog.Dispose();

                    Logger.AddDebugText(rtbDebug, string.Format(@"Added {0} Zones", Zones.Count.ToString()));
                    foreach (var item in Zones)
                    {
                        mapLB.Items.Add(item.name);
                    }
                }
                catch (Exception ex)
                {
                    Logger.AddDebugText(rtbDebug, string.Format(@"LoadZones error {0}", ex.ToString()));
                }
            }
        }

        public void ExportSingleMapData(string Id)
        {
            try
            {
                foreach (var zn in Zones)
                {
                    if (zn.id.ToString() == Id)
                    {
                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();
                        Logger.AddDebugText(rtbDebug, string.Format(@"Exporting {0} ID= {1}", zn.name, zn.id.ToString()));
                        string str = zn.path.Replace(@"\", @"/");
                        if (zn.name != "NILL" && zn.path != "NILL" && !File.Exists(string.Format(@"Map Collision obj files\{0}.obj", zn.name)))
                        {
                            Filename = zn.name.ToString();
                            Dat = null;
                            Dat = new DAT(this, zn.name.ToString());
                            String[] foos = new String[] { str };
                            Dat.Load(foos);
                        }

                        stopWatch.Stop();
                        TimeSpan ts = stopWatch.Elapsed;

                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);

                        Logger.AddDebugText(rtbDebug, string.Format(@"Finished dumping {0} collision data to {1}.obj'", zn.name, zn.name));
                        Logger.AddDebugText(rtbDebug, string.Format(@"Time Taken to dump {0} collision data to {1}.obj = {2}", zn.name, zn.name, elapsedTime));
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddDebugText(rtbDebug, string.Format(@"{0} Best comment out {1} from ZoneList.xml save it,reload and try again. Please use xiExporter to export that map",
                    ex.ToString(), Filename));
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadZones();
        }

        private void DumpAllBtn_Click(object sender, EventArgs e)
        {
            if (DumpAllBtn.Text == "Dump all map.dats")
            {
                Logger.AddDebugText(rtbDebug, string.Format(@"Dumping all map.dats = true"));
                DumpAllBtn.Text = "Stop Dumping map.dats";
                DumpingMapDats = true;
                DumpDatWorker.RunWorkerAsync();
            }
            else if (DumpAllBtn.Text == "Stop Dumping map.dats")
            {
                Logger.AddDebugText(rtbDebug, string.Format(@"Dumping all map.dats = false"));
                DumpAllBtn.Text = "Dump all map.dats";
                if (DumpDatWorker.IsBusy)
                    DumpDatWorker.CancelAsync();
                DumpingMapDats = false;
            }
        }

        private void DumpSelectedMapDatBtn_Click(object sender, EventArgs e)
        {
            if (mapLB.SelectedItem != null)
            {
                foreach (var zone in Zones)
                {
                    if (zone.name == mapLB.SelectedItem.ToString())
                    {
                        ExportSingleMapData(zone.id.ToString());
                    }
                }
            }
            else if (mapLB.SelectedItem == null)
            {
                Logger.AddDebugText(rtbDebug, "Please Select a zone to Dump.");
            }
        }

        private void DumpDatWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Zones.Count > 0)
            {
                while (!DumpDatWorker.CancellationPending)
                {
                    if (DumpingMapDats)
                    {
                        try
                        {
                            DumpingMapDats = false;
                            Stopwatch stopWatch1 = new Stopwatch();
                            stopWatch1.Start();
                            foreach (var zn in Zones)
                            {
                                Stopwatch stopWatch = new Stopwatch();
                                stopWatch.Start();
                                if (DumpDatWorker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    break;
                                }
                                Logger.AddDebugText(rtbDebug, string.Format(@"Exporting {0} ID= {1}", zn.name, zn.id.ToString()));
                                string str = zn.path.Replace(@"\", @"/");
                                if (zn.name != "NILL" && zn.path != "NILL" && !File.Exists(string.Format(@"Map Collision obj files\{0}.obj", zn.name)))
                                {
                                    Filename = zn.name.ToString();
                                    Dat = new DAT(this, zn.name.ToString());
                                    String[] foos = new String[] { str };
                                    Dat.Load(foos);
                                }
                                stopWatch.Stop();
                                TimeSpan ts = stopWatch.Elapsed;

                                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                    ts.Hours, ts.Minutes, ts.Seconds,
                                    ts.Milliseconds / 10);

                                Logger.AddDebugText(rtbDebug, string.Format(@"Finished dumping {0} collision data to {1}.obj'", zn.name, zn.name));
                                Logger.AddDebugText(rtbDebug, string.Format(@"Time Taken to dump {0} collision data to {1}.obj = {2}", zn.name, zn.name, elapsedTime));
                            }
                            stopWatch1.Stop();
                            TimeSpan ts1 = stopWatch1.Elapsed;

                            string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                ts1.Hours, ts1.Minutes, ts1.Seconds,
                                ts1.Milliseconds / 10);
                            Logger.AddDebugText(rtbDebug, string.Format(@"Finished dumping collision data .obj's"));
                            Logger.AddDebugText(rtbDebug, string.Format(@"Time Taken to dump all zones collision data .obj = " + elapsedTime1));
                            DirectoryInfo dInfo = new DirectoryInfo(string.Format(@"{0}\Map Collision obj files\", Application.StartupPath));
                            long sizeOfDir = DirectorySize(dInfo, true);

                            Logger.AddDebugText(rtbDebug, string.Format(@"Map Collsion data OBJ disk space used = {0:N2} MB", ((double)sizeOfDir) / (1024 * 1024)));

                            DumpingMapDats = false;
                            DumpDatWorker.CancelAsync();
                        }
                        catch (Exception ex)
                        {
                            Logger.AddDebugText(rtbDebug, string.Format(@"{0} Best comment out {1} from ZoneList.xml save it,reload and try again. Please use xiExporter to export that map",
                                ex.ToString(), Filename));
                        }
                    }
                }
            }
            else

                Logger.AddDebugText(rtbDebug, "Please load the zone list before you try and dump all the collision data to OBJ files");
            Logger.AddDebugText(rtbDebug, string.Format(@"Dumping all map.dats = false"));

            DumpingMapDats = false;
            DumpDatWorker.CancelAsync();
        }

        private static long DirectorySize(DirectoryInfo dInfo, bool includeSubDir)
        {
            // Enumerate all the files
            long totalSize = dInfo.EnumerateFiles()
                         .Sum(file => file.Length);

            // If Subdirectories are to be included
            if (includeSubDir)
            {
                // Enumerate all sub-directories
                totalSize += dInfo.EnumerateDirectories()
                         .Sum(dir => DirectorySize(dir, true));
            }
            return totalSize;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                double CS = Convert.ToDouble(CSTB.Text);
                double CH = Convert.ToDouble(CHTB.Text);
                double AH = Convert.ToDouble(AHTB.Text);
                double AR = Convert.ToDouble(ARTB.Text);
                double MC = Convert.ToDouble(MCTB.Text);
                double MS = Convert.ToDouble(MSTB.Text);
                double TS = Convert.ToDouble(TSTB.Text);
                double Rs = Convert.ToDouble(RMinS.Text);
                double Rms = Convert.ToDouble(RMS.Text);
                double EML = Convert.ToDouble(EMaxL.Text);
                double Em = Convert.ToDouble(EmE.Text);
                double Vpp = Convert.ToDouble(vPP.Text);
                double Dsd = Convert.ToDouble(DSD.Text);
                double Dsm = Convert.ToDouble(DsM.Text);
                NavBuilder.ChangeNavMeshSettings(CS, CH, AH, AR, MC, MS, TS, Rs, Rms, EML, Em, Vpp, Dsd, Dsm);
                Logger.AddDebugText(rtbDebug, "NavMesh Settings changed.");
            }
            catch (Exception es)
            {
                Logger.AddDebugText(rtbDebug, es.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDialog = new OpenFileDialog();
            string PATH = (string.Format(Application.StartupPath + "\\Map Collision obj files\\"));
            OpenDialog.InitialDirectory = PATH;
            OpenDialog.FilterIndex = 0;

            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                string ZoneFilename = OpenDialog.FileName;
                Logger.AddDebugText(rtbDebug, string.Format(@"Obj File Selected = {0}", ZoneFilename));
                try
                {
                    Stopwatch stopWatch = new Stopwatch();

                    string result;
                    result = Path.GetFileName(ZoneFilename);
                    string result2 = result.Substring(0, result.LastIndexOf(".") + 1);
                    if (File.Exists(string.Format(@"{0}\\Dumped NavMeshes\\{1}nav", Application.StartupPath, result2)))
                    {
                        DialogResult box = MessageBox.Show(string.Format(@"Are you sure you want to overwrite {0}.nav", result2.ToString()), "Question", MessageBoxButtons.YesNoCancel);
                        if (box == DialogResult.Yes)
                        {
                            Logger.AddDebugText(rtbDebug, string.Format(@"Dumping NavMesh for {0}", result));
                            Thread.Sleep(100);
                            if (!NavBuilder.DumpingMesh)
                            {
                                Stopwatch stopWatch2 = new Stopwatch();
                                stopWatch.Start();
                                NavBuilder.Dump_NavMesh(ZoneFilename);
                                stopWatch.Stop();
                                TimeSpan ts2 = stopWatch.Elapsed;

                                // Format and display the TimeSpan value.
                                string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                    ts2.Hours, ts2.Minutes, ts2.Seconds,
                                    ts2.Milliseconds / 10);
                                Logger.AddDebugText(rtbDebug, string.Format(@"Time Taken to dump mesh = " + elapsedTime2));
                            }
                        }
                        else if (box == DialogResult.Cancel)
                        {
                            DumpMeshes.CancelAsync();
                            return;
                        }
                        else if (box == DialogResult.No)
                        {
                            return;
                        }
                    }
                    if (!File.Exists(string.Format(@"{0}\\Dumped NavMeshes\\{1}nav", Application.StartupPath, result2)))
                    {
                        stopWatch.Start();
                        Logger.AddDebugText(rtbDebug, string.Format(@"Dumping NavMesh for {0}", ZoneFilename));
                        NavBuilder.Dump_NavMesh(ZoneFilename);

                        stopWatch.Stop();
                        TimeSpan ts = stopWatch.Elapsed;

                        // Format and display the TimeSpan value.
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);

                        Logger.AddDebugText(rtbDebug, string.Format(@"Finished dumping NavMesh for {0}", ZoneFilename));
                        Logger.AddDebugText(rtbDebug, string.Format(@"Time Taken to dump NavMesh = " + elapsedTime));
                    }
                }
                catch (Exception ex)
                {
                    Logger.AddDebugText(rtbDebug, string.Format(ex.ToString()));
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Start dumping all zone.obj file navmeshes")
            {
                button5.Text = "Stop dumping all zone.obj file navmeshes";
                Thread.Sleep(100);
                if (DumpMeshes.IsBusy)
                {
                    DumpMeshes.CancelAsync();
                }
                else
                    DumpMeshes.RunWorkerAsync();
                Logger.AddDebugText(rtbDebug, string.Format(@"Dumping all zone.obj file navmeshes = True"));
            }
            else if (button5.Text == "Stop dumping all zone.obj file navmeshes")
            {
                Logger.AddDebugText(rtbDebug, string.Format(@"Dumping all zone.obj file navmeshes = false, Finishing off Current build."));
                DumpMeshes.CancelAsync();
                NavBuilder.DumpingMesh = false;
                NavBuilder.UnloadMeshBuilder();

                Thread.Sleep(200);
                button5.Text = "Start dumping all zone.obj file navmeshes";
                Thread.Sleep(200);
            }
        }

        private void DumpMeshes_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Stopwatch stopWatch1 = new Stopwatch();
                stopWatch1.Start();
                while (!DumpMeshes.CancellationPending)
                {
                    if (DumpMeshes.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                    string path = string.Format("{0}\\Map Collision obj files\\", Application.StartupPath);
                    int fileCount = Directory.GetFiles(path, "*.obj", SearchOption.AllDirectories).Length;
                    Logger.AddDebugText(rtbDebug, string.Format(@"{0}.obj files fould in Map Collision obj folder", fileCount.ToString()));
                    foreach (var file in Directory.EnumerateFiles(string.Format(path, "*.obj")))
                    {
                        if (DumpMeshes.CancellationPending)
                        {
                            button5.BeginInvoke(new MethodInvoker(() =>
                            {
                                button5.Text = "Start dumping all zone.obj file navmeshes";
                            }));
                            e.Cancel = true;
                            break;
                        }
                        string result;
                        result = Path.GetFileName(file);
                        string result2 = result.Substring(0, result.LastIndexOf(".") + 1);
                        if (File.Exists(string.Format(@"{0}\\Dumped NavMeshes\\{1}nav", Application.StartupPath, result2)))
                        {
                            DialogResult box = MessageBox.Show(string.Format(@"Are you sure you want to overwrite {0}.nav", result2.ToString()), "Question", MessageBoxButtons.YesNoCancel);

                            if (box == DialogResult.Yes)
                            {
                                if (!NavBuilder.DumpingMesh && !DumpMeshes.CancellationPending)
                                {
                                    Stopwatch stopWatch = new Stopwatch();
                                    stopWatch.Start();
                                    Logger.AddDebugText(rtbDebug, string.Format(@"Dumping NavMesh for {0}", result2));
                                    if (NavBuilder.Dump_NavMesh(file) && !DumpMeshes.CancellationPending)
                                    {
                                        stopWatch.Stop();
                                        NavBuilder.UnloadMeshBuilder();
                                        TimeSpan ts = stopWatch.Elapsed;

                                        // Format and display the TimeSpan value.
                                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                            ts.Hours, ts.Minutes, ts.Seconds,
                                            ts.Milliseconds / 10);
                                        Logger.AddDebugText(rtbDebug, string.Format(@"Time Taken to dump mesh {0} = {1} ", result2, elapsedTime));
                                    }
                                }
                            }
                            else if (box == DialogResult.Cancel)
                            {
                                button5.BeginInvoke(new MethodInvoker(() =>
                                {
                                    button5.Text = "Start dumping all zone.obj file navmeshes";
                                }));
                                DumpMeshes.CancelAsync();
                                break;
                            }
                            else if (box == DialogResult.No)
                            {
                                continue;
                            }
                        }
                        if (!File.Exists(string.Format(@"{0}\\Dumped NavMeshes\\{1}nav", Application.StartupPath, result2)))
                        {
                            if (!NavBuilder.DumpingMesh && !DumpMeshes.CancellationPending)
                            {
                                Stopwatch stopWatch = new Stopwatch();
                                stopWatch.Start();
                                Logger.AddDebugText(rtbDebug, string.Format(@"Dumping NavMesh for {0}", result2));
                                if (NavBuilder.Dump_NavMesh(file) && !DumpMeshes.CancellationPending)
                                {
                                    stopWatch.Stop();
                                    NavBuilder.UnloadMeshBuilder();
                                    TimeSpan ts = stopWatch.Elapsed;

                                    // Format and display the TimeSpan value.
                                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                        ts.Hours, ts.Minutes, ts.Seconds,
                                        ts.Milliseconds / 10);
                                    Logger.AddDebugText(rtbDebug, string.Format(@"Time Taken to dump mesh {0} = {1} ", result2, elapsedTime));
                                }
                            }
                        }
                        if (DumpMeshes.CancellationPending)
                        {
                            button5.BeginInvoke(new MethodInvoker(() =>
                            {
                                button5.Text = "Start dumping all zone.obj file navmeshes";
                            }));
                            e.Cancel = true;
                            break;
                        }
                    }

                    stopWatch1.Stop();
                    TimeSpan ts1 = stopWatch1.Elapsed;
                    string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts1.Hours, ts1.Minutes, ts1.Seconds,
                        ts1.Milliseconds / 10);
                    Logger.AddDebugText(rtbDebug, string.Format(@"Finished dumping NavMesh data"));
                    Logger.AddDebugText(rtbDebug, string.Format(@"Time Taken to dump all zones NavMeshes = " + elapsedTime1));
                    DirectoryInfo dInfo = new DirectoryInfo(string.Format(@"{0}\Dumped NavMeshes\", Application.StartupPath));
                    long sizeOfDir = DirectorySize(dInfo, true);

                    Logger.AddDebugText(rtbDebug, string.Format(@"NavMeshes data disk space used = {0:N2} MB", ((double)sizeOfDir) / (1024 * 1024)));
                    button5.BeginInvoke(new MethodInvoker(() =>
                    {
                        button5.Text = "Start dumping all zone.obj file navmeshes";
                    }));
                    DumpMeshes.CancelAsync();
                    return;
                }
            }
            catch (Exception es)
            {
                Logger.AddDebugText(rtbDebug, es.ToString());
            }
        }
    }
}