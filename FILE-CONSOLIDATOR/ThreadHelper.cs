using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FILE_CONSOLIDATOR
{
    public class ThreadHelper
    {
        Main frm = null;

        private delegate void SetButtonState(Main f, MetroButton btn, bool stat);
        private delegate void SetLabelValue(Main f, MetroLabel lbl, string val);
        private delegate void SetProgressBar(Main f, MetroProgressBar pb, int val);

        public ThreadHelper()
        {

        }

        public static void SetButton(Main f, MetroButton btn, bool stat)
        {
            if (f.InvokeRequired)
            {
                SetButtonState b = new SetButtonState(SetButton);
                f.Invoke(b, new object[] {f, btn, stat });
            }
            else
                btn.Enabled = stat;
        }

        public static void SetProgressBarValue(Main f, MetroProgressBar pb, int val)
        {
            if (f.pbProgress.InvokeRequired)
            {
                SetProgressBar p = new SetProgressBar(SetProgressBarValue);
                f.Invoke(p, new object[] {f, pb, val });
            }
            else
                pb.Value = 0;
        }

        public static void SetLabel(Main f, MetroLabel pb, string val)
        {
            if (f.InvokeRequired)
            {
                SetLabelValue p = new SetLabelValue(SetLabel);
                f.Invoke(p, new object[] { f, pb, val });
            }
            else
                pb.Text = val;
        }

    }
}
