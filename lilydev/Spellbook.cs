using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using FastColoredTextBoxNS;
using System.Windows.Forms.Integration;

namespace fonder.Lilian.Develop
{
    public partial class MainWindow
    {
        public new delegate void Closed(IBookPage sender, EventArgs e);
        public interface IBookPage
        {
            event Closed Fermeture;
            string Title { get; }
            string Name { get; }
        }

    }
}
