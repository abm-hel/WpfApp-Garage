using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Projet_Garage.Model;

namespace WpfApp_Garage.ViewModel
{
    class Client : BasePropriete
    {
        #region Données Écran
        private string chaineConnexion;
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

        private C_Client _clientSelectionnee;
        public C_Client clientSelectionnee
        {
            get { return _clientSelectionnee; }
            set { AssignerChamp<C_Client>(ref _clientSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Données extérieures
        private Client _unClient;
        public Client unClient
        {
            get { return _unClient; }
            set { AssignerChamp<Client>(ref _unClient, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Client> _bcpClients = new ObservableCollection<C_Client>();
        public ObservableCollection<C_Client> bcpClients
        {
            get { return _bcpClients; }
            set { _bcpClients = value; }
        }
        #endregion

        #region Commandes
        public BaseCommande commandeConfirmer { get; set; }
        public BaseCommande commandeAnnuler { get; set; }
        public BaseCommande commandeAjouter { get; set; }
        public BaseCommande commandeModifier { get; set; }
        public BaseCommande commandeSupprimer { get; set; }
        public BaseCommande commandeEssaiSelMult { get; set; }
        #endregion
    }
}
