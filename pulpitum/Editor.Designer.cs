namespace fonder.Lilian.IDE
{
    partial class Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.DocumentRuler = new FastColoredTextBoxNS.Ruler();
            this.DocumentSummaryMap = new FastColoredTextBoxNS.DocumentMap();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // fastColoredTextBox1
            // 
            this.fastColoredTextBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox1.AutoScrollMinSize = new System.Drawing.Size(200, 18);
            this.fastColoredTextBox1.BackBrush = null;
            this.fastColoredTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.fastColoredTextBox1.CharHeight = 18;
            this.fastColoredTextBox1.CharWidth = 9;
            this.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastColoredTextBox1.Font = new System.Drawing.Font("Cascadia Code PL", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fastColoredTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.fastColoredTextBox1.IndentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.fastColoredTextBox1.IsReplaceMode = false;
            this.fastColoredTextBox1.LineNumberColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(145)))), ((int)(((byte)(175)))));
            this.fastColoredTextBox1.Location = new System.Drawing.Point(0, 34);
            this.fastColoredTextBox1.Name = "fastColoredTextBox1";
            this.fastColoredTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox1.ServiceColors")));
            this.fastColoredTextBox1.Size = new System.Drawing.Size(956, 552);
            this.fastColoredTextBox1.TabIndex = 0;
            this.fastColoredTextBox1.Text = "fastColoredTextBox1";
            this.fastColoredTextBox1.Zoom = 100;
            // 
            // DocumentRuler
            // 
            this.DocumentRuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.DocumentRuler.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.DocumentRuler.Dock = System.Windows.Forms.DockStyle.Top;
            this.DocumentRuler.Font = new System.Drawing.Font("Cascadia Code PL", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DocumentRuler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(145)))), ((int)(((byte)(175)))));
            this.DocumentRuler.Location = new System.Drawing.Point(0, 0);
            this.DocumentRuler.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.DocumentRuler.MaximumSize = new System.Drawing.Size(1380525184, 34);
            this.DocumentRuler.MinimumSize = new System.Drawing.Size(0, 34);
            this.DocumentRuler.Name = "DocumentRuler";
            this.DocumentRuler.Size = new System.Drawing.Size(956, 34);
            this.DocumentRuler.TabIndex = 1;
            this.DocumentRuler.Target = this.fastColoredTextBox1;
            // 
            // DocumentSummaryMap
            // 
            this.DocumentSummaryMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.DocumentSummaryMap.Dock = System.Windows.Forms.DockStyle.Right;
            this.DocumentSummaryMap.ForeColor = System.Drawing.Color.White;
            this.DocumentSummaryMap.Location = new System.Drawing.Point(956, 0);
            this.DocumentSummaryMap.Name = "DocumentSummaryMap";
            this.DocumentSummaryMap.Size = new System.Drawing.Size(75, 586);
            this.DocumentSummaryMap.TabIndex = 2;
            this.DocumentSummaryMap.Target = this.fastColoredTextBox1;
            this.DocumentSummaryMap.Text = "documentMap1";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 586);
            this.Controls.Add(this.fastColoredTextBox1);
            this.Controls.Add(this.DocumentRuler);
            this.Controls.Add(this.DocumentSummaryMap);
            this.Name = "Editor";
            this.Text = "Editor";
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        private FastColoredTextBoxNS.Ruler DocumentRuler;
        private FastColoredTextBoxNS.DocumentMap DocumentSummaryMap;
    }
}