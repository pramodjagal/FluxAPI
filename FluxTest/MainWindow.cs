using System;
using System.Windows.Forms;
using FluxAPI;
using FluxAPI.Classes;

namespace FluxTest
{
    public partial class MainWindow : Form
    {
        private protected readonly Flux Fluxus = new Flux();
        public MainWindow()
        {
            InitializeComponent();
            Fluxus.InitializeAPI("Executor");
            Fluxus.DoAutoAttach = true;
        }

        private async void Attach_Click(object sender, EventArgs e)
        {
            await Fluxus.DownloadDLLs();
            Fluxus.Inject();
        }

        private void Run_Click(object sender, EventArgs e)
        {
            Fluxus.Execute(TextBox.Text);
        }

        private async void DlFiles_Click(object sender, EventArgs e)
        {
            await Fluxus.DownloadDLLs();
        }
    }
}
