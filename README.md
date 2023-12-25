# .Net4.6.2-WPF
使用说明

系统采用MVVM模式

整体样式采用 https://github.com/MahApps/MahApps.Metro

首页选项卡组件采用(非TabControl) https://github.com/Dirkster99/AvalonDock

Dialog 组件采用https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit框架内的Dialogs

Dialogs用法

1、全局用法

在MainWindow 中Grid上一级增加materialDesign:DialogHost包裹

xaml：
```
<materialDesign:DialogHost Identifier="GlobalHost">
 <Grid>
 </Grid>	
</materialDesign:DialogHost>
```
1.1 无加载动画在使用位置直接调用

.cs：
```
var file = new EmailEdit(message);//自定义的弹窗页面

if (!DialogHost.IsDialogOpen("GlobalHost"))
{
    await DialogHost.Show(file, "GlobalHost",ClosingEventHandler);    
}
```
ClosingEventHandler页面关闭事件
```
 private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs) 
 {       
      string parameter = eventArgs.Parameter as string;      
 }
 ```
 注意页面关闭事件内禁止继续嵌套Dialogs组件如需继续弹窗请使用如下写法
 ```
 var result = await DialogHost.Show(file, "GlobalHost"); 
 string parameter = result as string; 
  if (!DialogHost.IsDialogOpen("GlobalHost"))  
  {  
    await DialogHost.Show(file, "GlobalHost");    
  }
  ```
 1.2 需要加载动画
 
.cs：
```
var progressDialog = new SampleProgressDialog();//自定义加载页面
 if (!DialogHost.IsDialogOpen("GlobalHost")) 
 { 
     await DialogHost.Show(progressDialog, "GlobalHost", (object sender, DialogOpenedEventArgs eventArgs) =>     
     {     
         dialogOpenedEventHandler(sender, eventArgs);         
     });
     
 }
 ```
VM:
```
 OnProcess?.Invoke(async (object sender, DialogOpenedEventArgs eventArgs) => 
 { 
   await Task.Run(async () =>{}).ContinueWith((t, _) => eventArgs.Session.Close(), null, TaskScheduler.FromCurrentSynchronizationContext());   
 });
 ```
 
