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
using System.IO;
using System.Diagnostics;

namespace TestSuite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DirectoryInfo workDirrectory = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Portal\features");
        public MainWindow()
        {
            InitializeComponent();
            
            foreach (var item in GetFiles())
            {
                listOfTests.Items.Add(item.Name);
            }
        }
        public static FileInfo[] GetFiles()
        {
            FileInfo[] tests = workDirrectory.GetFiles("*.feature");
            return tests;
        }

        private void listOfTests_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StartTest();
        }

        private void runButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StartTest();
        }
        private void StartTest()
        {
            string closeMode = @"/k";
            if (closeConsole.IsChecked ?? false)
            {
                closeMode = @"/c";
            }
            ProcessStartInfo cmd = new ProcessStartInfo();
            cmd.FileName = "cmd";
            cmd.Arguments = String.Format(@"{0} cucumber {1}\{2}", closeMode,workDirrectory,listOfTests.SelectedItem);
            Process.Start(cmd);
        }

        private void rubAllTestButton_Click(object sender, RoutedEventArgs e)
        {
            string closeMode = @"/k";
            if (closeConsole.IsChecked ?? false)
            {
                closeMode = @"/c";
            }
            ProcessStartInfo cmd = new ProcessStartInfo();
            cmd.FileName = "cmd";

            cmd.Arguments = String.Format(@"{0} cucumber {1}", closeMode, workDirrectory.FullName);
            Process.Start(cmd);
        }

        private void runButton_Click(object sender, RoutedEventArgs e)
        {
            StartTest();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }

    
}
