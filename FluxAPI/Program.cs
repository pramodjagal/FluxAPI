using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using FluxAPI.Classes;

namespace FluxAPI
{
    public class Flux
    {
        public static readonly string ProgramData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        public static readonly string PreFlux = Path.Combine(ProgramData, "Fluxus");
        public static readonly string PostFlux = Path.Combine(PreFlux, "FluxusAPI");
        public static readonly string ModulePath = Path.Combine(PostFlux, "Module.dll");
        public static readonly string FluxPath = Path.Combine(PostFlux, "FluxteamAPI.dll");
        private static readonly string ModuleUrl = "https://github.com/ItzzExcel/LInjectorRedistributables/raw/main/extra/Module.dll";
        private static readonly string FluxURL = "https://github.com/ItzzExcel/LInjectorRedistributables/raw/main/extra/FluxteamAPI.dll";

        public bool IsInitialized;

        public void InitializeAPI()
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
                ThreadBox.MsgThread("Application is recommended to run with Administrator Privileges.", "Fluxus API", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
                Environment.Exit(0);
            }

            IsInitialized = true;
        }

        public async Task CreateDirectories()
        {
            if (!Directory.Exists(PreFlux))
            {
                Directory.CreateDirectory(PreFlux);
                if (!Directory.Exists(PostFlux))
                {
                    Directory.CreateDirectory(PostFlux);
                }
            }
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

        public async Task DownloadDLLs()
        {
            try
            {
                await Utility.DownloadAsync(ModuleUrl, ModulePath); 
                await Utility.DownloadAsync(FluxURL, FluxPath);
            }
            catch (Exception ex)
            {
                ThreadBox.MsgThread("DLLs are already downloaded or are being used by Windows10Universal.exe" +
                                    "\nThis may happened because you opened a new executor instance." +
                                    "\nClose all related to FluxAPI.dll and try again." +
                                    "\nException:\n" + ex.Message);
            }
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
                    FluxusAPI.run_script(FluxusAPI.pid, src);
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
    }
}
