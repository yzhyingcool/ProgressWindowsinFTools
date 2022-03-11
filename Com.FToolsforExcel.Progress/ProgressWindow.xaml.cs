using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Com.FToolsforExcel.Progress
{
    /// <summary>
    /// ProgressWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ProgressWindow : Window
    {
        public bool IsShowed { get { return this.isShowed; } }
        private bool isShowed = false;
        public ProgressWindow()
        {
            InitializeComponent();
            this._waiting.Visibility = Visibility.Visible;
        }

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this._waiting.Visibility = Visibility.Hidden;
        }
        public void SetProgressText(object sender, ProgressChangedEventArgs e)
        {
            this.lblProgress.Dispatcher.BeginInvoke(new Action(() => this.lblProgress.Content = e.Message));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.isShowed = true;
        }
    }
}
