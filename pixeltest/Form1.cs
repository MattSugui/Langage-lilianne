namespace pixeltest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Screen = new(640, 480);

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

        public Bitmap Screen;
    }
}