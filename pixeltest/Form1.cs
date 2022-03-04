namespace pixeltest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            Screen = new(320, 240);

            //panel2.BackgroundImage = Screen;
            pictureBox1.Image = Screen;

            
            /*
             
                #
                #
                #
                #
                #
                #
                #
             */
        }

        internal void Type()
        {
            for (int y = 0; y < Screen.Height; y++)
            {
                for  (int x = 0; x < Screen.Width; x++)
                { 
                    Screen.SetPixel(x, y, Color.Red);
                    Refresh();
                    //Thread.Sleep(1);
                }
            }
        }

        public Bitmap Screen;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Type();
        }
    }
}