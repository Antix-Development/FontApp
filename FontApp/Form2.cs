
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
    }
}
