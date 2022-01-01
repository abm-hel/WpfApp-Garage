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
    class VM_TypeEntretien : BasePropriete
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

        private C_TypeEntretien _typeEntretienSelectionnee;
        public C_TypeEntretien typeEntretienSelectionnee
        {
            get { return _typeEntretienSelectionnee; }
            set { AssignerChamp<C_TypeEntretien>(ref _typeEntretienSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Données extérieures
        private VM_UnTypeEntretien _unTypeEntretien;
        public VM_UnTypeEntretien unTypeEntretien
        {
            get { return _unTypeEntretien; }
            set { AssignerChamp<VM_UnTypeEntretien>(ref _unTypeEntretien, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_TypeEntretien> _bcpTypeEntretiens = new ObservableCollection<C_TypeEntretien>();
        public ObservableCollection<C_TypeEntretien> bcpTypeEntretiens
        {
            get { return _bcpTypeEntretiens; }
            set { _bcpTypeEntretiens = value; }
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

        public VM_TypeEntretien()
        {
            unTypeEntretien = new VM_UnTypeEntretien();

            bcpTypeEntretiens = ChargerTypeEntretiens(chaineConnexion);
            ActiverUneFiche = false;
            commandeConfirmer = new BaseCommande(Confirmer);
            commandeAnnuler = new BaseCommande(Annuler);
            commandeAjouter = new BaseCommande(Ajouter);
            commandeModifier = new BaseCommande(Modifier);
            commandeSupprimer = new BaseCommande(Supprimer);
            //commandeEssaiSelMult = new BaseCommande(EssaiSelMult);
        }


        private ObservableCollection<C_TypeEntretien> ChargerTypeEntretiens(string chaineConnexion)
        {
            ObservableCollection<C_TypeEntretien> rep = new ObservableCollection<C_TypeEntretien>();
            List<C_TypeEntretien> lTmp = new G_TypeEntretien(chaineConnexion).Lire("id");
            foreach (C_TypeEntretien Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }

        public void Confirmer()
        {
            if (nAjout == -1)
            {
                unTypeEntretien.id = new G_TypeEntretien(chaineConnexion).Ajouter(unTypeEntretien.nom, unTypeEntretien.kilometrage);
                bcpTypeEntretiens.Add(new C_TypeEntretien(unTypeEntretien.id,unTypeEntretien.nom, unTypeEntretien.kilometrage));
            }
            else
            {
                new G_TypeEntretien(chaineConnexion).Modifier(unTypeEntretien.id, unTypeEntretien.nom, unTypeEntretien.kilometrage);
                bcpTypeEntretiens[nAjout] = new C_TypeEntretien(unTypeEntretien.id, unTypeEntretien.nom, unTypeEntretien.kilometrage);
            }
            ActiverUneFiche = false;
        }
        public void Annuler()
        {
            ActiverUneFiche = false;
        }

        public void Ajouter()
        {
            unTypeEntretien = new VM_UnTypeEntretien();
            nAjout = -1;
            ActiverUneFiche = true;
        }

        public void Modifier()
        {
            if (typeEntretienSelectionnee != null)
            {
                C_TypeEntretien Tmp = new G_TypeEntretien(chaineConnexion).Lire_ID(unTypeEntretien.id);
                unTypeEntretien = new VM_UnTypeEntretien();
                unTypeEntretien.id = Tmp.id;
                unTypeEntretien.nom = Tmp.nom;
                unTypeEntretien.kilometrage = Tmp.kilometrage;
                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (typeEntretienSelectionnee != null)
            {
                new G_Intervention(chaineConnexion).Supprimer(typeEntretienSelectionnee.id);
                bcpTypeEntretiens.Remove(typeEntretienSelectionnee);
            }
        }

        public void typeEntretienSelectionnee2UnTypeEntretien()
        {
            unTypeEntretien.id = typeEntretienSelectionnee.id;
            unTypeEntretien.nom = typeEntretienSelectionnee.nom;
            unTypeEntretien.kilometrage = typeEntretienSelectionnee.kilometrage;
        }

        public class VM_UnTypeEntretien : BasePropriete
        {
            private int _id;
            private string _nom;
            private Int64 _kilometrage;

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

            public Int64 kilometrage
            {
                get { return _kilometrage; }
                set { AssignerChamp<Int64>(ref _kilometrage, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
        }
    }
}
