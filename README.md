# ProgressWindowsinFTools
一个简单的WPF进度窗口，使用Thread实现异步进度


![This is an image](https://img2022.cnblogs.com/blog/1458014/202203/1458014-20220311212301549-1253527518.gif)

一、Com.FToolsforExcel.Progress项目
包含
进度窗口类ProgressWindow，用于展示进度；
委托类ProgressChangedEventHandler，参数是自定义的ProgressChangedEventArgs（进度消息参数）类型；
进度消息类ProgressMessageSender，用于封装传递进度消息；
接口IProgressProcessor，提供了进度改变事件及进度窗口打开、关闭的扩展方法。

二、Demo项目
工作类引用命名空间using Com.FToolsforExcel.Progress;

工作类继承ProgressMessageSender类，实现IProgressProcessor接口；

```class ProgramExcute:ProgressMessageSender,IProgressProcessor```

在工作方法中操作窗体与进度
```
public  void Excute(string finishedTips)
  {
  #show窗体
      *if (this.ShowProgressWindow(this))
      {
         for (int i = 0; i < 100; i++)
         {
              Thread.Sleep(200);
              #传递进度
              *OnProgressChanged(this.progressChangedEventHandler, i + 1, 100);
              }
         }
         #关闭窗体
         *this.CloseProgressWindow();
         MessageBox.Show(finishedTips);
  }
  ```
