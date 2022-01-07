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
    class VM_Client : BasePropriete
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

        private C_Client _clientSelectionnee;
        public C_Client clientSelectionnee
        {
            get { return _clientSelectionnee; }
            set { AssignerChamp<C_Client>(ref _clientSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Données extérieures
        private VM_UnClient _unClient;
        public VM_UnClient unClient
        {
            get { return _unClient; }
            set { AssignerChamp<VM_UnClient>(ref _unClient, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
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
       // public BaseCommande commandeEssaiSelMult { get; set; }
        #endregion

        public VM_Client()
        {
            unClient = new VM_UnClient();
          
            bcpClients = ChargerClients(chaineConnexion);
            ActiverUneFiche = false;
            commandeConfirmer = new BaseCommande(Confirmer);
            commandeAnnuler = new BaseCommande(Annuler);
            commandeAjouter = new BaseCommande(Ajouter);
            commandeModifier = new BaseCommande(Modifier);
            commandeSupprimer = new BaseCommande(Supprimer);
            //commandeEssaiSelMult = new BaseCommande(EssaiSelMult);
        }

        private ObservableCollection<C_Client> ChargerClients(string chaineConnexion)
        {
            ObservableCollection<C_Client> rep = new ObservableCollection<C_Client>();
            List<C_Client> lTmp = new G_Client (chaineConnexion).Lire("id");
            foreach (C_Client Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }

        public void Confirmer()
        {
            if (nAjout == -1)
            {
                unClient.id = new G_Client(chaineConnexion).Ajouter(unClient.nom, unClient.prenom, (DateTime?)unClient.dateNaissance, unClient.adresse, unClient.numeroTelephone, unClient.adresseEmail);
                bcpClients.Add(new C_Client(unClient.id,unClient.nom, unClient.prenom, unClient.dateNaissance, unClient.adresse, unClient.numeroTelephone, unClient.adresseEmail));
            }
            else
            {
                new G_Client(chaineConnexion).Modifier(unClient.id, unClient.nom, unClient.prenom, (DateTime?)unClient.dateNaissance, unClient.adresse, unClient.numeroTelephone, unClient.adresseEmail);
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
            unClient = new VM_UnClient();
            nAjout = -1;
            ActiverUneFiche = true;     
        }

        public void Modifier()
        {
            if (clientSelectionnee != null)
            {
                C_Client Tmp = new G_Client(chaineConnexion).Lire_ID(unClient.id);
                unClient = new VM_UnClient();
                unClient.id = Tmp.id;
                unClient.prenom = Tmp.prenom;
                unClient.nom = Tmp.nom;
                unClient.dateNaissance = Tmp.dateNaissance;
                unClient.adresse = Tmp.adresse;
                unClient.numeroTelephone = Tmp.numeroTelephone;
                unClient.adresseEmail = Tmp.adresseEmail;
                nAjout = bcpClients.IndexOf(clientSelectionnee);
                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (clientSelectionnee != null)
            {
                new G_Client(chaineConnexion).Supprimer(clientSelectionnee.id);
                bcpClients.Remove(clientSelectionnee);
            }
        }

        public void ClientSelectionnee2UnClient()
        {
            unClient.id = clientSelectionnee.id;
            unClient.nom = clientSelectionnee.nom;
            unClient.prenom = clientSelectionnee.prenom;
            unClient.dateNaissance = clientSelectionnee.dateNaissance;
            unClient.adresse = clientSelectionnee.adresse;
            unClient.numeroTelephone = clientSelectionnee.numeroTelephone;
            unClient.adresseEmail = clientSelectionnee.adresseEmail;
        }

        public class VM_UnClient : BasePropriete
        {
            private int _id;
            private string _nom;
            private string _prenom;
            private DateTime? _dateNaissance;
            private string _adresse;
            private string _numeroTelephone;
            private string _adresseEmail;
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
            public DateTime? dateNaissance
            {
                get { return _dateNaissance; }
                set { AssignerChamp<DateTime?>(ref _dateNaissance, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
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
