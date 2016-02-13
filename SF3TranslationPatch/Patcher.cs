///Shining Force 3 Translation Patcher
///Copyright 2016 Anthony Randazzo
///Email: Knight0fDragon@gmail.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;


namespace SF3TranslationPatch
{

    public partial class Patcher : Form
    {
        string scenario = "1";
        DriveInfo drive = null;
        string region = "";

        /// <summary>
        /// Initializer for Patcher.
        /// Will make sure the files needed are extracted before starting.
        /// Will also auto scan drives looking for Shining Force 3
        /// </summary>
        public Patcher()
        {
            InitializeComponent();
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data");
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data/viewPatch"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data/viewPatch");
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data/viewPatch/s1u"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data/viewPatch/s1u");
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data/viewPatch/s1e"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data/viewPatch/s1e");
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data/viewPatch/s1j"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data/viewPatch/s1j");
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data/viewPatch/s2"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data/viewPatch/s2");
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data/viewPatch/s3"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data/viewPatch/s3");
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data/viewPatch/pd"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data/viewPatch/pd");
            }
            ExtractResource("sf3_1", Directory.GetCurrentDirectory() + "/data/sf3-1.txt");
            ExtractResource("sf3_2", Directory.GetCurrentDirectory() + "/data/sf3-2.txt");
            ExtractResource("sf3_3", Directory.GetCurrentDirectory() + "/data/sf3-3.txt");
            ExtractResource("sf3_p", Directory.GetCurrentDirectory() + "/data/sf3-p.txt");
            ExtractResource("sf32ip", Directory.GetCurrentDirectory() + "/data/sf32ip.bin");
            ExtractResource("SF3Track2", Directory.GetCurrentDirectory() + "/data/SF3Track2.bin");
            ExtractResource("cygwin1", Directory.GetCurrentDirectory() + "/data/cygwin1.dll");
            ExtractResource("mkisofs", Directory.GetCurrentDirectory() + "/data/mkisofs.exe");
            ExtractResource("sf3_1", Directory.GetCurrentDirectory() + "/data/sf3-1.txt");
            ExtractResource("sf3_2", Directory.GetCurrentDirectory() + "/data/sf3-2.txt");
            ExtractResource("sf3_3", Directory.GetCurrentDirectory() + "/data/sf3-3.txt");
            ExtractResource("sf3_p", Directory.GetCurrentDirectory() + "/data/sf3-p.txt");
            ExtractResource("sf32ip", Directory.GetCurrentDirectory() + "/data/sf32ip.bin");
            ExtractResource("SF3Track2", Directory.GetCurrentDirectory() + "/data/SF3Track2.bin");
            ExtractResource("cygwin1", Directory.GetCurrentDirectory() + "/data/cygwin1.dll");
            ExtractResource("mkisofs", Directory.GetCurrentDirectory() + "/data/mkisofs.exe");
            ExtractResource("S1U_1ST_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s1u/1ST.BIN.DFR");
            ExtractResource("S1U_X002_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s1u/X002.BIN.DFR");
            ExtractResource("S1U_X003_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s1u/X003.BIN.DFR");
            ExtractResource("S1U_X006_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s1u/X006.BIN.DFR");
            ExtractResource("S1U_X009_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s1u/X009.BIN.DFR");
            ExtractResource("S1U_X014_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s1u/X014.BIN.DFR");
            ExtractResource("S2_1ST_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s2/1ST.BIN.DFR");
            ExtractResource("S2_X002_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s2/X002.BIN.DFR");
            ExtractResource("S2_X003_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s2/X003.BIN.DFR");
            ExtractResource("S2_X006_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s2/X006.BIN.DFR");
            ExtractResource("S2_X009_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s2/X009.BIN.DFR");
            ExtractResource("S2_X014_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s2/X014.BIN.DFR");
            ExtractResource("S3_1ST_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s3/1ST.BIN.DFR");
            ExtractResource("S3_X002_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s3/X002.BIN.DFR");
            ExtractResource("S3_X003_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s3/X003.BIN.DFR");
            ExtractResource("S3_X006_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s3/X006.BIN.DFR");
            ExtractResource("S3_X009_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s3/X009.BIN.DFR");
            ExtractResource("S3_X014_BIN", Directory.GetCurrentDirectory() + "/data/viewPatch/s3/X014.BIN.DFR");




            scanDrives();
        }

        /// <summary>
        /// Scan all available drives till we hit disc drives with Shining Force 3 loaded
        /// </summary>
        private void scanDrives()
        {
            //Pull all drives attached to the PC
            foreach (DriveInfo drv in DriveInfo.GetDrives())
            {
                //If a drive is not ready, skip it
                if (drv.IsReady == true)
                {

                    //Lets make sure we have a Shining Force 3 Disc
                    string CD_Label = drv.VolumeLabel.ToUpper();
                    if (CD_Label.Contains("SHINING_FORCE_3"))
                    {
                        //We have a disc, the last character will tell us the scenario
                        string[] brokenUp = CD_Label.Split('_');
                        scenario = brokenUp[brokenUp.Length - 1].ToUpper();

                    }
                    else
                    {
                        //This is not a Shining Force 3 game, so skip it
                        continue;
                    }

                    region = "";
                    //P means premium disc
                    if (scenario == "P")
                    {
                        //Prompt to verify this is the disc they want to patch
                        if (MessageBox.Show("Patch Shining Force 3 Premium Disc?", "Premium Disc found!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            drive = drv;
                            lblScenario.Text = "Premium Disk";
                            return;
                        }

                    }
                    //Scenario 1 has 3 versions, US Europe and Japan, we need to figure out the 3
                    else if (scenario == "1")
                    {
                        //If it is not US or JP then it has to be Europe, so lets make that default
                        string str = "E";

                        //Only japanese version is missing Voice.Dat
                        bool jap = !File.Exists(drv.RootDirectory + "/VOICE.DAT");
                        //The US version of the Sega Logo movis is larger than 1K
                        bool us = new FileInfo(drv.RootDirectory + "/SEGALOGO.CPK").Length > 1024 * 1024;

                        if (jap)
                        {
                            str = "J";
                        }
                        else if (us)
                        {
                            str = "U";
                        }

                        //Prompt to verify this is the disc they want to patch
                        if (MessageBox.Show("Patch Shining Force 3 Scenario " + scenario + str + "?", "Scenario " + scenario + str + " found!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            drive = drv;
                            region = str;
                            lblScenario.Text = "Scenario " + scenario + region;
                            return;
                        }


                    }
                    //Has to be scenario 2 or 3
                    else
                    {
                        //Prompt to verify this is the disc they want to patch
                        if (MessageBox.Show("Patch Shining Force 3 Scenario " + scenario + "?", "Scenario " + scenario + " found!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            drive = drv;
                            lblScenario.Text = "Scenario " + scenario;
                            return;
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Heart of the patching process,  will do all the work
        /// Needs to be ran on a background thread
        /// </summary>
        public void Patch()
        {
            //Lets reset the progress bar
            //We should always be invoking because the progress bar needs to update on the main thread
            //if is added just in case.
            if (pBarLoading.InvokeRequired)
            {
                pBarLoading.Invoke(new MethodInvoker(() => { pBarLoading.Value = 0; lblProgressBar.Text = ""; }));
            }
            else
            {
                pBarLoading.Value = 0; lblProgressBar.Text = "";
            }

            //Prompt a dialog box on the main thread to capture the save location
            bool? proceed = null;
            SaveFileDialog sfd = new SaveFileDialog();
            Invoke(new MethodInvoker(() => { proceed = (sfd.ShowDialog() == DialogResult.OK); }));

            //lock up the background thread till we can proceed
            while (proceed == null) ;

            //If we got an OK back from the Save Dialog box
            if (proceed == true)
            {
                //Lets start creating a directory to backup our files to.
                string path = Directory.GetCurrentDirectory();


                if (scenario == "P")
                {
                    path += "/files/pd";
                }
                else
                {
                    path += "/files/s" + scenario;
                    if (region.ToUpper() == "J")
                    {
                        path += region.ToLower();
                    }
                }
                //Check to make sure the translation patch exists before attempting to patch
                if (!Directory.Exists(path))
                {
                    MessageBox.Show("Translation patch does not exist.\r\nMake sure you have a files directory.");
                    return;
                }

                //Copy over files from the CD to HDD
                if (!ExtractCD(drive.Name))
                {
                    MessageBox.Show("Unable to copy over all files from CD.");
                    return;
                }

                //Apply the patch files to the files on HDD
                if (!CopyPatchFiles(path))
                {
                    MessageBox.Show("Unable to apply translation patch files.");
                    return;
                }

                //This is for paul_met's view mod
                if (chkView.Checked)
                {
                    //Apply the mod
                    if (!applyViewPatch(scenario))
                    {
                        MessageBox.Show("Unable to apply View Mod patch");
                        return;
                    }
                }

                //Set the save path without extension
                //we will be creating several files of the same name
                string savepath = sfd.FileName.Substring(0, (sfd.FileName.IndexOf(".") > 0) ? sfd.FileName.IndexOf(".") : sfd.FileName.Length);

                //Creates the CD Image based on the save path
                CreateImage(savepath);
            }


        }

        /// <summary>
        /// Copies all files from one destination to another
        /// </summary>
        /// <param name="source">Source Directory</param>
        /// <param name="target">Target Directory</param>
        public void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {

            Directory.CreateDirectory(target.FullName);

            //Lets make copying 25% of the process.
            //This will happen twice,  once for CD, and once for the patch, giving us 50% of the process done

            //Get the count of files in the directory, and make our interval 1/count * 25%,  if there are no files, set interval to 1
            float len = source.GetFiles().Length;
            float progressBarInterval = (1 / ((len == 0) ? 1 : len)) * 25;
            float progressBarValue = pBarLoading.Value;

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                progressBarValue += progressBarInterval;

                //Update the progress bar
                if (pBarLoading.InvokeRequired)
                {
                    pBarLoading.Invoke(new MethodInvoker(() => { pBarLoading.Value = (int)progressBarValue; lblProgressBar.Text = "Copying Files"; }));
                }
                else
                {
                    pBarLoading.Value = (int)progressBarValue; lblProgressBar.Text = "Copying Files";
                }
                try
                {
                    //CDDA2 is not a readable file, so make a blank file for it
                    if (fi.Name != "CDDA2")
                    {
                        fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                        File.SetAttributes(Path.Combine(target.FullName, fi.Name), FileAttributes.Normal);
                    }
                    else
                    {
                        File.Create(Path.Combine(target.FullName, fi.Name));
                    }
                }
                catch (Exception ex)
                {
                    //We are expecting CDDA2 to fail
                    if (fi.Name != "CDDA2")
                    {
                        throw ex;
                    }
                }

            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        /// <summary>
        /// Remove any existance of old patch attempts
        /// </summary>
        private void DeleteCDFiles()
        {
            try
            {
                if (Directory.Exists(Directory.GetCurrentDirectory() + "/cdfiles"))
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory() + "/cdfiles");

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Copy files from CD to HDD
        /// </summary>
        /// <param name="driveLetter"></param>
        /// <returns></returns>
        private bool ExtractCD(string driveLetter)
        {
            try
            {
                DeleteCDFiles();
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/cdfiles");
                DirectoryInfo source = new DirectoryInfo(driveLetter);
                DirectoryInfo destination = new DirectoryInfo(Directory.GetCurrentDirectory() + "/cdfiles");
                CopyAll(source, destination);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Create the CD Image
        /// </summary>
        /// <param name="path">Path where the CD Image should be saved to</param>
        /// <returns></returns>
        private bool CreateImage(string path)
        {
            try
            {
                if (pBarLoading.InvokeRequired)
                {
                    pBarLoading.Invoke(new MethodInvoker(() => { pBarLoading.Value = 60; lblProgressBar.Text = "Creating Image"; }));
                }
                else
                {
                    pBarLoading.Value = 60; lblProgressBar.Text = "Creating Image";
                }

                //script to tell mkisofs.exe how to layout the files
                string sortscript = "sf3-" + scenario.ToLower() + ".txt";

                string filename = "mkisofs.exe";

                string output = @"-o """ + path + @".bin"" ";
                string sort = @"-sort " + sortscript + @" ";
                string volume = @"-V " + drive.VolumeLabel + " ";
                string abstractFile = @"-abstract ABSTRACT.TXT ";
                string biblio = @"-biblio BIBLIOGR.TXT ";
                string copyright = @"-copyright COPYRIGH.TXT ";
                string boot = @"-G sf32ip.bin ";

                string inFile = @"..\cdfiles\";


                string args = sort + output + volume + abstractFile + biblio + copyright + boot + inFile;
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\data\\";
                startInfo.Arguments = args;
                startInfo.FileName = filename;

                //run mkisofs as an external process
                var proc = System.Diagnostics.Process.Start(startInfo);
                proc.EnableRaisingEvents = true;
                //Wait till the external process ends, then continue patching.
                proc.Exited += (sender, e) => { DeleteCDFiles(); PatchIPBin(path); FinishUp(path); MessageBox.Show("Patch completed successfully!"); };
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Patch the Special Header Info to the CD Image
        /// </summary>
        /// <param name="path">Path of the CD Image</param>
        private void PatchIPBin(string path)
        {
            
            if (pBarLoading.InvokeRequired)
            {
                pBarLoading.Invoke(new MethodInvoker(() => { pBarLoading.Value = 75; lblProgressBar.Text = "Patching Header"; }));
            }
            else
            {
                pBarLoading.Value = 75; lblProgressBar.Text = "Patching Header";
            }
            object ob = Properties.Resources.ResourceManager.GetObject("sf32ip");
            byte[] myResBytes = (byte[])ob;

            using (BinaryWriter writer = new BinaryWriter(File.Open(path + ".bin", FileMode.Open)))
            {
                //Get the version 
                string versionNumber = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
                char[] charArrVersionNumber = versionNumber.ToCharArray();
                
                //Write the version number to the CD Image
                writer.Seek(43, SeekOrigin.Begin);
                writer.Write(charArrVersionNumber, 0, charArrVersionNumber.Length);
                writer.Seek(47, SeekOrigin.Begin);
                writer.Write('\0');

                //Write the Patch date to the CD Image
                //Get the build description, this will contain our last version date
                DateTime date = DateTime.Parse((Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0] as AssemblyDescriptionAttribute).Description);
                writer.Seek(48, SeekOrigin.Begin);
                writer.Write(date.ToString("yyyyMMdd").ToCharArray());

                //Write the scenario to the CD Image
                writer.Seek(121, SeekOrigin.Begin);
                writer.Write(scenario.ToCharArray());


            }

            
        }

        /// <summary>
        /// Move over the Audio track and create the cue sheet 
        /// </summary>
        private void FinishUp(string path)
        {
            //copy track 2
            File.Copy(Path.Combine(Directory.GetCurrentDirectory(), "data/SF3Track2.bin"), path.Substring(0, path.LastIndexOf('\\')) + "/SF3Track2.bin", true);

            //Create the Cue Sheet
            if (pBarLoading.InvokeRequired)
            {
                pBarLoading.Invoke(new MethodInvoker(() => { pBarLoading.Value = 90; lblProgressBar.Text = "Creating Cue"; }));
            }
            else
            {
                pBarLoading.Value = 90; lblProgressBar.Text = "Creating Cue";
            }



            //make cue
            string cue = @"FILE """ + path.Substring(path.LastIndexOf('\\')) + @".bin"" BINARY" + "\r\n" +
                          "  TRACK 01 MODE1/2048" + "\r\n" +
                          "    INDEX 01 00:00:00" + "\r\n" +
                         @"FILE ""SF3Track2.bin"" BINARY" + "\r\n" +
                          "  TRACK 02 AUDIO" + "\r\n" +
                          "    PREGAP 00:02:00" + "\r\n" +
                          "    INDEX 01 00:00:00" + "\r\n";
            File.WriteAllText(path + ".cue", cue);
            if (pBarLoading.InvokeRequired)
            {
                pBarLoading.Invoke(new MethodInvoker(() => { pBarLoading.Value = 100; lblProgressBar.Text = "Patch Complete!"; }));
            }
            else
            {
                pBarLoading.Value = 100; lblProgressBar.Text = "Patch Complete!";
            }

        }


        /// <summary>
        /// Copy over the patch files to the working directory
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool CopyPatchFiles(string path)
        {
            try
            {
                DirectoryInfo source = new DirectoryInfo(path);
                DirectoryInfo destination = new DirectoryInfo(Directory.GetCurrentDirectory() + "/cdfiles");
                CopyAll(source, destination);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Extract Resources from our executable
        /// </summary>
        /// <param name="resName">Name of the resource to extract</param>
        /// <param name="outName">Name of output path/file </param>
        private void ExtractResource(string resName, string outName)
        {
            object ob = Properties.Resources.ResourceManager.GetObject(resName);
            byte[] myResBytes = (byte[])ob;
            if (!File.Exists(outName))
            {
                using (FileStream fsDst = new FileStream(outName, FileMode.CreateNew, FileAccess.Write))
                {
                    byte[] bytes = myResBytes;
                    fsDst.Write(bytes, 0, bytes.Length);
                    fsDst.Close();
                    fsDst.Dispose();
                }
            }
        }

        /// <summary>
        /// Patch Button Press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPatch_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(p => Patch());
        }

        /// <summary>
        /// Rescan Drives Button Press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRescan_Click(object sender, EventArgs e)
        {

            scanDrives();
        }

        private void chkView_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Apply paul_mets View Mod Patch
        /// </summary>
        /// <param name="scenario"></param>
        /// <returns></returns>
        private bool applyViewPatch(string scenario)
        {
            try
            {
                if (pBarLoading.InvokeRequired)
                {
                    pBarLoading.Invoke(new MethodInvoker(() => { pBarLoading.Value = 55; lblProgressBar.Text = "Applying View Patch"; }));
                }
                else
                {
                    pBarLoading.Value = 55; lblProgressBar.Text = "Applying View Patch";
                }

                //Get the directory holding the patches
                DirectoryInfo di;
                switch (scenario + region.ToUpper())
                {
                    case "1U":
                        {
                            di = new DirectoryInfo(Directory.GetCurrentDirectory() + "/data/viewPatch/s1u");

                            break;
                        }
                    case "1J":
                        {
                            di = new DirectoryInfo(Directory.GetCurrentDirectory() + "/data/viewPatch/s1j");

                            break;
                        }
                    case "1E":
                        {
                            di = new DirectoryInfo(Directory.GetCurrentDirectory() + "/data/viewPatch/s1e");

                            break;
                        }
                    case "2":
                        {
                            di = new DirectoryInfo(Directory.GetCurrentDirectory() + "/data/viewPatch/s2");

                            break;
                        }
                    case "3":
                        {
                            di = new DirectoryInfo(Directory.GetCurrentDirectory() + "/data/viewPatch/s3");

                            break;
                        }
                    case "P":
                        {
                            di = new DirectoryInfo(Directory.GetCurrentDirectory() + "/data/viewPatch/pd");

                            break;
                        }
                    default:
                        {
                            di = new DirectoryInfo(Directory.GetCurrentDirectory() + "/data/viewPatch/s1u");
                            break;
                        }
                }

                //Go throu all the files, and apply the patch based on the name of the file
                if (di.GetFiles() != null)
                {
                    foreach (FileInfo file in di.GetFiles())
                    {
                        StreamReader fs = file.OpenText();
                        using (BinaryWriter writer = new BinaryWriter(File.Open(Directory.GetCurrentDirectory() + "/cdfiles/" + file.Name.Replace(".DFR", ""), FileMode.Open)))
                        {
                            while (!fs.EndOfStream)
                            {
                                string line = fs.ReadLine();
                                char[] split = new char[] { '\t' };
                                string[] parts = line.Split(split);
                                ushort address = (ushort)Convert.ToInt32(parts[0], 16);
                                ushort value = (ushort)Convert.ToInt32(parts[1], 16);
                                writer.Seek(address, SeekOrigin.Begin);
                                writer.Write(value);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

    }
}
