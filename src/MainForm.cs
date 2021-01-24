using FFXINAVBUILDER.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace FFXINAVBUILDER
{
    public partial class MainForm : Form
    {
        #region Public Constructors

        public MainForm()
        {
            InitializeComponent();
            Logger = new Log();
            Zones = new List<Zones>();
            Logger.AddDebugText(rtbDebug,
                @"Please Note: You may need to edit ZoneList.xml if your installation of Final Fantasy XI is not C:/Program Files (x86)/PlayOnline/SquareEnix/FINAL FANTASY XI/");
            CreateFolders();
        }

        #endregion Public Constructors

        #region Public Properties

        public Log Logger { get; }

        #endregion Public Properties

        #region Private Properties

        private Dat Dat { get; set; }
        private bool DumpingMapDats { get; set; }
        private string Filename { get; set; }
        private Ffxinav NavBuilder { get; set; }
        private List<Zones> Zones { get; set; }

        #endregion Private Properties

        #region Private Methods

        private static long DirectorySize(DirectoryInfo dInfo, bool includeSubDir)
        {
            // Enumerate all the files
            var totalSize = dInfo.EnumerateFiles().Sum(file => file.Length);

            // If Subdirectories are to be included
            if (includeSubDir)
                // Enumerate all sub-directories
                totalSize += dInfo.EnumerateDirectories().Sum(dir => DirectorySize(dir, true));
            return totalSize;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            var path = string.Format(Application.StartupPath + "\\Map Collision obj files\\");
            openDialog.InitialDirectory = path;
            openDialog.FilterIndex = 0;
            if (openDialog.ShowDialog() != DialogResult.OK) return;
            var zoneFilename = openDialog.FileName;
            Logger.AddDebugText(rtbDebug, $@"Obj File Selected = {zoneFilename}");
            try
            {
                var stopWatch = new Stopwatch();
                var result = Path.GetFileName(zoneFilename);
                var result2 = result.Substring(0, result.LastIndexOf(".", StringComparison.Ordinal) + 1);
                if (File.Exists($@"{Application.StartupPath}\\Dumped NavMeshes\\{result2}nav"))
                {
                    var box = MessageBox.Show($@"Are you sure you want to overwrite {result2}.nav", @"Question",
                        MessageBoxButtons.YesNoCancel);
                    if (box == DialogResult.Yes)
                    {
                        Logger.AddDebugText(rtbDebug, $@"Dumping NavMesh for {result}");
                        Thread.Sleep(100);
                        if (!NavBuilder.DumpingMesh)
                        {
                            stopWatch.Start();
                            NavBuilder.Dump_NavMesh(zoneFilename);
                            stopWatch.Stop();
                            var ts2 = stopWatch.Elapsed;

                            // Format and display the TimeSpan value.
                            var elapsedTime2 =
                                $"{ts2.Hours:00}:{ts2.Minutes:00}:{ts2.Seconds:00}.{ts2.Milliseconds / 10:00}";
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

                if (File.Exists($@"{Application.StartupPath}\\Dumped NavMeshes\\{result2}nav")) return;
                stopWatch.Start();
                Logger.AddDebugText(rtbDebug, $@"Dumping NavMesh for {zoneFilename}");
                NavBuilder.Dump_NavMesh(zoneFilename);
                stopWatch.Stop();
                var ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                var elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
                Logger.AddDebugText(rtbDebug, $@"Finished dumping NavMesh for {zoneFilename}");
                Logger.AddDebugText(rtbDebug, string.Format(@"Time Taken to dump NavMesh = " + elapsedTime));
            }
            catch (Exception ex)
            {
                Logger.AddDebugText(rtbDebug, string.Format(ex.ToString()));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var cs = Convert.ToDouble(CSTB.Text);
                var ch = Convert.ToDouble(CHTB.Text);
                var ah = Convert.ToDouble(AHTB.Text);
                var ar = Convert.ToDouble(ARTB.Text);
                var mc = Convert.ToDouble(MCTB.Text);
                var ms = Convert.ToDouble(MSTB.Text);
                var ts = Convert.ToDouble(TSTB.Text);
                var rs = Convert.ToDouble(RMinS.Text);
                var rms = Convert.ToDouble(RMS.Text);
                var eml = Convert.ToDouble(EMaxL.Text);
                var em = Convert.ToDouble(EmE.Text);
                var vpp = Convert.ToDouble(vPP.Text);
                var dsd = Convert.ToDouble(DSD.Text);
                var dsm = Convert.ToDouble(DsM.Text);
                NavBuilder.ChangeNavMeshSettings(cs, ch, ah, ar, mc, ms, ts, rs, rms, eml, em, vpp, dsd, dsm);
                Logger.AddDebugText(rtbDebug, "NavMesh Settings changed.");
            }
            catch (Exception es)
            {
                Logger.AddDebugText(rtbDebug, es.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == @"Start dumping all zone.obj file navmeshes")
            {
                button5.Text = @"Stop dumping all zone.obj file navmeshes";
                Thread.Sleep(100);
                if (DumpMeshes.IsBusy) DumpMeshes.CancelAsync();
                else DumpMeshes.RunWorkerAsync();
                Logger.AddDebugText(rtbDebug, @"Dumping all zone.obj file navmeshes = True");
            }
            else if (button5.Text == @"Stop dumping all zone.obj file navmeshes")
            {
                Logger.AddDebugText(rtbDebug,
                    @"Dumping all zone.obj file navmeshes = false, Finishing off Current build.");
                DumpMeshes.CancelAsync();
                NavBuilder.DumpingMesh = false;
                NavBuilder.UnloadMeshBuilder();
                Thread.Sleep(200);
                button5.Text = @"Start dumping all zone.obj file navmeshes";
                Thread.Sleep(200);
            }
        }

        private void CreateFolders()
        {
            if (!Directory.Exists($@"{Application.StartupPath}\\Map Collision obj files"))
                Directory.CreateDirectory($@"{Application.StartupPath}\\Map Collision obj files");
            if (!Directory.Exists($@"{Application.StartupPath}\\Dumped NavMeshes"))
                Directory.CreateDirectory($@"{Application.StartupPath}\\Dumped NavMeshes");
            if (!Directory.Exists($"{Application.StartupPath}\\Log Configs"))
                Directory.CreateDirectory($"{Application.StartupPath}\\Log Configs");
            if (!Directory.Exists($"{Application.StartupPath}\\Logs"))
                Directory.CreateDirectory($"{Application.StartupPath}\\Logs");
            var netVersion = Environment.Version.ToString();
            Logger.AddDebugText(rtbDebug, $@".NetFramework v  = ({netVersion})");
            if (!netVersion.Contains("4."))
                Logger.AddDebugText(rtbDebug,
                    "Please Update your .Net framework, https://www.microsoft.com/en-us/download/details.aspx?id=53344");
            if (File.Exists($"{Application.StartupPath}\\FFXINAV.dll"))
            {
                var ffxinaVversion = FileVersionInfo.GetVersionInfo("FFXINAV.dll");
                Logger.AddDebugText(rtbDebug, $@"FFXINAV.dll Found: Version: ({ffxinaVversion.FileVersion})");
                NavBuilder = new Ffxinav();
            }

            if (!File.Exists($"{Application.StartupPath}\\FFXINAV.dll"))
                Logger.AddDebugText(rtbDebug,
                    @"FFXINAV.dll Missing, Please download the latest version from my GitHub,https://github.com/xenonsmurf/FFXI-NavMesh-builder");
            var configPath = $"{Application.StartupPath}\\Log Configs\\Default_Config.conf";
            if (!Directory.Exists(configPath))
                using (var sw = File.CreateText(configPath))
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

            try
            {
                if (NavBuilder.Initialize(configPath)) Logger.AddDebugText(rtbDebug, "FFXINAV: Initialized");
                if (!NavBuilder.Initialize(configPath)) Logger.AddDebugText(rtbDebug, "FFXINAV: Unable to Initialize");
            }
            catch (Exception ex)
            {
                Logger.AddDebugText(rtbDebug, ex.ToString());
            }
        }

        private void DumpAllBtn_Click(object sender, EventArgs e)
        {
            switch (DumpAllBtn.Text)
            {
                case "Dump all map.dats":
                    Logger.AddDebugText(rtbDebug, @"Dumping all map.dats = true");
                    DumpAllBtn.Text = @"Stop Dumping map.dats";
                    DumpingMapDats = true;
                    progressBar1.Enabled = true;
                    progressBar1.Visible = true;
                    DumpDatWorker.RunWorkerAsync();
                    break;

                case "Stop Dumping map.dats":
                    {
                        Logger.AddDebugText(rtbDebug, @"Dumping all map.dats = false");
                        DumpAllBtn.Text = @"Dump all map.dats";
                        if (DumpDatWorker.IsBusy) DumpDatWorker.CancelAsync();
                        DumpingMapDats = false;
                        progressBar1.Enabled = false;
                        progressBar1.Visible = false;
                        break;
                    }
            }
        }

        private void DumpDatWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Zones.Count > 0)
            {
                while (!DumpDatWorker.CancellationPending)
                    if (DumpingMapDats)
                        try
                        {
                            DumpingMapDats = false;
                            var stopWatch1 = new Stopwatch();
                            stopWatch1.Start();
                            foreach (var zn in Zones)
                            {
                                var stopWatch = new Stopwatch();
                                stopWatch.Start();
                                if (DumpDatWorker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    break;
                                }

                                Logger.AddDebugText(rtbDebug, $@"Exporting {zn.Name} ID= {zn.Id.ToString()}");
                                var str = zn.Path.Replace(@"\", @"/");
                                if (zn.Name != "NILL" && zn.Path != "NILL" &&
                                    !File.Exists($@"Map Collision obj files\{zn.Name}.obj"))
                                {
                                    Filename = zn.Name;
                                    Dat = new Dat(this, zn.Name, zn.Id, zn.Type);
                                    var foos = new[] { str };
                                    Dat.Load(foos);
                                }

                                stopWatch.Stop();
                                var ts = stopWatch.Elapsed;
                                var elapsedTime =
                                    $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
                                Logger.AddDebugText(rtbDebug,
                                    $@"Finished dumping {zn.Name} collision data to {zn.Name}.obj'");
                                Logger.AddDebugText(rtbDebug,
                                    $@"Time Taken to dump {zn.Name} collision data to {zn.Name}.obj = {elapsedTime}");
                            }

                            stopWatch1.Stop();
                            var ts1 = stopWatch1.Elapsed;
                            var elapsedTime1 =
                                $"{ts1.Hours:00}:{ts1.Minutes:00}:{ts1.Seconds:00}.{ts1.Milliseconds / 10:00}";
                            Logger.AddDebugText(rtbDebug, @"Finished dumping collision data .obj's");
                            Logger.AddDebugText(rtbDebug,
                                string.Format(@"Time Taken to dump all zones collision data .obj = " + elapsedTime1));
                            var dInfo = new DirectoryInfo($@"{Application.StartupPath}\Map Collision obj files\");
                            var sizeOfDir = DirectorySize(dInfo, true);
                            Logger.AddDebugText(rtbDebug,
                                $@"Map Collsion data OBJ disk space used = {(double)sizeOfDir / (1024 * 1024):N2} MB");
                            DumpingMapDats = false;
                            DumpDatWorker.CancelAsync();
                        }
                        catch (Exception ex)
                        {
                            Logger.AddDebugText(rtbDebug,
                                $@"{ex} Best comment out {Filename} from ZoneList.xml save it,reload and try again. Please use xiExporter to export that map");
                        }
            }
            else
            {
                Logger.AddDebugText(rtbDebug,
                    "Please load the zone list before you try and dump all the collision data to OBJ files");
            }

            Logger.AddDebugText(rtbDebug, @"Dumping all map.dats = false");
            DumpingMapDats = false;
            DumpDatWorker.CancelAsync();
        }

        private void DumpMeshes_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var stopWatch1 = new Stopwatch();
                stopWatch1.Start();
                while (!DumpMeshes.CancellationPending)
                {
                    if (DumpMeshes.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    var path = $"{Application.StartupPath}\\Map Collision obj files\\";
                    var fileCount = Directory.GetFiles(path, "*.obj", SearchOption.AllDirectories).Length;
                    Logger.AddDebugText(rtbDebug,
                        $@"{fileCount.ToString()}.obj files fould in Map Collision obj folder");
                    foreach (var file in Directory.EnumerateFiles(string.Format(path, "*.obj")))
                    {
                        if (DumpMeshes.CancellationPending)
                        {
                            button5.BeginInvoke(new MethodInvoker(() =>
                            {
                                button5.Text = @"Start dumping all zone.obj file navmeshes";
                            }));
                            e.Cancel = true;
                            break;
                        }

                        var result = Path.GetFileName(file);
                        var result2 = result.Substring(0, result.LastIndexOf(".", StringComparison.Ordinal) + 1);
                        if (File.Exists($@"{Application.StartupPath}\\Dumped NavMeshes\\{result2}nav"))
                        {
                            var box = MessageBox.Show($@"Are you sure you want to overwrite {result2}.nav", @"Question",
                                MessageBoxButtons.YesNoCancel);
                            if (box == DialogResult.Yes)
                            {
                                if (!NavBuilder.DumpingMesh && !DumpMeshes.CancellationPending)
                                {
                                    var stopWatch = new Stopwatch();
                                    stopWatch.Start();
                                    Logger.AddDebugText(rtbDebug, $@"Dumping NavMesh for {result2}");
                                    if (NavBuilder.Dump_NavMesh(file) && !DumpMeshes.CancellationPending)
                                    {
                                        stopWatch.Stop();
                                        NavBuilder.UnloadMeshBuilder();
                                        var ts = stopWatch.Elapsed;

                                        // Format and display the TimeSpan value.
                                        var elapsedTime =
                                            $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
                                        Logger.AddDebugText(rtbDebug,
                                            $@"Time Taken to dump mesh {result2} = {elapsedTime} ");
                                    }
                                }
                            }
                            else if (box == DialogResult.Cancel)
                            {
                                button5.BeginInvoke(new MethodInvoker(() =>
                                {
                                    button5.Text = @"Start dumping all zone.obj file navmeshes";
                                }));
                                DumpMeshes.CancelAsync();
                                break;
                            }
                            else if (box == DialogResult.No)
                            {
                                continue;
                            }
                        }

                        if (!File.Exists($@"{Application.StartupPath}\\Dumped NavMeshes\\{result2}nav"))
                            if (!NavBuilder.DumpingMesh && !DumpMeshes.CancellationPending)
                            {
                                var stopWatch = new Stopwatch();
                                stopWatch.Start();
                                Logger.AddDebugText(rtbDebug, $@"Dumping NavMesh for {result2}");
                                if (NavBuilder.Dump_NavMesh(file) && !DumpMeshes.CancellationPending)
                                {
                                    stopWatch.Stop();
                                    NavBuilder.UnloadMeshBuilder();
                                    var ts = stopWatch.Elapsed;

                                    // Format and display the TimeSpan value.
                                    var elapsedTime =
                                        $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
                                    Logger.AddDebugText(rtbDebug,
                                        $@"Time Taken to dump mesh {result2} = {elapsedTime} ");
                                }
                            }

                        if (DumpMeshes.CancellationPending)
                        {
                            button5.BeginInvoke(new MethodInvoker(() =>
                            {
                                button5.Text = @"Start dumping all zone.obj file navmeshes";
                            }));
                            e.Cancel = true;
                            break;
                        }
                    }

                    stopWatch1.Stop();
                    var ts1 = stopWatch1.Elapsed;
                    var elapsedTime1 = $"{ts1.Hours:00}:{ts1.Minutes:00}:{ts1.Seconds:00}.{ts1.Milliseconds / 10:00}";
                    Logger.AddDebugText(rtbDebug, @"Finished dumping NavMesh data");
                    Logger.AddDebugText(rtbDebug,
                        string.Format(@"Time Taken to dump all zones NavMeshes = " + elapsedTime1));
                    var dInfo = new DirectoryInfo($@"{Application.StartupPath}\Dumped NavMeshes\");
                    var sizeOfDir = DirectorySize(dInfo, true);
                    Logger.AddDebugText(rtbDebug,
                        $@"NavMeshes data disk space used = {(double)sizeOfDir / (1024 * 1024):N2} MB");
                    button5.BeginInvoke(new MethodInvoker(() =>
                    {
                        button5.Text = @"Start dumping all zone.obj file navmeshes";
                    }));
                    progressBar1.Enabled = false;
                    progressBar1.Visible = false;
                    DumpMeshes.CancelAsync();
                    return;
                }
            }
            catch (Exception es)
            {
                Logger.AddDebugText(rtbDebug, es.ToString());
            }
        }

        private void DumpSelectedMapDatBtn_Click(object sender, EventArgs e)
        {
            if (mapLB.SelectedItem != null)
                foreach (var zone in Zones.Where(zone => zone.Name == mapLB.SelectedItem.ToString()))
                    ExportSingleMapData(zone.Id.ToString());
            else if (mapLB.SelectedItem == null) Logger.AddDebugText(rtbDebug, "Please Select a zone to Dump.");
        }

        private void ExportSingleMapData(string id)
        {
            try
            {
                foreach (var zn in Zones)
                    if (zn.Id.ToString() == id)
                    {
                        var stopWatch = new Stopwatch();
                        stopWatch.Start();
                        Logger.AddDebugText(rtbDebug, $@"Exporting {zn.Name} ID= {zn.Id.ToString()}");
                        var str = zn.Path.Replace(@"\", @"/");
                        if (zn.Name != "NILL" && zn.Path != "NILL" &&
                            !File.Exists($@"Map Collision obj files\{zn.Name}.obj"))
                        {
                            Filename = zn.Name;
                            Dat = null;
                            Dat = new Dat(this, zn.Name, zn.Id, zn.Type);
                            var foos = new[] { str };
                            Dat.Load(foos);
                        }

                        stopWatch.Stop();
                        var ts = stopWatch.Elapsed;
                        var elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
                        Logger.AddDebugText(rtbDebug, $@"Finished dumping {zn.Name} collision data to {zn.Name}.obj'");
                        Logger.AddDebugText(rtbDebug,
                            $@"Time Taken to dump {zn.Name} collision data to {zn.Name}.obj = {elapsedTime}");
                        return;
                    }
            }
            catch (Exception ex)
            {
                Logger.AddDebugText(rtbDebug,
                    $@"{ex} Best comment out {Filename} from ZoneList.xml save it,reload and try again. Please use xiExporter to export that map");
            }
        }

        private void LoadZones()
        {
            var openDialog = new OpenFileDialog();
            var path = string.Format(Application.StartupPath);
            openDialog.InitialDirectory = path;
            openDialog.FilterIndex = 0;
            if (openDialog.ShowDialog() != DialogResult.OK) return;
            var zoneFilename = openDialog.FileName;
            Logger.AddDebugText(rtbDebug, $@"Nav file loaded = {zoneFilename}");
            try
            {
                Zones = XmlSerializationHelper.Deserialize<List<Zones>>(zoneFilename) ?? new List<Zones>();
                openDialog.Dispose();
                Logger.AddDebugText(rtbDebug, $@"Added {Zones.Count.ToString()} Zones");
                foreach (var item in Zones) mapLB.Items.Add(item.Name);
            }
            catch (Exception ex)
            {
                Logger.AddDebugText(rtbDebug, $@"LoadZones error {ex}");
            }
        }

        private void SearchBoxTB_TextChanged(object sender, EventArgs e)
        {
            if (mapLB.Items.Count <= 0) return;
            if (SearchBoxTB.Text == "") return;
            for (var i = mapLB.Items.Count - 1; i >= 0; i--)
                if (mapLB.Items[i].ToString().StartsWith(SearchBoxTB.Text, StringComparison.CurrentCultureIgnoreCase))
                    mapLB.SelectedItem = mapLB.Items[i];
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadZones();
        }

        #endregion Private Methods
    }
}