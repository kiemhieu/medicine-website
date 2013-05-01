﻿using System;
using System.Windows.Forms;
using Run.Implementation;

namespace Run
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var manager = new ApplicationManager();
                Application.Run(manager.EntryForm);
                // manager.EntryForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ApplicationManager.HandleException(ex);
            }

        }
    }
}
