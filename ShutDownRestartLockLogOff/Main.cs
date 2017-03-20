using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ShutDownRestartLockLogOff
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        [DllImport("user32")]
        private static extern void LockWorkStation();

        [DllImport("user32")]
        private static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        private void shutdownBtn_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/s /t 0");
        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/r /t 0");
        }

        private void logOffBtn_Click(object sender, EventArgs e)
        {
            ExitWindowsEx(0, 0);
        }

        private void lockBtn_Click(object sender, EventArgs e)
        {
            LockWorkStation();
        }
    }
}