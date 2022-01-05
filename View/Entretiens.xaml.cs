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
using System.Windows.Shapes;

namespace WpfApp_Garage.View
{
    /// <summary>
    /// Logique d'interaction pour Entretiens.xaml
    /// </summary>
    public partial class Entretiens : Window
    {
        private ViewModel.VM_Entretien localEntretien;
        public Entretiens()
        {
            InitializeComponent();
            localEntretien = new ViewModel.VM_Entretien();
            DataContext = localEntretien;
        }

        private void dataGridEntretiens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridEntretiens.SelectedIndex >= 0)
            {
                localEntretien.EntretienSelectionnee2UnEntretien();
            }
        }
    }
}
