using Projet_Garage.Classes;
using Projet_Garage.Gestion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
        private string chaineConnexion = ConfigurationManager.ConnectionStrings["WpfApp_Garage.Properties.Settings.chaineConnexionBD"].ConnectionString;
       // public BaseCommande remplirEntretienIntervention { get; set; }
        public RichTextBox richTextBoxFiche= new RichTextBox();
        public RichTextBox richTextBoxFacture = new RichTextBox();
        public RichTextBox richTextBoxReleve = new RichTextBox();
        public MainWindow()
        {
            InitializeComponent();
            localTableauBord = new VM_TableauBord();

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
            if (dataGridEntretien_Interventions.SelectedIndex >= 0)
                localTableauBord.Entretien_InterventionSelectionnee2UneEntretien_Intervention();
        }

        private void dataGridEntretien_Pieces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridEntretien_Pieces.SelectedIndex >= 0)
                localTableauBord.Entretien_PieceSelectionnee2UneEntretien_Piece();
        }

        private void dataGridEntretiens3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridEntretiens3.SelectedIndex >= 0)
                localTableauBord.EntretienSelectionnee2UnEntretien();
        }

        private void dataGridTypeEntretiens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridTypeEntretiens.SelectedIndex >= 0)
            {
                localTableauBord.TypeEntretienSelectionnee2UnTypeEntretien();
            }
        }

        private void buttonGenererFacture_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxEntretien.SelectedValue == null)
            {
                MessageBox.Show("Veuillez choisir un entretien !");
            }

            else
            {
                C_Entretien entretien = new G_Entretien(chaineConnexion).Lire_ID(Convert.ToInt32(comboBoxEntretien.SelectedValue));
                C_Vehicule vehicule = new G_Vehicule(chaineConnexion).Lire_ID(Convert.ToInt32(entretien.vehiculeId));
                List<C_Entretien_Intervention> interventions = new G_Entretien_Intervention(chaineConnexion).Lire("id");
                List<C_Entretien_Piece> pieces = new G_Entretien_Piece(chaineConnexion).Lire("id");
                FlowDocument fdFacture = new FlowDocument();
                Paragraph p = new Paragraph();

                p.Inlines.Add(new Bold(new Run("Facture " + entretien.id + " - " + Convert.ToDateTime(entretien.datePassage).ToString("dd/MM/yyyy").ToString())));
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new Bold(new Run("Interventions")));
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());



                foreach (C_Entretien_Intervention intervention in interventions)
                {
                    if (intervention.entretienId == Convert.ToInt32(comboBoxEntretien.SelectedValue))
                    {
                        C_Intervention i = new G_Intervention(chaineConnexion).Lire_ID(Convert.ToInt32(intervention.interventionId));

                        p.Inlines.Add(i.description);
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add(string.Format("{0:0.00}", intervention.prixHeure) + " € / h" + "\t" + i.nombreHeures + " heure(s)" + "\t" + string.Format("{0:0.0}", intervention.tva) + " % TVA" + "\t" + string.Format("{0:0.00}", intervention.prix + (intervention.prix * intervention.tva / 100) + " € TTC"));
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add(new LineBreak());
                    }
                }

                p.Inlines.Add(new Bold(new Run("Pièces")));
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());

                foreach (C_Entretien_Piece piece in pieces)
                {
                    if (piece.entretienId == Convert.ToInt32(comboBoxEntretien.SelectedValue))
                    {
                        C_Piece pi = new G_Piece(chaineConnexion).Lire_ID(Convert.ToInt32(piece.pieceId));
                        p.Inlines.Add(pi.fabricant + " " + pi.nom);
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add(string.Format("{0:0.00}", pi.prix) + " € / pièce" + "\t" + " x " + piece.quantite + "\t" + string.Format("{0:0.0}", piece.tva) + " % TVA" + "\t" + string.Format("{0:0.00}", piece.prix * piece.quantite + (piece.prix * piece.quantite * piece.tva / 100)) + " € TTC");
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add(new LineBreak());


                    }
                }

                fdFacture.Blocks.Add(p);
                richTextBoxFacture.Document = fdFacture;
                FileStream fs = new FileStream(@"Facture" + entretien.id + ".rtf", FileMode.Create);
                TextRange tr = new TextRange(richTextBoxFacture.Document.ContentStart, richTextBoxFacture.Document.ContentEnd);
                tr.Save(fs, System.Windows.DataFormats.Rtf);
                MessageBox.Show("Facture créée !");
            }
            

        }

        private void buttonGenererFicheEntreeVehicule_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxEntretien.SelectedValue == null)
            {
                MessageBox.Show("Veuillez choisir un entretien !");
            }

            else
            {
                C_Entretien entretien = new G_Entretien(chaineConnexion).Lire_ID(Convert.ToInt32(comboBoxEntretien.SelectedValue));
                C_Vehicule vehicule = new G_Vehicule(chaineConnexion).Lire_ID(Convert.ToInt32(entretien.vehiculeId));
                List<C_Entretien_Intervention> interventions = new G_Entretien_Intervention(chaineConnexion).Lire("id");
                List<C_Entretien_Piece> pieces = new G_Entretien_Piece(chaineConnexion).Lire("id");
                FlowDocument fdFicheEntree = new FlowDocument();
                Paragraph p = new Paragraph();
                p.Inlines.Add(new Bold(new Run("Fiche d'entrée pour le véhicule " + vehicule.immatriculation + "(" + Convert.ToDateTime(entretien.datePassage).ToString("dd/MM/yyyy") + ")".ToString())));
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new Bold(new Run("Interventions à effectuer")));

                foreach (C_Entretien_Intervention intervention in interventions)
                {
                    if (intervention.entretienId == Convert.ToInt32(comboBoxEntretien.SelectedValue))
                    {
                        C_Intervention i = new G_Intervention(chaineConnexion).Lire_ID(Convert.ToInt32(intervention.interventionId));

                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add(i.description);
                    }
                }
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new Bold(new Run("Pièces nécessaires")));

                foreach (C_Entretien_Piece piece in pieces)
                {
                    if (piece.entretienId == Convert.ToInt32(comboBoxEntretien.SelectedValue))
                    {
                        C_Piece pi = new G_Piece(chaineConnexion).Lire_ID(Convert.ToInt32(piece.pieceId));

                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add(pi.nom+"\tx"+piece.quantite);
                    }
                }

                fdFicheEntree.Blocks.Add(p);
                richTextBoxFiche.Document = fdFicheEntree;
                FileStream fs = new FileStream(@"Fiche" + entretien.id + ".rtf", FileMode.Create);
                TextRange tr = new TextRange(richTextBoxFiche.Document.ContentStart, richTextBoxFiche.Document.ContentEnd);
                tr.Save(fs, System.Windows.DataFormats.Rtf);
                MessageBox.Show("Fiche d'entrée créée !");
            }
        }

        private void boutonChiffreAffaire_Click(object sender, RoutedEventArgs e)
        {
            View.ChiffreAffaire fenetre = new View.ChiffreAffaire();
            fenetre.ShowDialog();
        }
    

        private void boutonReleveSemaine_Click(object sender, RoutedEventArgs e)
        {
            List<C_Entretien> entretiens = new G_Entretien(chaineConnexion).Lire("id");
            FlowDocument fdReleve = new FlowDocument();

            DateTime date = DateTime.Now.AddDays(-7);
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Relevé de la seamine "+date.ToString("dd/MM/yyyy"))));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new LineBreak());

            foreach (C_Entretien en in entretiens)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (Convert.ToDateTime(en.datePassage).Date == date.AddDays(i).Date)
                    {
                        C_Vehicule v = new G_Vehicule(chaineConnexion).Lire_ID(Convert.ToInt32(en.vehiculeId));
                        p.Inlines.Add("Le véhicule " + v.immatriculation + " est passé le "+ Convert.ToDateTime(en.datePassage).ToString("dd/MM/yyyy"));
                        p.Inlines.Add(new LineBreak());
                    }
                }
            }

            fdReleve.Blocks.Add(p);
            richTextBoxReleve.Document = fdReleve;
            FileStream fs = new FileStream(@"Releve"+ date.Day+"-"+date.Month+"-"+date.Year+".rtf", FileMode.Create);
            TextRange tr = new TextRange(richTextBoxReleve.Document.ContentStart, richTextBoxReleve.Document.ContentEnd);
            tr.Save(fs, System.Windows.DataFormats.Rtf);
            MessageBox.Show("Relevé de la seamine écoulée créée !");
        }
    }
}
