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
    class VM_Entretien : BasePropriete
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

        private C_Entretien _entretienSelectionnee;
        public C_Entretien entretienSelectionnee
        {
            get { return _entretienSelectionnee; }
            set { AssignerChamp<C_Entretien>(ref _entretienSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Données extérieures
        private VM_UnEntretien _unEntretien;
        public VM_UnEntretien unEntretien
        {
            get { return _unEntretien; }
            set { AssignerChamp<VM_UnEntretien>(ref _unEntretien, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private ObservableCollection<C_Vehicule> _bcpVehicules = new ObservableCollection<C_Vehicule>();
        public ObservableCollection<C_Vehicule> bcpVehicules
        {
            get { return _bcpVehicules; }
            set { _bcpVehicules = value; }
        }

        private ObservableCollection<C_Entretien> _bcpEntretiens = new ObservableCollection<C_Entretien>();
        public ObservableCollection<C_Entretien> bcpEntretiens
        {
            get { return _bcpEntretiens; }
            set { _bcpEntretiens = value; }
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

        public VM_Entretien()
        {
            unEntretien = new VM_UnEntretien();
            bcpVehicules = ChargerVehicules(chaineConnexion);
            bcpEntretiens = ChargerEntretiens(chaineConnexion);
            

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

        private ObservableCollection<C_Entretien> ChargerEntretiens(string chaineConnexion)
        {
            //ObservableCollection<C_Client> rep = new ObservableCollection<C_Client>();
            List<C_Entretien> lTmp = new G_Entretien(chaineConnexion).Lire("id");
            ObservableCollection<C_Entretien> c = new ObservableCollection<C_Entretien>();
            foreach (C_Entretien Tmp in lTmp)
                c.Add(Tmp);
            return c;
        }

        public void Confirmer()
        {
            if (nAjout == -1)
            {

                unEntretien.id = new G_Entretien(chaineConnexion).Ajouter(unEntretien.vehiculeId, unEntretien.datePassage);
                bcpEntretiens.Add(new C_Entretien(unEntretien.id, unEntretien.vehiculeId, unEntretien.datePassage));
            }

            else
            {
                new G_Entretien(chaineConnexion).Modifier(unEntretien.id, unEntretien.vehiculeId, unEntretien.datePassage);
                bcpEntretiens[nAjout] = new C_Entretien(unEntretien.id, unEntretien.vehiculeId, unEntretien.datePassage);
            }
            ActiverUneFiche = false;
        }
        public void Annuler()
        {
            ActiverUneFiche = false;
        }

        public void Ajouter()
        {
            unEntretien = new VM_UnEntretien();
            nAjout = -1;
            ActiverUneFiche = true;
        }

        public void Modifier()
        {
            if (entretienSelectionnee != null)
            {
                C_Entretien Tmp = new G_Entretien(chaineConnexion).Lire_ID(unEntretien.id);
                unEntretien = new VM_UnEntretien();
                unEntretien.id = Tmp.id;
                unEntretien.vehiculeId = Tmp.vehiculeId;
                unEntretien.datePassage = Tmp.datePassage;
                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (entretienSelectionnee != null)
            {
                new G_Entretien(chaineConnexion).Supprimer(entretienSelectionnee.id);
                bcpEntretiens.Remove(entretienSelectionnee);
            }
        }

        public void EntretienSelectionnee2UnEntretien()
        {
            unEntretien.id = entretienSelectionnee.id;
            unEntretien.vehiculeId = entretienSelectionnee.vehiculeId;
            unEntretien.datePassage = entretienSelectionnee.datePassage;
        }

        public class VM_UnEntretien : BasePropriete
        {
            private int _id;
            private int? _vehiculeId;
            private DateTime? _datePassage;

            public int id
            {
                get { return _id; }
                set { AssignerChamp<int>(ref _id, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public int? vehiculeId
            {
                get { return _vehiculeId; }
                set { AssignerChamp<int?>(ref _vehiculeId, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public DateTime? datePassage
            {
                get { return _datePassage; }
                set { AssignerChamp<DateTime?>(ref _datePassage, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
        }
    }
}
