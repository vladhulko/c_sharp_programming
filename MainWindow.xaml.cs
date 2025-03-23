using Lab01.ViewModel;
using System.Windows;

namespace Lab01
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}