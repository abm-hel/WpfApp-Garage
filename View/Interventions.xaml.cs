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
    /// Logique d'interaction pour Interventions.xaml
    /// </summary>
    public partial class Interventions : Window
    {
        private ViewModel.VM_Intervention localIntervention;
        public Interventions()
        {
            InitializeComponent();
            localIntervention = new ViewModel.VM_Intervention();
            DataContext = localIntervention;
        }

        private void dataGridInterventions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridInterventions.SelectedIndex >= 0)
                localIntervention.InterventionSelectionnee2UneIntervention();
        }
    }
}
