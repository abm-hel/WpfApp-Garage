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
    /// Logique d'interaction pour Vehicules.xaml
    /// </summary>
    public partial class Vehicules : Window
    {
        private ViewModel.VM_Vehicule localVehicule;
        public Vehicules()
        {
            InitializeComponent();
            localVehicule = new ViewModel.VM_Vehicule();
            DataContext = localVehicule;
        }

        private void dataGridVehicules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridVehicules.SelectedIndex >= 0)
                localVehicule.VehiculeSelectionnee2UnVehicule();
        }
    }
}
