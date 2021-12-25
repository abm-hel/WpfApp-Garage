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

namespace WpfApp_Garage
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

     

        private void boutonClients_Click(object sender, RoutedEventArgs e)
        {
            View.Clients fenetre = new View.Clients();
            fenetre.ShowDialog();
        }

        private void boutonQuitter_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
