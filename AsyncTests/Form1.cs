using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bruhMoment += HandleBruh;
        }

        internal void HandleBruh(object sender, ArgumentsDEvenements e)
        {

        }

        public class ArgumentsDEvenements : EventArgs
        {
            public ArgumentsDEvenements()
            {
                Message = "ew";
            }

            public string Message { get; init; }
        }

        public event EventHandler<ArgumentsDEvenements> bruhMoment;

        internal static int CurrentItem;
        internal int t;


        public void Do()
        {
            TheW();
        }

        protected virtual void TheW()
        {
            EventHandler<ArgumentsDEvenements> e = bruhMoment;

            if (e != null) e(this, new());
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = $"Stop at: {trackBar1.Value}";
        }



        public void ThreadTest()
        {
            CurrentItem = 0;
            try
            {
                for (CurrentItem = 0; CurrentItem < 50; CurrentItem++)
                {
                    if (CurrentItem == trackBar1.Value) throw new Exception();
                    //timer1.Start();
                        label1.Text = $"bruh {++CurrentItem}/50";
                    label3.Text = new Random().Next(0, int.MaxValue).ToString();
                }
            }
            catch { label1.Text = "lol " + CurrentItem.ToString(); }
            finally { CurrentItem = 0; }
            CurrentItem = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadTest();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = new Random().Next(0, int.MaxValue).ToString();
            t++;
        }
    }

}
