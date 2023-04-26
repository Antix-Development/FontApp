
using System.Diagnostics;

namespace FontApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label5.Text = $"FontApp version {Application.ProductVersion}.";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start(new ProcessStartInfo { FileName = "https://github.com/Antix-Development/FontApp", UseShellExecute = true });

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start(new ProcessStartInfo { FileName = "https://www.buymeacoffee.com/antixdevelu", UseShellExecute = true });

    }
}
