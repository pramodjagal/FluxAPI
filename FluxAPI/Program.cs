using FluxAPI.Classes;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace FluxAPI
{
    public class Flux
    {
        private static readonly string ProgramData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        private static readonly string PreFlux = Path.Combine(ProgramData, "Fluxus");
        private static readonly string PostFlux = Path.Combine(PreFlux, "FluxusAPI");
        private static readonly string ModulePath = Path.Combine(PostFlux, "Module.dll");
        private static readonly string FluxPath = Path.Combine(PostFlux, "FluxteamAPI.dll");
        private static readonly string ModuleUrl = "https://github.com/ItzzExcel/LInjectorRedistributables/raw/main/extra/Module.dll";
        private static readonly string FluxURL = "https://github.com/ItzzExcel/LInjectorRedistributables/raw/main/extra/FluxteamAPI.dll";

        private static string InitString;
        public bool DoAutoAttach = false;
        public bool IsAttached = FluxusAPI.is_injected(FluxusAPI.pid);

        private static DispatcherTimer timer = new DispatcherTimer();

        public bool IsInitialized;

        public void InitializeAPI(string ExecutorName = "")
        {
            _ = CreateDirectories();
            _ = DownloadDLLs();
            try
            {
                _ = CreateDirectories();
                _ = DownloadDLLs();
                FluxusAPI.create_files(ModulePath);
            }
            catch (Exception)
            {
                ThreadBox.MsgThread("Couldn't create files of " + ModulePath);
            }

            if (!IsAdmin())
            {
                ThreadBox.MsgThread("Application need to be executed with Administrator Privileges.", "Fluxus API", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
                Environment.Exit(0);
            }

            IsInitialized = true;
            SetExecutorName(ExecutorName);
            runAutoAttachTimer();
        }

        public void SetExecutorName(string executorName)
        {
            InitString =
                $"local a=\"{executorName}\"local b;function Hookin()return a end;b=hookfunction(request,function(c)local d=c.Headers or{{}}d['User-Agent']=a;return b({{Url=c.Url,Method=c.Method or\"GET\",Headers=d,Cookies=c.Cookies or{{}},Body=c.Body or\"\"}})end)b=hookfunction(http.request,function(c)local d=c.Headers or{{}}d['User-Agent']=a;return b({{Url=c.Url,Method=c.Method or\"GET\",Headers=d,Cookies=c.Cookies or{{}},Body=c.Body or\"\"}})end)b=hookfunction(http_request,function(c)local d=c.Headers or{{}}d['User-Agent']=a;return b({{Url=c.Url,Method=c.Method or\"GET\",Headers=d,Cookies=c.Cookies or{{}},Body=c.Body or\"\"}})end)hookfunction(identifyexecutor,Hookin)hookfunction(getexecutorname,Hookin)";
        }

        public void RunInit(object sender, EventArgs e)
        {
            var flag = FluxusAPI.is_injected(FluxusAPI.pid);

            if (flag)
            {
                try
                {
                    FluxusAPI.run_script(FluxusAPI.pid, InitString);
                }
                catch { }
            }

            Task.Delay(200);
        }

        public Task CreateDirectories()
        {
            if (!Directory.Exists(PreFlux))
            {
                Directory.CreateDirectory(PreFlux);
                if (!Directory.Exists(PostFlux))
                {
                    Directory.CreateDirectory(PostFlux);
                }
            }

            return Task.CompletedTask;
        }

        private bool IsAdmin()
        {
            bool isElevated;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            return isElevated;
        }

        public void RunInternalFunctions()
        {
            timer.Tick += RunInit;
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Start();
        }

        public async Task DownloadDLLs()
        {
            try
            {
                await Utility.DownloadAsync(ModuleUrl, ModulePath);
                await Utility.DownloadAsync(FluxURL, FluxPath);
            }
            catch (Exception) { }
        }

        public void Inject()
        {
            if (!IsInitialized)
            {
                ThreadBox.MsgThread("Initialize API First!", "Fluxus API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var flag = !FluxusAPI.is_injected(FluxusAPI.pid);
                if (flag)
                {
                    try
                    {
                        try
                        {
                            FluxusAPI.inject();
                        }
                        catch (Exception ex)
                        {
                            ThreadBox.MsgThread("Fluxus API encountered a unrecoverable error" +
                                                "\nDue to Hyperion Byfron, Fluxus API only supports Roblox from Microsoft Store." +
                                                "\nException:\n"
                                                + ex.Message
                                                + "\nStack Trace:\n"
                                                + ex.StackTrace,
                                "Fluxus API | Exception",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }

                    }
                    catch (Exception ex)
                    {
                        ThreadBox.MsgThread("Error on inject:\n" + ex.Message
                                                                 + "\nStack Trace:\n" + ex.StackTrace,
                            "Fluxus API | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ThreadBox.MsgThread("Already injected", "Fluxus API",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public void Execute(string src)
        {
            try
            {
                var flag = FluxusAPI.is_injected(FluxusAPI.pid);
                if (flag)
                {
                    FluxusAPI.run_script(FluxusAPI.pid, $"{InitString}; {src}");
                    Utility.Cw("Script executed");
                }
                else
                {
                    ThreadBox.MsgThread("Inject API before running script.", "Fluxus API", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                ThreadBox.MsgThread("Fluxus couldn't run the script.", "Fluxus API",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utility.Cw("Exception from Fluxus:\n"
                        + ex.Message
                        + "\nStack Trace:\n"
                        + ex.StackTrace);
            }
        }

        public void runAutoAttachTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += AttachedDetectorTick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        private void AttachedDetectorTick(object sender, EventArgs e)
        {
            if (DoAutoAttach == false)
            {
                return;
            }

            var processesByName = Process.GetProcessesByName("Windows10Universal");
            foreach (var Process in processesByName)
            {
                var FilePath = Process.MainModule.FileName;

                if (FilePath.Contains("ROBLOX"))
                {
                    try
                    {
                        var flag = FluxusAPI.is_injected(FluxusAPI.pid);
                        if (flag)
                        {
                            return;
                        }

                        Inject();
                    }
                    catch { }
                }
            }
        }
    }
}