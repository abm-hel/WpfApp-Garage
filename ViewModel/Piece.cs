using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_Garage.Classes;
using Projet_Garage.Gestion;
using System.Configuration;
using System.Collections.ObjectModel;

namespace WpfApp_Garage.ViewModel
{
    class VM_Piece : BasePropriete
    {
        #region Données Écran


        private string chaineConnexion = ConfigurationManager.ConnectionStrings["WpfApp_Garage.Properties.Settings.chaineConnexionBD"].ConnectionString;

        private int nAjout;
        private bool _ActiverUneFiche;
        public bool ActiverUneFiche
        {
            get { return _ActiverUneFiche; }
            set
            {
                AssignerChamp<bool>(ref _ActiverUneFiche, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ActiverBcpFiche = !ActiverUneFiche;
            }
        }

        private bool _ActiverBcpFiche;
        public bool ActiverBcpFiche
        {
            get { return _ActiverBcpFiche; }
            set { AssignerChamp<bool>(ref _ActiverBcpFiche, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private C_Piece _pieceSelectionnee;
        public C_Piece pieceSelectionnee
        {
            get { return _pieceSelectionnee; }
            set { AssignerChamp<C_Piece>(ref _pieceSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Données extérieures
        private VM_UnePiece _unePiece;
        public VM_UnePiece unePiece
        {
            get { return _unePiece; }
            set { AssignerChamp<VM_UnePiece>(ref _unePiece, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Piece> _bcpPieces = new ObservableCollection<C_Piece>();
        public ObservableCollection<C_Piece> bcpPieces
        {
            get { return _bcpPieces; }
            set { _bcpPieces = value; }
        }
        #endregion


        #region Commandes
        public BaseCommande commandeConfirmer { get; set; }
        public BaseCommande commandeAnnuler { get; set; }
        public BaseCommande commandeAjouter { get; set; }
        public BaseCommande commandeModifier { get; set; }
        public BaseCommande commandeSupprimer { get; set; }
        // public BaseCommande commandeEssaiSelMult { get; set; }
        #endregion

        public VM_Piece()
        {
            unePiece = new VM_UnePiece();

            bcpPieces = ChargerPieces(chaineConnexion);
            ActiverUneFiche = false;
            commandeConfirmer = new BaseCommande(Confirmer);
            commandeAnnuler = new BaseCommande(Annuler);
            commandeAjouter = new BaseCommande(Ajouter);
            commandeModifier = new BaseCommande(Modifier);
            commandeSupprimer = new BaseCommande(Supprimer);
            //commandeEssaiSelMult = new BaseCommande(EssaiSelMult);
        }

        private ObservableCollection<C_Piece> ChargerPieces(string chaineConnexion)
        {
            ObservableCollection<C_Piece> rep = new ObservableCollection<C_Piece>();
            List<C_Piece> lTmp = new G_Piece(chaineConnexion).Lire("id");
            foreach (C_Piece Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }

        public void Confirmer()
        {
            if (nAjout == -1)
            {
                unePiece.id = new G_Piece(chaineConnexion).Ajouter(unePiece.nom, unePiece.fabricant, unePiece.prix, unePiece.tva, unePiece.quantite);
                bcpPieces.Add(new C_Piece(unePiece.nom, unePiece.fabricant, unePiece.prix, unePiece.tva, unePiece.quantite));
            }
            else
            {
                new G_Piece(chaineConnexion).Modifier(unePiece.id, unePiece.nom, unePiece.fabricant, unePiece.prix, unePiece.tva, unePiece.quantite);
                bcpPieces[nAjout] = new C_Piece(unePiece.id, unePiece.nom, unePiece.fabricant, unePiece.prix, unePiece.tva, unePiece.quantite);
            }
            ActiverUneFiche = false;
        }

        public void Annuler()
        {
            ActiverUneFiche = false;
        }

        public void Ajouter()
        {
            unePiece = new VM_UnePiece();
            nAjout = -1;
            ActiverUneFiche = true;
        }

        public void Modifier()
        {
            if (pieceSelectionnee != null)
            {
                C_Piece Tmp = new G_Piece(chaineConnexion).Lire_ID(unePiece.id);
                unePiece = new VM_UnePiece();
                unePiece.id = Tmp.id;
                unePiece.nom = Tmp.nom;
                unePiece.fabricant = Tmp.fabricant;
                unePiece.prix = (double)Tmp.prix;
                unePiece.tva = (double)Tmp.tva;
                unePiece.quantite = (int)Tmp.quantite;
                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (pieceSelectionnee != null)
            {
                new G_Piece(chaineConnexion).Supprimer(pieceSelectionnee.id);
                bcpPieces.Remove(pieceSelectionnee);
            }
        }

        public void PieceSelectionnee2UnePiece()
        {
            unePiece.id = pieceSelectionnee.id;
            unePiece.nom = pieceSelectionnee.nom;
            unePiece.fabricant = pieceSelectionnee.fabricant;
            unePiece.prix = (double)pieceSelectionnee.prix;
            unePiece.tva = (double)pieceSelectionnee.tva;
            unePiece.quantite = (int)pieceSelectionnee.quantite;
        }


        public class VM_UnePiece : BasePropriete
        {
            private int _id, _quantite;
            private string _nom, _fabricant;
            private double _tva, _prix;

            public int id
            {
                get { return _id; }
                set { AssignerChamp<int>(ref _id, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string nom
            {
                get { return _nom; }
                set { AssignerChamp<string>(ref _nom, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public string fabricant
            {
                get { return _fabricant; }
                set { AssignerChamp<string>(ref _fabricant, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int quantite
            {
                get { return _quantite; }
                set { AssignerChamp<int>(ref _quantite, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public double prix
            {
                get { return _prix; }
                set { AssignerChamp<double>(ref _prix, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public double tva
            {
                get { return _tva; }
                set { AssignerChamp<double>(ref _tva, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
        }
    }
}
