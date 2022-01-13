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
using WpfApp_Garage.ViewModel;

namespace WpfApp_Garage
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ViewModel.VM_TableauBord localTableauBord;

        public BaseCommande remplirEntretienIntervention { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            localTableauBord = new ViewModel.VM_TableauBord();
            DataContext = localTableauBord;
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

        private void boutonModeles_Click(object sender, RoutedEventArgs e)
        {
            View.Modeles fenetre = new View.Modeles();
            fenetre.ShowDialog();
        }

        private void boutonPieces_Click(object sender, RoutedEventArgs e)
        {
            View.Pieces fenetre = new View.Pieces();
            fenetre.ShowDialog();
        }

        private void boutonIntervention_Click(object sender, RoutedEventArgs e)
        {
            View.Interventions fenetre = new View.Interventions();
            fenetre.ShowDialog();
        }

        private void boutonVehicule_Click(object sender, RoutedEventArgs e)
        {
            View.Vehicules fenetre = new View.Vehicules();
            fenetre.ShowDialog();
        }

        private void boutonTypeEntretien_Click(object sender, RoutedEventArgs e)
        {
            View.typeEntretiens fenetre = new View.typeEntretiens();
            fenetre.ShowDialog();
        }

        private void boutonEntretien_Click(object sender, RoutedEventArgs e)
        {
            View.Entretiens fenetre = new View.Entretiens();
            fenetre.ShowDialog();
        }

        private void dataGridInterventions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridInterventions.SelectedIndex >= 0)
                localTableauBord.InterventionSelectionnee2UneIntervention();
        }

        private void dataGridEntretiens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridEntretiens.SelectedIndex >= 0)
                localTableauBord.EntretienSelectionnee2UnEntretien();
        }

        private void dataGridEntretiens2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridEntretiens2.SelectedIndex >= 0)
                localTableauBord.EntretienSelectionnee2UnEntretien();
        }

        private void dataGridEntretien_Interventions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
