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
    class VM_Vehicule : BasePropriete
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

        private C_Vehicule _vehiculeSelectionnee;
        public C_Vehicule vehiculeSelectionnee
        {
            get { return _vehiculeSelectionnee; }
            set { AssignerChamp<C_Vehicule>(ref _vehiculeSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Données extérieures
        private VM_UnVehicule _unVehicule;
        public VM_UnVehicule unVehicule
        {
            get { return _unVehicule; }
            set { AssignerChamp<VM_UnVehicule>(ref _unVehicule, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private ObservableCollection<C_Vehicule> _bcpVehicules = new ObservableCollection<C_Vehicule>();
        public ObservableCollection<C_Vehicule> bcpVehicules
        {
            get { return _bcpVehicules; }
            set { _bcpVehicules = value; }
        }

        private ObservableCollection<int> _bcpClients = new ObservableCollection<int>();
        public ObservableCollection<int> bcpClients
        {
            get { return _bcpClients; }
            set { _bcpClients = value; }
        }

        private ObservableCollection<int> _bcpModeles = new ObservableCollection<int>();
        public ObservableCollection<int> bcpModeles
        {
            get { return _bcpModeles; }
            set { _bcpModeles = value; }
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

        public VM_Vehicule()
        {
            unVehicule = new VM_UnVehicule();
            bcpVehicules = ChargerVehicules(chaineConnexion);
            bcpClients = ChargerClients(chaineConnexion);
            bcpModeles = ChargerModeles(chaineConnexion);

            ActiverUneFiche = false;
            commandeConfirmer = new BaseCommande(Confirmer);
            commandeAnnuler = new BaseCommande(Annuler);
            commandeAjouter = new BaseCommande(Ajouter);
            commandeModifier = new BaseCommande(Modifier);
            commandeSupprimer = new BaseCommande(Supprimer);
            //commandeEssaiSelMult = new BaseCommande(EssaiSelMult);
        }

        private ObservableCollection<C_Vehicule> ChargerVehicules(string chaineConnexion)
        {
            ObservableCollection<C_Vehicule> rep = new ObservableCollection<C_Vehicule>();
            List<C_Vehicule> lTmp = new G_Vehicule(chaineConnexion).Lire("id");
            foreach (C_Vehicule Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }

        private ObservableCollection<int> ChargerClients(string chaineConnexion)
        {
            //ObservableCollection<C_Client> rep = new ObservableCollection<C_Client>();
            List<C_Client> lTmp = new G_Client(chaineConnexion).Lire("id");
            ObservableCollection<int> c  = new ObservableCollection<int>();
            foreach (C_Client Tmp in lTmp)
                c.Add(Tmp.id);
            return c;
        }

        private ObservableCollection<int> ChargerModeles(string chaineConnexion)
        {
            //ObservableCollection<C_Client> rep = new ObservableCollection<C_Client>();
            List<C_Modele> lTmp = new G_Modele(chaineConnexion).Lire("id");
            ObservableCollection<int> c = new ObservableCollection<int>();
            foreach (C_Modele Tmp in lTmp)
                c.Add(Tmp.id);
            return c;
        }

        public void Confirmer()
        {
            if (nAjout == -1)
            {
                unVehicule.id = new G_Vehicule(chaineConnexion).Ajouter(unVehicule.modeleId, unVehicule.clientId, unVehicule.immatriculation, unVehicule.datePremiereImmatriculation, unVehicule.couleur,unVehicule.kilometrage);
                bcpVehicules.Add(new C_Vehicule(unVehicule.modeleId, unVehicule.clientId, unVehicule.immatriculation, unVehicule.datePremiereImmatriculation, unVehicule.couleur , unVehicule.kilometrage));
            }

            else
            {
                new G_Vehicule(chaineConnexion).Modifier(unVehicule.id,unVehicule.modeleId, unVehicule.clientId, unVehicule.immatriculation, unVehicule.datePremiereImmatriculation, unVehicule.couleur, unVehicule.kilometrage);
                bcpVehicules[nAjout] = new C_Vehicule(unVehicule.modeleId, unVehicule.clientId, unVehicule.immatriculation, unVehicule.datePremiereImmatriculation, unVehicule.couleur, unVehicule.kilometrage);
            }
            ActiverUneFiche = false;
        }
        public void Annuler()
        {
            ActiverUneFiche = false;
        }

        public void Ajouter()
        {
            unVehicule = new VM_UnVehicule();
            nAjout = -1;
            ActiverUneFiche = true;
        }

        public void Modifier()
        {
            if (vehiculeSelectionnee != null)
            {
                C_Vehicule Tmp = new G_Vehicule(chaineConnexion).Lire_ID(unVehicule.id);
                unVehicule = new VM_UnVehicule();
                unVehicule.id = Tmp.id;
                unVehicule.modeleId = Tmp.modeleId;
                unVehicule.clientId = Tmp.clientId;
                unVehicule.immatriculation = Tmp.immatriculation;
                unVehicule.datePremiereImmatriculation =Tmp.datePremiereImmatriculation;
                unVehicule.couleur = Tmp.couleur;
                unVehicule.kilometrage = Tmp.kilometrage;
                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (vehiculeSelectionnee != null)
            {
                new G_Vehicule(chaineConnexion).Supprimer(vehiculeSelectionnee.id);
                bcpVehicules.Remove(vehiculeSelectionnee);
            }
        }

        public void VehiculeSelectionnee2UnVehicule()
        {
            unVehicule.id = vehiculeSelectionnee.id;
            unVehicule.modeleId = vehiculeSelectionnee.modeleId;
            unVehicule.clientId = vehiculeSelectionnee.clientId;
            unVehicule.immatriculation = vehiculeSelectionnee.immatriculation;
            unVehicule.datePremiereImmatriculation = vehiculeSelectionnee.datePremiereImmatriculation;
            unVehicule.couleur = vehiculeSelectionnee.couleur;
            unVehicule.kilometrage = vehiculeSelectionnee.kilometrage;
        }

        public class VM_UnVehicule : BasePropriete
        {
            private int _id;
            private int? _modeleId;
            private int? _clientId;
            private string _immatriculation;
            private DateTime? _datePremiereImmatriculation;
            private string _couleur;
            private Int64? _kilometrage;

            public int id
            {
                get { return _id; }
                set { AssignerChamp<int>(ref _id, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public int? modeleId
            {
                get { return _modeleId; }
                set { AssignerChamp<int?>(ref _modeleId, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int? clientId
            {
                get { return _clientId; }
                set { AssignerChamp<int?>(ref _clientId, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public string immatriculation
            {
                get { return _immatriculation; }
                set { AssignerChamp<string>(ref _immatriculation, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public DateTime? datePremiereImmatriculation
            {
                get { return _datePremiereImmatriculation; }
                set { AssignerChamp<DateTime?>(ref _datePremiereImmatriculation, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public string couleur
            {
                get { return _couleur; }
                set { AssignerChamp<string>(ref _couleur, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public Int64? kilometrage
            {
                get { return _kilometrage; }
                set { AssignerChamp<Int64?>(ref _kilometrage, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

        }
    }
}
