using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FILE_CONSOLIDATOR
{
    public class Functions
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public string FileExtension { get; set; }
        public string ForInteg { get; set; }
        public DateTime GenerateDate { get; set; }

        private List<string> branchFolders = new List<string>();
        private List<string> branchSubFolders = new List<string>();
        private List<string> syncedFiles = new List<string>();

        Main frm = null;

        private string appLogs = Path.Combine(Application.StartupPath, "AppLog.txt");

        public delegate void UpdateProgress(Int32 totalFiles, Int32 copiedFiles, string currentFile);

        public Functions(Main _frm)
        {
            frm = _frm;
        }

        private void UpdateBar(Int32 totalFiles, Int32 copiedFiles, string currentFile)
        {
            if (frm.InvokeRequired)
            {
                UpdateProgress d = new UpdateProgress(UpdateBar);
                frm.Invoke(d, new object[] { totalFiles, copiedFiles, currentFile });
            }
            else
            {
                frm.pbProgress.Maximum = totalFiles;

                frm.pbProgress.Value = copiedFiles;

                frm.lblTotalFiles.Text = $"Total files ({copiedFiles}/{totalFiles})";

                frm.lblFiles.Text = currentFile;
            }
        }

        public bool CheckFilesIfExist()
        {
            if (!Directory.Exists(ForInteg))
                Directory.CreateDirectory(ForInteg);

            return Directory.GetFiles(ForInteg, FileExtension, SearchOption.AllDirectories).Length > 0 ? true : false;
        }

        public bool Copy()
        {
            try
            {
                string ttypeFolder = string.Empty;
                string destinationFolderName = string.Empty;
                string forIntegFolderName = string.Empty;
                string newFileName = string.Empty;
                string newForIntegFileName = string.Empty;
                string fileName = string.Empty;
                int count = 0;

                branchFolders = Directory.GetDirectories(Source).ToList();

                if (!Directory.Exists(Destination))
                    Directory.CreateDirectory(Destination);

                int totalCount = Directory.GetFiles(Source, FileExtension, SearchOption.AllDirectories).Length - Directory.GetFiles(Destination, FileExtension, SearchOption.AllDirectories).Length;

                foreach (var subFolders in branchFolders)
                {
                    branchSubFolders = Directory.GetDirectories(subFolders).ToList();

                    foreach (var transTypeFolder in branchSubFolders)
                    {
                        syncedFiles = new List<string>();

                        ttypeFolder = transTypeFolder.Split('\\').Last();
                        destinationFolderName = Path.Combine(Destination, ttypeFolder);
                        forIntegFolderName = Path.Combine(ForInteg, ttypeFolder);

                        syncedFiles = Directory.GetFiles(transTypeFolder).Where(n => new FileInfo(n).LastWriteTime.Year == GenerateDate.Year && new FileInfo(n).LastWriteTime.Month == GenerateDate.Month).ToList();

                        //var test = Directory.GetFiles(Source, FileExtension, SearchOption.AllDirectories).Where(n => new FileInfo(n).LastWriteTime.Year == GenerateDate.Year && new FileInfo(n).LastWriteTime.Month == GenerateDate.Month).ToList();

                        

                        if (!Directory.Exists(destinationFolderName))
                            Directory.CreateDirectory(destinationFolderName);


                        if (!Directory.Exists(forIntegFolderName))
                            Directory.CreateDirectory(forIntegFolderName);


                        foreach (var file in syncedFiles)
                        {
                            fileName = Path.GetFileName(file);
                            newFileName = Path.Combine(destinationFolderName, fileName);
                            newForIntegFileName = Path.Combine(forIntegFolderName, fileName);

                            //Check if exist in consolidated folder
                            if (!File.Exists(newFileName))
                            {
                                //Copy file to for integration folder
                                File.Copy(file, Path.Combine(file, newForIntegFileName));

                                //Copy file to consolidated folder
                                File.Copy(file, newFileName);

                                //Write logs 
                                File.AppendAllText(appLogs, $"{DateTime.Now.ToString()} - {fileName} transfer successfully. {Environment.NewLine}");

                                //count transfered files
                                count += 1;

                                UpdateBar(totalCount, count, fileName);
                            }
                        }
                    }
                }

                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch 
            {

                throw;
            }
        }
    }
}
