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
using System.IO;
using Projet_Garage.Classes;

namespace WpfApp_Garage.View
{
    /// <summary>
    /// Logique d'interaction pour typeEntretiens.xaml
    /// </summary>
    public partial class typeEntretiens : Window
    {
        private ViewModel.VM_TypeEntretien localTypeEntretien;
        public typeEntretiens()
        {
            InitializeComponent();
            localTypeEntretien = new ViewModel.VM_TypeEntretien();
            DataContext = localTypeEntretien;
        }

        private void dataGridTypeEntretiens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridTypeEntretiens.SelectedIndex >= 0)
                localTypeEntretien.typeEntretienSelectionnee2UnTypeEntretien();
        }

        private void dataGridTypeEntretiens_intervention_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridTypeEntretiens_piece_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
