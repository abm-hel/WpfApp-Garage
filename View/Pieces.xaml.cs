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
    /// Logique d'interaction pour Pieces.xaml
    /// </summary>
    public partial class Pieces : Window
    {
        private ViewModel.VM_Piece localPiece;
        public Pieces()
        {
            InitializeComponent();
            localPiece = new ViewModel.VM_Piece();
            DataContext = localPiece;
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Titre de document")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Liste des pièces encodées"));
            fd.Blocks.Add(p);
            List l = new List();
            foreach (C_Piece cp in localPiece.bcpPieces)
            {
                Paragraph pl = new Paragraph(new Run(cp.nom + " (" + cp.quantite
                  + " pièce(s) restante(s) )"));
                l.ListItems.Add(new ListItem(pl));
            }
            fd.Blocks.Add(l);
            richTextBoxDoc.Document = fd;
            FileStream fs = new FileStream(@"pieces.rtf", FileMode.Create);
            TextRange tr = new TextRange(richTextBoxDoc.Document.ContentStart, richTextBoxDoc.Document.ContentEnd);
            tr.Save(fs, System.Windows.DataFormats.Rtf);
        }

        private void dataGridPieces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridPieces.SelectedIndex >= 0)
                localPiece.PieceSelectionnee2UnePiece();
        }
    }
}
