using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using System.Threading;
using MetroFramework.Controls;

namespace FILE_CONSOLIDATOR
{
    public partial class Main : MetroForm
    {
        private string sourcePath = Properties.Settings.Default.SOURCE_FILES;
        private string destinationPath = Properties.Settings.Default.DESTINATION_FILES;
        private string fileExt = Properties.Settings.Default.FILE_EXTENSION;
        private string forInteg = Properties.Settings.Default.FOR_INTEG_FILES;

        public Main()
        {
            InitializeComponent();
        }

        private void StartConsolidation()
        {
            try
            {

                var func = new Functions(this);
                func.Source = sourcePath;
                func.Destination = destinationPath;
                func.FileExtension = fileExt;
                func.GenerateDate = dtpDateTrans.Value;
                func.ForInteg = forInteg;

                if (!func.CheckFilesIfExist())
                {
                    ThreadHelper.SetButton(this, btnStart, false);

                    if (func.Copy())
                    {
                        MetroMessageBox.Show(this, "Generation completed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "No files for integration.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, $"Path {forInteg} still have files. It cannot start consolidation.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception er)
            {
                MetroMessageBox.Show(this, er.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                ThreadHelper.SetProgressBarValue(this, pbProgress, 0);
                ThreadHelper.SetButton(this, btnStart, true);
                ThreadHelper.SetLabel(this, lblFiles, string.Empty);
                ThreadHelper.SetLabel(this, lblTotalFiles, "Total Files");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var thread = new Thread(StartConsolidation);
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
