using FormiumClient;
using NetDimension.NanUI;
using NetDimension.NanUI.DataServiceResource;
using NetDimension.NanUI.EmbeddedFileResource;
using NetDimension.NanUI.LocalFileResource;
using NetDimension.NanUI.ZippedResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperForm
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if NETCOREAPP3_1 || NET5_0
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
#endif

            WinFormium.CreateRuntimeBuilder(env =>
            {
                // You should do some initializing staffs of Cef Environment in this function.
                //您应该在这个函数中初始化Cef环境。
                env.CustomCefCommandLineArguments(cmdLine =>
                {
                    // Configure command line arguments of Cef here.
                    //在此处配置Cef的命令行参数。

                    //cmdLine.AppendSwitch("disable-gpu");
                    //cmdLine.AppendSwitch("disable-gpu-compositing");

                });

                env.CustomCefSettings(settings =>
                {
                    // Configure default Cef settings here.
                    //在此处配置默认Cef设置。
                    settings.WindowlessRenderingEnabled = true;
                });

                env.CustomDefaultBrowserSettings(cefSettings =>
                {
                    // Configure default browser settings here.
                    //在此处配置默认浏览器设置。
                });
            },
            app =>
            {
                // You can configure your application settings of NanUI here.
                //您可以在此处配置NanUI的应用程序设置。
#if DEBUG
                // Use this setting if your application running in DEBUG mode, it will allow user to open or clode DevTools by right-clicking mouse button and selecting menu items on context menu.
                //如果应用程序在调试模式下运行，则使用此设置，用户可以通过右键单击鼠标按钮并选择上下文菜单上的菜单项来打开或关闭DevTools。
                app.UseDebuggingMode();
#endif

                // Use this setting if you want only one instance can be run.
                //如果只希望运行一个实例，请使用此设置。
                app.UseSingleInstance(() =>
                {
                    MessageBox.Show("Instance has already run, only one instance can be run.", "Single Instance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });

                // Register JavaScript Extension by using this method. More info about JavaScript Extension please see the JavaScript Extension chapter in documentation of NanUI.
                //使用此方法注册JavaScript扩展。有关JavaScript扩展的更多信息，请参阅NanUI文档中的JavaScript扩展一章。
                app.RegisterJavaScriptExtension(() => new DemoWindowJavaScriptExtension());

                // Clear all cached files such as cookies, histories, localstorages, etc.
                //清除所有缓存文件，如cookies、历史记录、localstorage等。
                // app.ClearCacheFile();

                app.UseEmbeddedFileResource("http", "main.app.local", "wwwroot");

                // Register LocalFileResource handler which can handle the file resources in local folder.
                //注册LocalFileResource处理程序，它可以处理本地文件夹中的文件资源。
                app.UseLocalFileResource("http", "static.app.local", System.IO.Path.Combine(Application.StartupPath, "LocalFiles"));

                // Register UseZippedResource handler which can handle the resources zipped in archives.
                // Use the following method to load zip file in Resource file of current assembly.
                //注册UseZippedResource处理程序，它可以处理压缩到存档中的资源。
                //使用以下方法在当前程序集的资源文件中加载zip文件。
                app.UseZippedResource("http", "acrylic.example.local", () => new System.IO.MemoryStream(SuperForm.Properties.Resources.AcrylicDemoResource));

                // Or use the code below to load zip file from disk.
                //或者使用下面的代码从磁盘加载zip文件。
                app.UseZippedResource("http", "layered.example.local", System.IO.Path.Combine(Application.StartupPath, "LayeredDemoResource.zip"));

                // Register DataServiceResource handler which can process http request and return data to response.
                // It will find all DataServices in current assembly automatically or you can indicate where to find the DataServices by using the third parameter.
                //注册DataServiceResource处理程序，它可以处理http请求并将数据返回到响应。
                //它将自动查找当前程序集中的所有数据服务，或者您可以使用第三个参数指示在何处查找数据服务。
                app.UseDataServiceResource("https", "api.app.local"); ;

                // Set a main window class inherit Formium here to start appliation message loop.
                //在这里设置一个主窗口类inherit Formium来启动appliation消息循环。
                app.UseMainWindow(context =>
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    // You should return a Formium instatnce here or you can use context.MainForm property to set a Form which does not inherit Formium.
                    //你应该在这里返回一个Formium，否则你可以用context.MainForm属性，设置不继承Formium的表单。
                    // context.MainForm = new Form();

                    return new MainForm();
                });

                // If your application doesn't have a main window such as VSTO applicaitons, you could use this to initialize NanUI and CEF.
                //如果您的应用程序没有VSTO applications这样的主窗口，您可以使用它来初始化NanUI和CEF。
                //app.UseApplicationContext(() => new ApplicationContext());

            })
            // Build the NanUI runtime
            //构建NanUI运行时
            .Build()
            // Run the main process
            //运行主进程
            .Run();
        }
    }
    }
