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
        #endregion

        #region Données extérieures

        private ObservableCollection<C_Intervention> _bcpInterventions = new ObservableCollection<C_Intervention>();
        public ObservableCollection<C_Intervention> bcpInterventions
        {
            get { return _bcpInterventions; }
            set { _bcpInterventions = value; }
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

        public VM_TableauBord()
        {
            UnEntretien = new VM_UnEntretien();
            UneIntervention = new VM_UneIntervention();
            bcpInterventions = ChargerInterventions(chaineConnexion);
            bcpEntretiens = ChargerEntretiens(chaineConnexion);
            bcpPieces = ChargerPieces(chaineConnexion);
            BcpEntretien_Interventions = ChargerEntretienInterventions(chaineConnexion);
            RemplirEntretienIntervention = new BaseCommande(EncoderEntretienIntervention);
            
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

        public void EncoderEntretienIntervention()
        {
           new G_Entretien_Intervention(chaineConnexion).Ajouter(InterventionSelectionnee.id, EntretiennSelectionnee.id, InterventionSelectionnee.prixHeure,InterventionSelectionnee.prixTotal,InterventionSelectionnee.tva);
           BcpEntretien_Interventions.Add(new C_Entretien_Intervention(InterventionSelectionnee.id, EntretiennSelectionnee.id, InterventionSelectionnee.prixHeure, InterventionSelectionnee.prixTotal, InterventionSelectionnee.tva));
           MessageBox.Show("ok");
        }

        public void EncoderEntretienPiece()
        {
            //new G_Entretien_Piece(chaineConnexion).Ajouter(InterventionSelectionnee.id, EntretiennSelectionnee.id, InterventionSelectionnee.prixHeure, InterventionSelectionnee.prixTotal, InterventionSelectionnee.tva);
            //BcpEntretien_Interventions.Add(new G_Entretien_Piece(InterventionSelectionnee.id, EntretiennSelectionnee.id, InterventionSelectionnee.prixHeure, InterventionSelectionnee.prixTotal, InterventionSelectionnee.tva));
            //MessageBox.Show("ok");
        }
    }
}
