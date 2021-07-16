using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TranslationWPF.ViewModel;

namespace TranslationWPF
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            LanguageViewModel lvm = new LanguageViewModel();
            InitializeComponent();
            DataContext = lvm;

            ////If there is another culture defined.
            //if (!String.IsNullOrEmpty(Thread.CurrentThread.CurrentCulture.Name))
            //{
            //    //Override the default culture of all threads in the application.
            //    lvm.SetDefaultCulture(CultureInfo.CreateSpecificCulture(Thread.CurrentThread.CurrentCulture.Name));
            //}
        }
    }
}
