using System;
using System.Threading;
using Medical.Forms.Enums;
using Medical.Forms.Implements;
using Medical.Forms.Interfaces;
using Medical.Forms.UI;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.Forms.MockTest.Test01
{
    public partial class Test : DockContent
    {
        public Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            

        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            try
            {
                throw new Exception("Fucking good");
            }
            catch (Exception ex)
            {
                ExceptionHandler.Instance.HandlerException(ex);
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            MethodExecuter.Instance.Execute(DoProcess);
        }

        private void DoProcess()
        {
            MethodExecuter.Instance.ResetProgress(100, "...");
            for (int i = 0;i<10;i++)
            {
                Thread.Sleep(1000);
                MethodExecuter.Instance.UpdateProgress(10, "Add (" +i +")", ProgressUpdateMode.AddProgress);
            }
            
        }

        private void DoProcessWithErrro()
        {
            MethodExecuter.Instance.ResetProgress(100, "...");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                MethodExecuter.Instance.UpdateProgress(10, "Add (" + i + ")", ProgressUpdateMode.AddProgress);
                if (i == 8) throw new Exception("Custom error occur to test the function");
            }
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            MethodExecuter.Instance.Execute(DoProcessWithErrro);
        }
    }
}
