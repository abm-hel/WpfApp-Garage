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
    /// Logique d'interaction pour Modeles.xaml
    /// </summary>
    public partial class Modeles : Window
    {
        private ViewModel.VM_Modele localModele;
        public Modeles()
        {
            InitializeComponent();
            localModele = new ViewModel.VM_Modele();
            DataContext = localModele;
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Titre de document")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Liste des Modèles encodées"));
            fd.Blocks.Add(p);
            List l = new List();

            foreach (C_Modele cp in localModele.bcpModeles)
            {
                Paragraph pl = new Paragraph(new Run(cp.modele + " (" + cp.motorisation + " )"));
                l.ListItems.Add(new ListItem(pl));
            }
            fd.Blocks.Add(l);
            richTextBoxDoc.Document = fd;
            FileStream fs = new FileStream(@"Modeles.rtf", FileMode.Create);
            TextRange tr = new TextRange(richTextBoxDoc.Document.ContentStart, richTextBoxDoc.Document.ContentEnd);
            tr.Save(fs, System.Windows.DataFormats.Rtf);
        }

        private void dataGridModeles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridModeles.SelectedIndex >= 0)
                localModele.ModeleSelectionnee2UnModele();
        }
    }
}
