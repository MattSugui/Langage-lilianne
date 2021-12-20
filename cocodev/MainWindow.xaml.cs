using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;

using FastColoredTextBoxNS;

namespace fonder.Lilian.Coco.New
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
            textBox = new();
            textBox.Dock = DockStyle.Fill;
            textBox.Font = new Font("Consolas", 12, GraphicsUnit.Point);

            host.Child = textBox;
        }

        public FastColoredTextBox textBox;
    }
}
