using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using FastColoredTextBoxNS;
using System.Windows.Forms.Integration;

namespace fonder.Lilian.Develop
{
    /// <summary>
    /// Interaction logic for PrimaryCodeEditor.xaml
    /// </summary>
    public partial class PrimaryCodeEditor : System.Windows.Controls.UserControl, MainWindow.IBookPage
    {
        public PrimaryCodeEditor(bool create, string Filename = null)
        {
            InitializeComponent();



            textBox = new();
            textBox.Dock = DockStyle.Fill;
            textBox.Font = new Font("Consolas", 12, GraphicsUnit.Point);
            textBox.AutoCompleteBracketsList = new char[] { '(', ')', '{', '}', '[', ']', '\"', '\"', '\'', '\'' };
            textBox.AutoScrollMinSize = new Size(179, 14);
            textBox.BackBrush = null;
            textBox.BackColor = Color.FromArgb(18, 18, 18);
            textBox.ForeColor = Color.FromArgb(248, 248, 248);
            textBox.CaretColor = Color.White;
            textBox.CharHeight = 14;
            textBox.CharWidth = 8;
            textBox.Cursor = Cursors.IBeam;
            textBox.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            textBox.IndentBackColor = Color.FromArgb(18, 18, 18);
            textBox.IsReplaceMode = false;
            textBox.LineNumberColor = Color.FromArgb(43, 145, 175);
            textBox.Paddings = new Padding(0);
            textBox.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            textBox.Size = new Size(464, 292);
            textBox.TabIndex = 0;
            textBox.Zoom = 100;
            textBox.TextChanged += TextboxUpdated;
            textBox.DescriptionFile = "styles.xml";

            host.Child = textBox;

            try
            {
                if (!create && File.Exists(Filename))
                {
                    textBox.OpenFile(Filename);
                    Name = /*Path.GetFileName*/(Filename);
                    EstablishedFileName = Filename;
                    Title = $"Editeur : {Filename}";
                }
                else if (create)
                {
                    MainWindow.CurrentUntitleds++;
                    Name = $"Untitled{MainWindow.CurrentUntitleds}";
                    Title = $"Editeur : Untitled{MainWindow.CurrentUntitleds}";
                    EstablishedFileName = null;
                }
                else throw new InvalidOperationException("File not found, or in an invalid state");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                close_Click(null, null);
            }
        }
        //private string nm;
        //private string ttl;
        private bool oop = false;
        public new string Name { get; set; }
        public string EstablishedFileName { get; }
        public string Title { get; set; }

        public bool IsDirty { get; }

        public event MainWindow.Closed Fermeture;

        public FastColoredTextBox textBox;

        private void close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Fermeture?.Invoke(this, new EventArgs());
        }

        private void TextboxUpdated(object sender, FastColoredTextBoxNS.TextChangedEventArgs e) => oop = true;


    }
}
