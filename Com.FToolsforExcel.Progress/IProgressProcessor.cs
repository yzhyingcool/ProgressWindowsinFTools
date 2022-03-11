using System;
using System.Threading;

namespace Com.FToolsforExcel.Progress
{
    public interface IProgressProcessor
    {
        event ProgressChangedEventHandler ProgressChangedEvent;
        //event Action<string> ProgressEvent;
    }
    public static class Extend
    {
        private static ProgressWindow window;
            /// <summary>
            /// 在方法执行前，显示进度窗体。
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="smaple"></param>
            /// <param name="processor">待执行的方法类。</param>
            /// <returns></returns>
        public static bool ShowProgressWindow<T>(this T smaple, IProgressProcessor processor) where T : IProgressProcessor
        {
            bool isShowed = false;
            try
            {
                Thread t = new Thread(() =>
                {
                    window = new ProgressWindow();
                    window.Show();
                    (processor as IProgressProcessor).ProgressChangedEvent += window.SetProgressText;
                    isShowed = window.IsShowed;
                    System.Windows.Threading.Dispatcher.Run();
                });
                t.IsBackground = true;
                t.Priority = ThreadPriority.Highest;
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                while (true)
                {
                    if (isShowed)
                    {
                        break;
                    }
                }
                return true;
            }
            catch (Exception exp)
            {
                return false;
#if DEBUG
                throw new Exception("进度窗体展示出错：\r\n" + exp.Message + "\r\n" + exp.StackTrace);
#endif
            }
        }
        /// <summary>
        /// 关闭进度窗体。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="smaple"></param>
        public static void CloseProgressWindow<T>(this T smaple) where T : IProgressProcessor
        {
            window.Dispatcher.Invoke(() => window.Close());
            System.Windows.Threading.Dispatcher.ExitAllFrames();
        }

    }
}
