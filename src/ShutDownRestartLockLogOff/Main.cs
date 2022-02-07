// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Main.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The main form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ShutDownRestartLockLogOff
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    /// <summary>
    /// The main form.
    /// </summary>
    public partial class Main : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Locks the work station.
        /// </summary>
        [DllImport("user32")]
        private static extern void LockWorkStation();

        /// <summary>
        /// Exits the window exceptions.
        /// </summary>
        /// <param name="uFlags">The flags.</param>
        /// <param name="dwReason">The reason.</param>
        /// <returns>A <see cref="bool"/> value indicating whether the exit process worked or not.</returns>
        [DllImport("user32")]
        private static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        /// <summary>
        /// Handles the shutdown button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ShutdownButtonClick(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/s /t 0");
        }

        /// <summary>
        /// Handles the restart button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void RestartButtonClick(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/r /t 0");
        }

        /// <summary>
        /// Handles the log off button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void LogOffButtonClick(object sender, EventArgs e)
        {
            ExitWindowsEx(0, 0);
        }

        /// <summary>
        /// Handles the lock button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void LockButtonClick(object sender, EventArgs e)
        {
            LockWorkStation();
        }
    }
}