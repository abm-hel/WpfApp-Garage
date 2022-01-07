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
        }

        private void dataGridPieces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridPieces.SelectedIndex >= 0)
                localPiece.PieceSelectionnee2UnePiece();
        }
    }
}
