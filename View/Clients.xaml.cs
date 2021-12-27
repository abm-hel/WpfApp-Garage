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
using WpfApp_Garage;

namespace WpfApp_Garage.View
{
    /// <summary>
    /// Logique d'interaction pour Clients.xaml
    /// </summary>
    public partial class Clients : Window
    {

        private ViewModel.VM_Client localClient;
        public Clients()
        {
            InitializeComponent();
            localClient = new ViewModel.VM_Client();
            DataContext = localClient;
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Titre de document")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Liste des clients encodées"));
            fd.Blocks.Add(p);
            List l = new List();
            foreach (C_Client cp in localClient.bcpClients)
            {
                Paragraph pl = new Paragraph(new Run(cp.prenom + " " + cp.nom
                 + " (" + cp.dateNaissance + ")"));
                l.ListItems.Add(new ListItem(pl));
            }
            fd.Blocks.Add(l);
            richTextBoxDoc.Document = fd;
            FileStream fs = new FileStream(@"clients.rtf", FileMode.Create);
            TextRange tr = new TextRange(richTextBoxDoc.Document.ContentStart, richTextBoxDoc.Document.ContentEnd);
            tr.Save(fs, System.Windows.DataFormats.Rtf);
        }

        private void dataGridPersonnes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridClients.SelectedIndex >= 0)
                localClient.ClientSelectionnee2UnClient();
        }

        private void buttonAjouter_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
