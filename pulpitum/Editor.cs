﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fonder.Lilian.IDE
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
            men = new(fastColoredTextBox1);
            
        }

        public FastColoredTextBoxNS.AutocompleteMenu men;
    }
}
