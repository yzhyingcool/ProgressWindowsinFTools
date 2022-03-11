using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Com.FToolsforExcel.Progress;

namespace Demo
{
    class ProgramExcute:ProgressMessageSender,IProgressProcessor
    {
        private ProgressChangedEventHandler progressChangedEventHandler;
        public event ProgressChangedEventHandler ProgressChangedEvent
        {
            add { this.progressChangedEventHandler += value; }
            remove { this.progressChangedEventHandler -= value; }
        }
        public  void Excute(string finishedTips)
        {
            if (this.ShowProgressWindow(this))
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(200);
                    OnProgressChanged(this.progressChangedEventHandler, i + 1, 100);
                }
            }
            this.CloseProgressWindow();
            MessageBox.Show(finishedTips);
        }
    }
}
