using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Projet_Garage.Classes;
using Projet_Garage.Gestion;
using System.Configuration;

namespace WpfApp_Garage.ViewModel
{
    class VM_Modele : BasePropriete
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

        private C_Modele _modeleSelectionnee;
        public C_Modele modeleSelectionnee
        {
            get { return _modeleSelectionnee; }
            set { AssignerChamp<C_Modele>(ref _modeleSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Données extérieures
        private VM_UnModele _unModele;
        public VM_UnModele unModele
        {
            get { return _unModele; }
            set { AssignerChamp<VM_UnModele>(ref _unModele, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Client> _bcpModeles = new ObservableCollection<C_Client>();
        public ObservableCollection<C_Client> bcpModeles
        {
            get { return _bcpModeles; }
            set { _bcpModeles = value; }
        }
        #endregion

        public class VM_UnModele : BasePropriete
        {
            private int _id, _cylindree, _puissance, _poids;
            private string _modele, _motorisation, _carburant;
            private float _consommation;

            public int id
            {
                get { return _id; }
                set { AssignerChamp<int>(ref _id, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string modele
            {
                get { return _modele; }
                set { AssignerChamp<string>(ref _modele, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string motorisation
            {
                get { return _motorisation; }
                set { AssignerChamp<string>(ref _motorisation, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string carburant
            {
                get { return _carburant; }
                set { AssignerChamp<string>(ref _carburant, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int cylindree
            {
                get { return _cylindree; }
                set { AssignerChamp<int>(ref _cylindree, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int puissance
            {
                get { return _puissance; }
                set { AssignerChamp<int>(ref _puissance, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public float consommation
            {
                get { return _consommation; }
                set { AssignerChamp<float>(ref _consommation, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int poids
            {
                get { return _poids; }
                set { AssignerChamp<int>(ref _poids, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

        }
    }
}
