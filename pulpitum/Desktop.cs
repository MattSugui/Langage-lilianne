namespace fonder.Lilian.IDE
{
    public partial class Desktop : Form
    {
        public Desktop()
        {
            InitializeComponent();
        }

        private void Desktop_Load(object sender, EventArgs e)
        {

        }

        private void NewCodeButton_Click(object sender, EventArgs e)
        {
        }

        private void Minimise(object sender, EventArgs e)
        {
            var name = sender as ToolStripButton;
            foreach (Form child in MdiChildren)
            {
                if (child.Name == name!.Text)
                {
                    if (name.Checked) child.Show(); else child.Hide();
                }
            }    
        }

        private void codeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editor edit = new();
            edit.MdiParent = this;
            edit.Show();
        }
    }
}