using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using fonder.Lilian.New.Stuffer;

namespace fonder.Lilian.New.Stuffer.GUI
{
    public partial class TestingForm : Form
    {
        public TestingForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //byte[] imageafter = { 0x0 };
                //using (MemoryStream ms = new(imageafter))
                //{
                //    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                //}

                Common.Stuff((byte[])new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[])), "imagestufftest.lfb", "stufftest");
                pictureBox1.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void imgbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new();
            fd.Filter = "Portable network graphic|*.png|Joint Photographic Experts Group format|*.jpg,*.jpeg|Bitmap|*.bmp|Graphics interchange format|*.gif";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(fd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] bruh;
            try
            {
                bruh = Common.Unbox("imagestufftest.lfb");

                Image thing = (Image)new ImageConverter().ConvertFrom(bruh);

                //using (MemoryStream ms2 = new(bruh))
                //{
                //    thing = Image.FromStream(ms2);
                //}

                pictureBox1.Image = thing;
                MessageBox.Show("Congratulations! The test worked!", "wow!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            byte[] bruh;
            try
            {
                bruh = Common.Unbox("imagestufftest.lfb");

                Image thing = (Image)new ImageConverter().ConvertFrom(bruh);

                //using (MemoryStream ms2 = new(bruh))
                //{
                //    thing = Image.FromStream(ms2);
                //}

                listView1.Items.Add(new ListViewItem(nameof(thing), listView1.Groups[0]));

                MessageBox.Show("Congratulations! The test worked!", "wow!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
