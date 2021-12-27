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
        private ObservableCollection<C_Modele> _bcpModeles = new ObservableCollection<C_Modele>();
        public ObservableCollection<C_Modele> bcpModeles
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

        public VM_Modele()
        {
            unModele = new VM_UnModele();

            bcpModeles = ChargerModeles(chaineConnexion);
            ActiverUneFiche = false;
            commandeConfirmer = new BaseCommande(Confirmer);
            commandeAnnuler = new BaseCommande(Annuler);
            commandeAjouter = new BaseCommande(Ajouter);
            commandeModifier = new BaseCommande(Modifier);
            commandeSupprimer = new BaseCommande(Supprimer);
            //commandeEssaiSelMult = new BaseCommande(EssaiSelMult);
        }

        public void Confirmer()
        {
            if (nAjout == -1)
            {
                unModele.id = new G_Modele(chaineConnexion).Ajouter(unModele.modele, unModele.motorisation, unModele.carburant, unModele.cylindree, unModele.puissance, unModele.consommation, unModele.poids);
                bcpModeles.Add(new C_Modele(unModele.modele, unModele.motorisation, unModele.carburant, unModele.cylindree, unModele.puissance, unModele.consommation, unModele.poids));
            }
            else
            {
                new G_Modele(chaineConnexion).Modifier(unModele.id, unModele.modele, unModele.motorisation, unModele.carburant, unModele.cylindree, unModele.puissance, unModele.consommation, unModele.poids);
                bcpModeles[nAjout] = new C_Modele(unModele.id, unModele.modele, unModele.motorisation, unModele.carburant, unModele.cylindree, unModele.puissance, unModele.consommation, unModele.poids);
            }
            ActiverUneFiche = false;
        }

        public void Annuler()
        {
            ActiverUneFiche = false;
        }

        public void Ajouter()
        {
            unModele = new VM_UnModele();
            nAjout = -1;
            ActiverUneFiche = true;
        }

        public void Modifier()
        {
            if (modeleSelectionnee != null)
            {
                C_Modele Tmp = new G_Modele(chaineConnexion).Lire_ID(unModele.id);
                unModele = new VM_UnModele();
                unModele.id = Tmp.id;
                unModele.modele = Tmp.modele;
                unModele.motorisation = Tmp.motorisation;
                unModele.carburant = Tmp.carburant;
                unModele.cylindree = (int)Tmp.cylindree;
                unModele.puissance = (int)Tmp.puissance;
                unModele.consommation = (float)Tmp.consommation;
                unModele.poids = (int)Tmp.poids;
                nAjout = bcpModeles.IndexOf(modeleSelectionnee);
                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (modeleSelectionnee != null)
            {
                new G_Client(chaineConnexion).Supprimer(modeleSelectionnee.id);
                bcpModeles.Remove(modeleSelectionnee);
            }
        }

        private ObservableCollection<C_Modele> ChargerModeles(string chaineConnexion)
        {
            ObservableCollection<C_Modele> rep = new ObservableCollection<C_Modele>();
            List<C_Modele> lTmp = new G_Modele(chaineConnexion).Lire("id");
            foreach (C_Modele Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }

        public void ModeleSelectionnee2UnModele()
        {
            unModele.id = modeleSelectionnee.id;
            unModele.modele = modeleSelectionnee.modele;
            unModele.motorisation = modeleSelectionnee.motorisation;
            unModele.carburant = modeleSelectionnee.carburant;
            unModele.cylindree = (int)modeleSelectionnee.cylindree;
            unModele.puissance = (int)modeleSelectionnee.puissance;
            unModele.consommation = (float)modeleSelectionnee.consommation;
            unModele.poids = (int) modeleSelectionnee.poids;
        }

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
