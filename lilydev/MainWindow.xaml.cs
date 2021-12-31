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
using System.IO;

using FastColoredTextBoxNS;

namespace fonder.Lilian.Develop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Fluent.RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            switch (DateTime.Now.Hour)
            {
                case 6 or 7 or 8 or 9 or 10 or 11:
                    greeting.Content = "Bonjour !";
                    break;
                case 12 or 13 or 14 or 15 or 16 or 17:
                    greeting.Content = "Bonne après-midi !";
                    break;
                case 18 or 19 or 20 or 21 or 22:
                    greeting.Content = "Bonsoir !";
                    break;
                case 23 or 0 or 1 or 2 or 3 or 4 or 5:
                    greeting.Content = "De beaux rêves~";
                    break;
                default:
                    greeting.Content = "Bienvenue";
                    break;
            }

            
            textBox = new();
            textBox.Dock = DockStyle.Fill;
            textBox.Font = new Font("Consolas", 12, GraphicsUnit.Point);
            textBox.AutoCompleteBracketsList = new char[] { '(', ')', '{', '}', '[', ']', '\"', '\"', '\'', '\'' };
            textBox.AutoScrollMinSize = new System.Drawing.Size(179, 14);
            textBox.BackBrush = null;
            textBox.BackColor = System.Drawing.Color.FromArgb(18,18,18);
            textBox.CaretColor = System.Drawing.Color.White;
            textBox.CharHeight = 14;
            textBox.CharWidth = 8;
            textBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            textBox.DisabledColor = System.Drawing.Color.FromArgb(100,180,180,180);
            textBox.IndentBackColor = System.Drawing.Color.FromArgb(18,18,18);
            textBox.IsReplaceMode = false;
            textBox.LineNumberColor = System.Drawing.Color.FromArgb(43,145,175);
            textBox.Paddings = new Padding(0);
            textBox.SelectionColor = System.Drawing.Color.FromArgb(60,0,0,255);
            textBox.Size = new System.Drawing.Size(464, 292);
            textBox.TabIndex = 0;
            textBox.Text = "fastColoredTextBox1";
            textBox.Zoom = 100;

            textboxhost.Child = textBox;
            
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    PrimaryCodeEditor bookPage = new(true);
        //    InitialiseTabComponent(bookPage);
        //}

        //private void InitialiseTabComponent(IBookPage page, string FileName = null)
        //{
        //    if (!tofile.IsEnabled) tofile.IsEnabled = true;
        //    if (CurrentPages.ContainsKey(page.Name))
        //    {
        //        foreach (var item in mother.Items)
        //        {
        //            TabItem tabItem = (TabItem)item;
        //            if (tabItem.Name == page.Name)
        //            {
        //                tabItem.Focus();
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //mother.Visibility = Visibility.Visible;
        //        //mother.Width = ActualWidth;
        //        //mother.Height = ActualHeight - 48;

        //        page.Fermeture += new Closed(CloseTab);

        //        TabItem tabItem = new()
        //        {
        //            Name = page.Name.Replace(".", null).Replace(":", null).Replace("\\", null),
        //            Header = page.Title,
        //            HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch,
        //            VerticalContentAlignment = System.Windows.VerticalAlignment.Stretch
        //        };
        //        tabItem.Content = page;
        //        mother.Items.Add(tabItem);
        //        mother.SelectedItem = tabItem;

        //        CurrentPages.Add(page.Name, page.Title);
        //    }
        //}
        //private void CloseTab(IBookPage sender, EventArgs e)
        //{
        //    TabItem bruh = null;
        //    foreach (TabItem item in mother.Items)
        //    {
        //        if (sender.Name == ((IBookPage)item.Content).Name)
        //        {
        //            bruh = item;
        //            break;
        //        }
        //    }
        //    if (bruh is not null)
        //    {
        //        CurrentPages.Remove(((IBookPage)bruh.Content).Name);
        //        mother.Items.Remove(bruh);
        //    }

        //    if (mother.Items.Count == 0) tofile.IsEnabled = false;
        //}

        //private void tofile_Click(object sender, RoutedEventArgs e)
        //{
        //    SaveFileDialog fileDialog = new();
        //    if ((mother.SelectedItem as TabItem).Content is PrimaryCodeEditor)
        //    {
        //        TabItem current = mother.SelectedItem as TabItem;
        //        fileDialog.FileName = (current.Content as PrimaryCodeEditor).Name;
        //        fileDialog.Filter = "Script en Lilian|*.lps|Fichier du texte|*.txt|Tous les fichiers|*.*";
        //        fileDialog.DefaultExt = ".lps";
        //        if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            File.WriteAllText(fileDialog.FileName, (current.Content as PrimaryCodeEditor).textBox.Text);
        //            CloseTab(current.Content as PrimaryCodeEditor, null);
        //            InitialiseTabComponent(new PrimaryCodeEditor(false, fileDialog.FileName));
        //            // ineffecient but it's the only way to be sure
        //        }

        //    }
        //}

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    TabItem current = mother.SelectedItem as TabItem;
        //    string filename = (current.Content as PrimaryCodeEditor).EstablishedFileName;
        //    File.WriteAllText(filename, (current.Content as PrimaryCodeEditor).textBox.Text);
        //    CloseTab(current.Content as PrimaryCodeEditor, null);
        //    InitialiseTabComponent(new PrimaryCodeEditor(false, filename));
        //}

        //private void backstageBoys_IsOpenChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    TabItem current = mother.SelectedItem as TabItem;
        //    if (current is null) { ens.IsEnabled = false; return; }
        //    if ((current.Content as PrimaryCodeEditor).EstablishedFileName is not null) ens.IsEnabled = true; else ens.IsEnabled = false;
        //}

        //private void fromfile_Click(object sender, RoutedEventArgs e)
        //{

        //}


        public FastColoredTextBox textBox;
    }
}
