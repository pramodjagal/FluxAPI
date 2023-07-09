# FluxAPI
FluxAPI, simple exploit API.

### How this works
JJSploit, by WeAreDevs got dissasembled and a guy on [GitHub uploaded a repository](https://github.com/MoistMonkey420/MicrosoftRobloxFluxAPI/tree/main/RobloxLuaGitHub)
showing an example of how to use it.
There are more ports of this type, like this thread on [WeAreDevs](https://forum.wearedevs.net/t/34077)

This Class Library I created uses the [JJploit](https://wearedevs.net/dinfo/JJSploit) DLLs, provided by [Fluxus](https://fluxteam.net).

## Documentation
#### How to create a simple executor with FluxAPI:
Add the FluxAPI.dll to references of your Visual Studio Project, we need the next things:
- .NET Framework 4.8 Project (Windows Forms or WPF (Windows Presentation Framework))
- x86 Build Configuration
- Simple C# Knowledge<br>
- This will work on Roblox UWP, not Web Version
In the entry of your program. Put the class name above the declaration of the form, here is an example: 
```csharp
private protected readonly Flux Fluxus = new Flux(); // Here, we're declaring the API.
public MainWindow()
{
      InitializeComponent(); 
}
```

Then, we need to Initialize the API, this will download files and redistributables of the API, like FluxteamAPI.dll and Module.dll into `./ProgramData` folder, located in C:\ProgramData
```csharp
Fluxus.InitializeAPI();
/* If you want to ensure it downloads the DLLs you can put Fluxus.DownloadDLLs();
below the InitializeAPI line (not recommended). */
```

We start the nice things, how to inject, is super-simple, just do: 
```csharp
Fluxus.Inject();
```

For executing we need a Textbox in our project, here is an example:

```csharp
private void Execute(object sender, EventArgs e)
{
      Fluxus.Execute(TextBox.Text);
}
```

**Our code should be like this:**
```csharp
using System;
using System.Windows.Forms;
using FluxAPI;

namespace FluxTest
{
    public partial class MainWindow : Form
    {
        private protected readonly Flux Fluxus = new Flux();
        public MainWindow()
        {
            InitializeComponent(); 
            Fluxus.InitializeAPI();
        }

        private async void Attach_Click(object sender, EventArgs e)
        {
            Fluxus.Inject();
        }

        private void Run_Click(object sender, EventArgs e)
        {
            Fluxus.Execute(TextBox.Text);
        }
    }
}
 
```