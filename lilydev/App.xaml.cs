using ControlzEx.Theming;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace fonder.Lilian.Develop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // now set the Green color scheme and dark base color
            ThemeManager.Current.ChangeTheme(Current, "Light.Crimson");

            base.OnStartup(e);
        }
    }
}
