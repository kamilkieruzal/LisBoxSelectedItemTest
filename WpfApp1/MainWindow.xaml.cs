using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var viewModel = new MainWindowViewModel();

            InitializeComponent();
            DataContext = viewModel;
        }

        private void ItemOnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ((ListBoxItem)sender).IsSelected = true;
        }
    }
}
