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
using System.Reflection;

using static fonder.Adelaide.Main;

namespace fonder.Adelaide
{
    /// <summary>
    /// The main interpreter class
    /// </summary>
    public static partial class Main
    {
        /// <summary>
        /// If true, Adelaide will omit every detailed version reference and replaces them with simply the X.X version number.
        /// To invoke release mode, the build string must contain "releaseman" (release to manufacturing in short).
        /// </summary>
        public static bool ReleaseMode { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region cock check1
            if ((Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute)!.InformationalVersion.Contains("releaseman"))
                ReleaseMode = true;
            #endregion

            vername.Content = Assembly.GetExecutingAssembly().GetName().Version!.ToString() + (ReleaseMode ? "" : ", " + (Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute)!.InformationalVersion);
        }
    }
}