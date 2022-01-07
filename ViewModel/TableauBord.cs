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

namespace WpfApp_Garage.ViewModel
{
    class VM_TableauBord : BasePropriete
    {
        #region Données Écran
        private string chaineConnexion = ConfigurationManager.ConnectionStrings["WpfApp_Garage.Properties.Settings.chaineConnexionBD"].ConnectionString;

        private VM_TableauBord _unTableauBord;
        public VM_TableauBord unTableauBord
        {
            get { return _unTableauBord; }
            set { AssignerChamp<VM_TableauBord>(ref _unTableauBord, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        

        private C_Intervention _interventionSelectionnee;
        public C_Intervention interventionSelectionnee
        {
            get { return _interventionSelectionnee; }
            set { AssignerChamp<C_Intervention>(ref _interventionSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private C_Entretien _entretiennSelectionnee;
        public C_Entretien entretiennSelectionnee
        {
            get { return _entretiennSelectionnee; }
            set { AssignerChamp<C_Entretien>(ref _entretiennSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
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
        #endregion

        public VM_TableauBord()
        {
           
            bcpInterventions = ChargerInterventions(chaineConnexion);
            bcpEntretiens = ChargerEntretiens(chaineConnexion);
            bcpPieces = ChargerPieces(chaineConnexion);
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
    }
}
