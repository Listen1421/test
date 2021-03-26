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
                //��Ӧ������������г�ʼ��Cef������
                env.CustomCefCommandLineArguments(cmdLine =>
                {
                    // Configure command line arguments of Cef here.
                    //�ڴ˴�����Cef�������в�����

                    //cmdLine.AppendSwitch("disable-gpu");
                    //cmdLine.AppendSwitch("disable-gpu-compositing");

                });

                env.CustomCefSettings(settings =>
                {
                    // Configure default Cef settings here.
                    //�ڴ˴�����Ĭ��Cef���á�
                    settings.WindowlessRenderingEnabled = true;
                });

                env.CustomDefaultBrowserSettings(cefSettings =>
                {
                    // Configure default browser settings here.
                    //�ڴ˴�����Ĭ����������á�
                });
            },
            app =>
            {
                // You can configure your application settings of NanUI here.
                //�������ڴ˴�����NanUI��Ӧ�ó������á�
#if DEBUG
                // Use this setting if your application running in DEBUG mode, it will allow user to open or clode DevTools by right-clicking mouse button and selecting menu items on context menu.
                //���Ӧ�ó����ڵ���ģʽ�����У���ʹ�ô����ã��û�����ͨ���Ҽ�������갴ť��ѡ�������Ĳ˵��ϵĲ˵������򿪻�ر�DevTools��
                app.UseDebuggingMode();
#endif

                // Use this setting if you want only one instance can be run.
                //���ֻϣ������һ��ʵ������ʹ�ô����á�
                app.UseSingleInstance(() =>
                {
                    MessageBox.Show("Instance has already run, only one instance can be run.", "Single Instance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });

                // Register JavaScript Extension by using this method. More info about JavaScript Extension please see the JavaScript Extension chapter in documentation of NanUI.
                //ʹ�ô˷���ע��JavaScript��չ���й�JavaScript��չ�ĸ�����Ϣ�������NanUI�ĵ��е�JavaScript��չһ�¡�
                app.RegisterJavaScriptExtension(() => new DemoWindowJavaScriptExtension());

                // Clear all cached files such as cookies, histories, localstorages, etc.
                //������л����ļ�����cookies����ʷ��¼��localstorage�ȡ�
                // app.ClearCacheFile();

                app.UseEmbeddedFileResource("http", "main.app.local", "wwwroot");

                // Register LocalFileResource handler which can handle the file resources in local folder.
                //ע��LocalFileResource������������Դ������ļ����е��ļ���Դ��
                app.UseLocalFileResource("http", "static.app.local", System.IO.Path.Combine(Application.StartupPath, "LocalFiles"));

                // Register UseZippedResource handler which can handle the resources zipped in archives.
                // Use the following method to load zip file in Resource file of current assembly.
                //ע��UseZippedResource������������Դ���ѹ�����浵�е���Դ��
                //ʹ�����·����ڵ�ǰ���򼯵���Դ�ļ��м���zip�ļ���
                app.UseZippedResource("http", "acrylic.example.local", () => new System.IO.MemoryStream(SuperForm.Properties.Resources.AcrylicDemoResource));

                // Or use the code below to load zip file from disk.
                //����ʹ������Ĵ���Ӵ��̼���zip�ļ���
                app.UseZippedResource("http", "layered.example.local", System.IO.Path.Combine(Application.StartupPath, "LayeredDemoResource.zip"));

                // Register DataServiceResource handler which can process http request and return data to response.
                // It will find all DataServices in current assembly automatically or you can indicate where to find the DataServices by using the third parameter.
                //ע��DataServiceResource������������Դ���http���󲢽����ݷ��ص���Ӧ��
                //�����Զ����ҵ�ǰ�����е��������ݷ��񣬻���������ʹ�õ���������ָʾ�ںδ��������ݷ���
                app.UseDataServiceResource("https", "api.app.local"); ;

                // Set a main window class inherit Formium here to start appliation message loop.
                //����������һ����������inherit Formium������appliation��Ϣѭ����
                app.UseMainWindow(context =>
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    // You should return a Formium instatnce here or you can use context.MainForm property to set a Form which does not inherit Formium.
                    //��Ӧ�������ﷵ��һ��Formium�������������context.MainForm���ԣ����ò��̳�Formium�ı���
                    // context.MainForm = new Form();

                    return new MainForm();
                });

                // If your application doesn't have a main window such as VSTO applicaitons, you could use this to initialize NanUI and CEF.
                //�������Ӧ�ó���û��VSTO applications�����������ڣ�������ʹ��������ʼ��NanUI��CEF��
                //app.UseApplicationContext(() => new ApplicationContext());

            })
            // Build the NanUI runtime
            //����NanUI����ʱ
            .Build()
            // Run the main process
            //����������
            .Run();
        }
    }
    }
