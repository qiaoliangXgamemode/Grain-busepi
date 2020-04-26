using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace notebook
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public int saveojbk = 0;
        public string SaveFillPath;
        public MainWindow()
        {
            InitializeComponent();
            TeboxSeleTimer();
            TextCache();

        }
        public void TeboxSeleTimer()
        {
            /*
             ^ Timer set
             */

                 DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(TextboxSelect);
            dispatcherTimer.IsEnabled = true;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

        }
        public void TextCache()
        {
            /*
             ^ Timer set
             */

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(TextboxerrorCache);
            dispatcherTimer.IsEnabled = true;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
        }
        public void TextboxerrorCache(object sender, EventArgs e)
        {
            /*
             *Textbox SelectionStart
             */
                var thispath = System.Environment.CurrentDirectory; ;
                Console.WriteLine(thispath.ToString());
                if (System.IO.Directory.Exists(thispath.ToString() + "\\Cache") == false)//如果不存在就创建file文件夹
                {
                    System.IO.Directory.CreateDirectory(thispath + "\\Cache");
                }
                string lines = TextBox_Edit.Text;
                System.IO.File.WriteAllText(thispath+ "\\Cache\\thispath.Cache", lines, Encoding.UTF8);
        }
        public void TextboxSelect(object sender, EventArgs e)
        {
            /*
             *Textbox SelectionStart
             */
            try { Console.WriteLine(TextBox_Edit.SelectionStart.ToString()); } catch { }
        }
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /*
             ^ this Move
             */
            try { this.DragMove();  } catch { }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            System.Windows.Rect r = new System.Windows.Rect(e.NewSize);
            RectangleGeometry gm = new RectangleGeometry(r,6,5);
            ((UIElement)sender).Clip = gm; 
        }

        private void TextBox_Edit_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Edit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.S)
            {
                if (saveojbk != 0)
                {
                    Console.WriteLine("Yes!");
                    saveojbk = 1;
                    string lines = TextBox_Edit.Text;
                    System.IO.File.WriteAllText(SaveFillPath, lines, Encoding.UTF8);
                }
                else
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        saveojbk = 1;
                        Console.WriteLine("You File Yes!");
                        SaveFillPath = saveFileDialog.FileName;
                        string lines = TextBox_Edit.Text;
                        System.IO.File.WriteAllText(SaveFillPath, lines, Encoding.UTF8);
                    }
                    else
                    {
                        MessageBox.Show("Sorry You in File error");
                    }
                }
            }
        }

        private void menuOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                if (openFileDialog.FileName != null)
                {
                    SaveFillPath = openFileDialog.FileName;
                    saveojbk = 1;
                    string openstrfile = System.IO.File.ReadAllText(SaveFillPath, Encoding.UTF8);
                    TextBox_Edit.Text = openstrfile;
                }
                else { Console.WriteLine("error null"); }
            }
            else
            {
                Console.WriteLine("error");
            }
        }

        private void MenuItem_Click_saver(object sender, RoutedEventArgs e)
        {
            if (saveojbk != 0)
            {
                Console.WriteLine("Yes!");
                saveojbk = 1;
                string lines = TextBox_Edit.Text;
                System.IO.File.WriteAllText(SaveFillPath, lines, Encoding.UTF8);
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                {
                    saveojbk = 1;
                    Console.WriteLine("You File Yes!");
                    SaveFillPath = saveFileDialog.FileName;
                    string lines = TextBox_Edit.Text;
                    System.IO.File.WriteAllText(SaveFillPath, lines, Encoding.UTF8);
                }
                else
                {
                    MessageBox.Show("Sorry You in File error");
                }
            }
        }

        private void MenuItem_Click_saver_as(object sender, RoutedEventArgs e)
        {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                Console.WriteLine("You File Yes!");
                SaveFillPath = saveFileDialog.FileName;
                string lines = TextBox_Edit.Text;
                System.IO.File.WriteAllText(SaveFillPath, lines, Encoding.UTF8);
            }
            else {
                Console.WriteLine("error null");
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            System.Environment.Exit(0);
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
