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
        private VM_Client _unClient;
        public VM_Client unClient
        {
            get { return _unClient; }
            set { AssignerChamp<VM_Client>(ref _unClient, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
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

        public Client()
        {
            unClient = new VM_Client();
            unClient.id = 24;
            unClient.nom = "BEN MOUSSA";
            unClient.prenom = "Adil";
            unClient.dateNaissance = DateTime.Today;
            ActiverUneFiche = false;
        }

        private ObservableCollection<C_Client> ChargerClients(string chaineConnexion)
        {
            ObservableCollection<C_Client> rep = new ObservableCollection<C_Client>();
            List<C_Client> lTmp = new G_Client (chaineConnexion).Lire();
            foreach (C_Client Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }

        public void Confirmer()
        {
            if (nAjout == -1)
            {
                unClient.id = new G_Client(chaineConnexion).Ajouter(unClient.nom, unClient.prenom, unClient.dateNaissance, unClient.adresse, unClient.numeroTelephone, unClient.adresseEmail);
                bcpClients.Add(new C_Client(unClient.nom, unClient.prenom, unClient.dateNaissance, unClient.adresse, unClient.numeroTelephone, unClient.adresseEmail));
            }
            else
            {
                new G_Client(chaineConnexion).Modifier(unClient.id, unClient.nom, unClient.prenom, unClient.dateNaissance, unClient.adresse, unClient.numeroTelephone, unClient.adresseEmail);
                bcpClients[nAjout] = new C_Client(unClient.id, unClient.nom, unClient.prenom, unClient.dateNaissance, unClient.adresse, unClient.numeroTelephone, unClient.adresseEmail);
            }
            ActiverUneFiche = false;
        }

        public void Annuler()
        { 
            ActiverUneFiche = false;
        }

        public void Ajouter()
        {
            unClient = new VM_Client();
            nAjout = -1;
            ActiverUneFiche = true;
        }


        public class VM_Client : BasePropriete
        {
            private int _id;
            private string _nom, _prenom, _adresse, _numeroTelephone, _adresseEmail;
            private DateTime _dateNaissance;
            public int id
            {
                get { return _id; }
                set { AssignerChamp<int>(ref _id, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string prenom
            {
                get { return _prenom; }
                set { AssignerChamp<string>(ref _prenom, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string nom
            {
                get { return _nom; }
                set { AssignerChamp<string>(ref _nom, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public DateTime dateNaissance
            {
                get { return _dateNaissance; }
                set { AssignerChamp<DateTime>(ref _dateNaissance, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public string adresse
            {
                get { return _adresse; }
                set { AssignerChamp<string>(ref _adresse, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public string numeroTelephone
            {
                get { return _numeroTelephone; }
                set { AssignerChamp<string>(ref _numeroTelephone, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public string adresseEmail
            {
                get { return _adresseEmail; }
                set { AssignerChamp<string>(ref _adresseEmail, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

        }
    }
}
