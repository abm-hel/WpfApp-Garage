using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_Garage.Classes;
using Projet_Garage.Gestion;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Windows;
using static WpfApp_Garage.ViewModel.VM_Entretien;
using static WpfApp_Garage.ViewModel.VM_Intervention;
using static WpfApp_Garage.ViewModel.VM_Piece;

namespace WpfApp_Garage.ViewModel
{
    class VM_TableauBord : BasePropriete
    {
        #region Données Écran
        private string chaineConnexion = ConfigurationManager.ConnectionStrings["WpfApp_Garage.Properties.Settings.chaineConnexionBD"].ConnectionString;
        public BaseCommande RemplirEntretienIntervention { get; set; }
        public BaseCommande RemplirEntretienPiece { get; set; }
        public BaseCommande commandeSupprimerIntervention { get; set; }
        public BaseCommande commandeSupprimerPiece { get; set; }

        private VM_TableauBord _unTableauBord;
        public VM_TableauBord unTableauBord
        {
            get { return _unTableauBord; }
            set { AssignerChamp<VM_TableauBord>(ref _unTableauBord, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }


        private C_Intervention _InterventionSelectionnee;
        public C_Intervention InterventionSelectionnee
        {
            get { return _InterventionSelectionnee; }
            set { AssignerChamp<C_Intervention>(ref _InterventionSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private C_Entretien _EntretiennSelectionnee;
        public C_Entretien EntretiennSelectionnee
        {
            get { return _EntretiennSelectionnee; }
            set { AssignerChamp<C_Entretien>(ref _EntretiennSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private C_Piece _PieceSelectionnee;
        public C_Piece PieceSelectionnee
        {
            get { return _PieceSelectionnee; }
            set { AssignerChamp<C_Piece>(ref _PieceSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private C_Entretien_Intervention _Entretien_InterventionSelectionnee;
        public C_Entretien_Intervention Entretien_InterventionSelectionnee
        {
            get { return _Entretien_InterventionSelectionnee; }
            set { AssignerChamp<C_Entretien_Intervention>(ref _Entretien_InterventionSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private C_Entretien_Piece _Entretien_PieceSelectionnee;
        public C_Entretien_Piece Entretien_PieceSelectionnee
        {
            get { return _Entretien_PieceSelectionnee; }
            set { AssignerChamp<C_Entretien_Piece>(ref _Entretien_PieceSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }


        private VM_UnEntretien _UnEntretien;
        public VM_UnEntretien UnEntretien
        {
            get { return _UnEntretien; }
            set { AssignerChamp<VM_UnEntretien>(ref _UnEntretien, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

   

        private VM_UneIntervention _UneIntervention;
        public VM_UneIntervention UneIntervention
        {
            get { return _UneIntervention; }
            set { AssignerChamp<VM_UneIntervention>(ref _UneIntervention, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private VM_UnePiece _UnePiece;
        public VM_UnePiece UnePiece
        {
            get { return _UnePiece; }
            set { AssignerChamp<VM_UnePiece>(ref _UnePiece, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private VM_UnEntretien_Intervention _UnEntretien_Intervention;
        public VM_UnEntretien_Intervention UnEntretien_Intervention
        {
            get { return _UnEntretien_Intervention; }
            set { AssignerChamp<VM_UnEntretien_Intervention>(ref _UnEntretien_Intervention, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private VM_UnEntretien_Piece _UnEntretien_Piece;
        public VM_UnEntretien_Piece UnEntretien_Piece
        {
            get { return _UnEntretien_Piece; }
            set { AssignerChamp<VM_UnEntretien_Piece>(ref _UnEntretien_Piece, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion



        #region Données extérieures

        private ObservableCollection<C_Intervention> _bcpInterventions = new ObservableCollection<C_Intervention>();
        public ObservableCollection<C_Intervention> bcpInterventions
        {
            get { return _bcpInterventions; }
            set { _bcpInterventions = value; }
        }

        private ObservableCollection<C_TypeEntretien> _bcpTypeEntretiens = new ObservableCollection<C_TypeEntretien>();
        public ObservableCollection<C_TypeEntretien> bcpTypeEntretiens
        {
            get { return _bcpTypeEntretiens; }
            set { _bcpTypeEntretiens = value; }
        }

        private ObservableCollection<C_Entretien> _bcpEntretiens = new ObservableCollection<C_Entretien>();
        public ObservableCollection<C_Entretien> bcpEntretiens
        {
            get { return _bcpEntretiens; }
            set { _bcpEntretiens = value; }
        }

        private ObservableCollection<C_Piece> _bcpPieces = new ObservableCollection<C_Piece>();
        public ObservableCollection<C_Piece> bcpPieces
        {
            get { return _bcpPieces; }
            set { _bcpPieces = value; }
        }


        private ObservableCollection<C_Entretien_Intervention> _BcpEntretien_Interventions = new ObservableCollection<C_Entretien_Intervention>();
        public ObservableCollection<C_Entretien_Intervention> BcpEntretien_Interventions
        {
            get { return _BcpEntretien_Interventions; }
            set { _BcpEntretien_Interventions = value; }
        }


        private ObservableCollection<C_Entretien_Piece> _BcpEntretien_Pieces = new ObservableCollection<C_Entretien_Piece>();
        public ObservableCollection<C_Entretien_Piece> BcpEntretien_Pieces
        {
            get { return _BcpEntretien_Pieces; }
            set { _BcpEntretien_Pieces = value; }
        }

        #endregion


        public void EntretienSelectionnee2UnEntretien()
        {
            UnEntretien.id = EntretiennSelectionnee.id;
            UnEntretien.vehiculeId = EntretiennSelectionnee.vehiculeId;
            UnEntretien.datePassage = EntretiennSelectionnee.datePassage;
        }

        public void InterventionSelectionnee2UneIntervention()
        {
            UneIntervention.id = InterventionSelectionnee.id;
            UneIntervention.description = InterventionSelectionnee.description;
            UneIntervention.nombreHeures = InterventionSelectionnee.nombreHeures;
            UneIntervention.prixHeure = InterventionSelectionnee.prixHeure;
            UneIntervention.tva = InterventionSelectionnee.tva;
            UneIntervention.prixTotal = InterventionSelectionnee.prixTotal;
        }

        public void PieceSelectionnee2UnePiece()
        {
            UnePiece.id = PieceSelectionnee.id;
            UnePiece.nom = PieceSelectionnee.nom;
            UnePiece.fabricant = PieceSelectionnee.fabricant;
            UnePiece.prix = PieceSelectionnee.prix;
            UnePiece.tva = PieceSelectionnee.tva;
            UnePiece.quantite = PieceSelectionnee.quantite;
            
        }
        
        public void Entretien_InterventionSelectionnee2UneEntretien_Intervention()
        {
            UnEntretien_Intervention.id = Entretien_InterventionSelectionnee.id;
            UnEntretien_Intervention.interventionId = Entretien_InterventionSelectionnee.interventionId;
            UnEntretien_Intervention.entretienId = Entretien_InterventionSelectionnee.entretienId;
            UnEntretien_Intervention.prixHeure = Entretien_InterventionSelectionnee.prixHeure;
            UnEntretien_Intervention.prix = Entretien_InterventionSelectionnee.prix;
            UnEntretien_Intervention.tva = Entretien_InterventionSelectionnee.tva;
        }

        public void Entretien_PieceSelectionnee2UneEntretien_Piece()
        {
            UnEntretien_Piece.id = Entretien_PieceSelectionnee.id;
            UnEntretien_Piece.pieceId = Entretien_PieceSelectionnee.pieceId;
            UnEntretien_Piece.entretienId = Entretien_PieceSelectionnee.entretienId;
            UnEntretien_Piece.quantite = Entretien_PieceSelectionnee.quantite;
            UnEntretien_Piece.prix = Entretien_PieceSelectionnee.prix;
            UnEntretien_Piece.tva = Entretien_PieceSelectionnee.tva;
        }

        public VM_TableauBord()
        {
            UnEntretien = new VM_UnEntretien();
            UneIntervention = new VM_UneIntervention();
            UnEntretien_Intervention = new VM_UnEntretien_Intervention();
            UnEntretien_Piece = new VM_UnEntretien_Piece();
            bcpInterventions = ChargerInterventions(chaineConnexion);
            bcpEntretiens = ChargerEntretiens(chaineConnexion);
            bcpTypeEntretiens = ChargerTypeEntretiens(chaineConnexion);
            bcpPieces = ChargerPieces(chaineConnexion);
            BcpEntretien_Interventions = ChargerEntretienInterventions(chaineConnexion);
            BcpEntretien_Pieces = ChargerEntretienPieces(chaineConnexion);
            RemplirEntretienIntervention = new BaseCommande(EncoderEntretienIntervention);
            RemplirEntretienPiece = new BaseCommande(EncoderEntretienPiece);
            commandeSupprimerIntervention = new BaseCommande(SupprimerIntervention);
            commandeSupprimerPiece= new BaseCommande(SupprimerPiece);

        }

        private ObservableCollection<C_Intervention> ChargerInterventions(string chaineConnexion)
        {
            //ObservableCollection<C_Client> rep = new ObservableCollection<C_Client>();
            List<C_Intervention> lTmp = new G_Intervention(chaineConnexion).Lire("id");
            ObservableCollection<C_Intervention> c = new ObservableCollection<C_Intervention>();
            foreach (C_Intervention Tmp in lTmp)
                c.Add(Tmp);
            return c;
        }

        private ObservableCollection<C_Entretien> ChargerEntretiens(string chaineConnexion)
        {
            //ObservableCollection<C_Client> rep = new ObservableCollection<C_Client>();
            List<C_Entretien> lTmp = new G_Entretien(chaineConnexion).Lire("id");
            ObservableCollection<C_Entretien> c = new ObservableCollection<C_Entretien>();
            foreach (C_Entretien Tmp in lTmp)
                c.Add(Tmp);
            return c;
        }private ObservableCollection<C_TypeEntretien> ChargerTypeEntretiens(string chaineConnexion)
        {
            //ObservableCollection<C_Client> rep = new ObservableCollection<C_Client>();
            List<C_TypeEntretien> lTmp = new G_TypeEntretien(chaineConnexion).Lire("id");
            ObservableCollection<C_TypeEntretien> c = new ObservableCollection<C_TypeEntretien>();
            foreach (C_TypeEntretien Tmp in lTmp)
                c.Add(Tmp);
            return c;
        }

        private ObservableCollection<C_Piece> ChargerPieces(string chaineConnexion)
        {
            //ObservableCollection<C_Client> rep = new ObservableCollection<C_Client>();
            List<C_Piece> lTmp = new  G_Piece(chaineConnexion).Lire("id");
            ObservableCollection<C_Piece> c = new ObservableCollection<C_Piece>();
            foreach (C_Piece Tmp in lTmp)
                c.Add(Tmp);
            return c;
        }

        private ObservableCollection<C_Entretien_Intervention> ChargerEntretienInterventions(string chaineConnexion)
        {
            //ObservableCollection<C_Client> rep = new ObservableCollection<C_Client>();
            List<C_Entretien_Intervention> lTmp = new G_Entretien_Intervention(chaineConnexion).Lire("id");
            ObservableCollection<C_Entretien_Intervention> c = new ObservableCollection<C_Entretien_Intervention>();
            foreach (C_Entretien_Intervention Tmp in lTmp)
                c.Add(Tmp);
            return c;
        }

        private ObservableCollection<C_Entretien_Piece> ChargerEntretienPieces(string chaineConnexion)
        {
            //ObservableCollection<C_Client> rep = new ObservableCollection<C_Client>();
            List<C_Entretien_Piece> lTmp = new G_Entretien_Piece(chaineConnexion).Lire("id");
            ObservableCollection<C_Entretien_Piece> c = new ObservableCollection<C_Entretien_Piece>();
            foreach (C_Entretien_Piece Tmp in lTmp)
                c.Add(Tmp);
            return c;
        }

        public void EncoderEntretienIntervention()
        {
           new G_Entretien_Intervention(chaineConnexion).Ajouter(InterventionSelectionnee.id, EntretiennSelectionnee.id, InterventionSelectionnee.prixHeure,InterventionSelectionnee.prixTotal,InterventionSelectionnee.tva);
           BcpEntretien_Interventions.Add(new C_Entretien_Intervention(InterventionSelectionnee.id, EntretiennSelectionnee.id, InterventionSelectionnee.prixHeure, InterventionSelectionnee.prixTotal, InterventionSelectionnee.tva));
           MessageBox.Show("ok");
        }
        
        public void SupprimerIntervention()
        {
            if(Entretien_InterventionSelectionnee !=null)
            {
                new G_Entretien_Intervention(chaineConnexion).Lire_ID(Entretien_InterventionSelectionnee.id);
                BcpEntretien_Interventions.Remove(Entretien_InterventionSelectionnee);
            }
        }


        public void EncoderEntretienPiece()
        {
            new G_Entretien_Piece(chaineConnexion).Ajouter(PieceSelectionnee.id, EntretiennSelectionnee.id, UnEntretien_Piece.quantite, PieceSelectionnee.prix, PieceSelectionnee.tva);
            BcpEntretien_Pieces.Add(new C_Entretien_Piece(PieceSelectionnee.id, EntretiennSelectionnee.id, UnEntretien_Piece.quantite, PieceSelectionnee.prix, PieceSelectionnee.tva));
            MessageBox.Show("ok");
        }

        public void SupprimerPiece()
        {
            if (Entretien_PieceSelectionnee != null)
            {
                new G_Entretien_Piece(chaineConnexion).Lire_ID(Entretien_PieceSelectionnee.id);
                BcpEntretien_Pieces.Remove(Entretien_PieceSelectionnee);
            }
        }

        public class VM_UnEntretien_Intervention : BasePropriete
        {
            private int _id;
            private int? _interventionId;
            private int? _entretienId;
            private double? _prixHeure;
            private double? _prix;
            private double? _tva;

            public int id
            {
                get { return _id; }
                set { AssignerChamp<int>(ref _id, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public int? interventionId
            {
                get { return _interventionId; }
                set { AssignerChamp<int?>(ref _interventionId, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int? entretienId
            {
                get { return _entretienId; }
                set { AssignerChamp<int?>(ref _entretienId, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public double? prixHeure
            {
                get { return _prixHeure; }
                set { AssignerChamp<double?>(ref _prixHeure, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public double? prix
            {
                get { return _prix; }
                set { AssignerChamp<double?>(ref _prix, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public double? tva
            {
                get { return _tva; }
                set { AssignerChamp<double?>(ref _tva, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
        }

        public class VM_UnEntretien_Piece : BasePropriete
        {
            private int _id;
            private int? _pieceId;
            private int? _entretienId;
            private int? _quantite;
            private double? _prix;
            private double? _tva;

            public int id
            {
                get { return _id; }
                set { AssignerChamp<int>(ref _id, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public int? pieceId
            {
                get { return _pieceId; }
                set { AssignerChamp<int?>(ref _pieceId, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int? entretienId
            {
                get { return _entretienId; }
                set { AssignerChamp<int?>(ref _entretienId, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int? quantite
            {
                get { return _quantite; }
                set { AssignerChamp<int?>(ref _quantite, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public double? prix
            {
                get { return _prix; }
                set { AssignerChamp<double?>(ref _prix, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public double? tva
            {
                get { return _tva; }
                set { AssignerChamp<double?>(ref _tva, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
        }
    }
}
