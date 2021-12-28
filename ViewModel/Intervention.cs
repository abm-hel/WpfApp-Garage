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
    class VM_Intervention : BasePropriete
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

        private C_Intervention _interventionSelectionnee;
        public C_Intervention interventionSelectionnee
        {
            get { return _interventionSelectionnee; }
            set { AssignerChamp<C_Intervention>(ref _interventionSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Données extérieures
        private VM_UneIntervention _uneIntervention;
        public VM_UneIntervention uneIntervention
        {
            get { return _uneIntervention; }
            set { AssignerChamp<VM_UneIntervention>(ref _uneIntervention, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Intervention> _bcpInterventions = new ObservableCollection<C_Intervention>();
        public ObservableCollection<C_Intervention> bcpInterventions
        {
            get { return _bcpInterventions; }
            set { _bcpInterventions = value; }
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

        public VM_Intervention()
        {
            uneIntervention = new VM_UneIntervention();

            bcpInterventions = ChargerInterventions(chaineConnexion);
            ActiverUneFiche = false;
            commandeConfirmer = new BaseCommande(Confirmer);
            commandeAnnuler = new BaseCommande(Annuler);
            commandeAjouter = new BaseCommande(Ajouter);
            commandeModifier = new BaseCommande(Modifier);
            commandeSupprimer = new BaseCommande(Supprimer);
            //commandeEssaiSelMult = new BaseCommande(EssaiSelMult);
        }

        private ObservableCollection<C_Intervention> ChargerInterventions(string chaineConnexion)
        {
            ObservableCollection<C_Intervention> rep = new ObservableCollection<C_Intervention>();
            List<C_Intervention> lTmp = new G_Intervention(chaineConnexion).Lire("id");
            foreach (C_Intervention Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }

        public void Confirmer()
        {
            if (nAjout == -1)
            {
                uneIntervention.id = new G_Intervention(chaineConnexion).Ajouter(uneIntervention.description, uneIntervention.nombreHeures, uneIntervention.prixHeure, uneIntervention.tva, uneIntervention.prixTotal);
                bcpInterventions.Add(new C_Intervention(uneIntervention.description, uneIntervention.nombreHeures, uneIntervention.prixHeure, uneIntervention.tva, uneIntervention.prixTotal));
            }
            else
            {
                new G_Intervention(chaineConnexion).Modifier(uneIntervention.id, uneIntervention.description, uneIntervention.nombreHeures, uneIntervention.prixHeure, uneIntervention.tva, uneIntervention.prixTotal);
                bcpInterventions[nAjout] = new C_Intervention(uneIntervention.id, uneIntervention.description, uneIntervention.nombreHeures, uneIntervention.prixHeure, uneIntervention.tva, uneIntervention.prixTotal);
            }
            ActiverUneFiche = false;
        }
        public void Annuler()
        {
            ActiverUneFiche = false;
        }

        public void Ajouter()
        {
            uneIntervention = new VM_UneIntervention();
            nAjout = -1;
            ActiverUneFiche = true;
        }

        public void Modifier()
        {
            if (interventionSelectionnee != null)
            {
                C_Intervention Tmp = new G_Intervention(chaineConnexion).Lire_ID(uneIntervention.id);
                uneIntervention = new VM_UneIntervention();
                uneIntervention.id = Tmp.id;
                uneIntervention.description = Tmp.description;
                uneIntervention.nombreHeures = (int)Tmp.nombreHeures;
                uneIntervention.prixHeure = (double)Tmp.prixHeure;
                uneIntervention.tva = (double)Tmp.tva;
                uneIntervention.prixTotal = (double)Tmp.prixTotal;
                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (interventionSelectionnee != null)
            {
                new G_Intervention(chaineConnexion).Supprimer(interventionSelectionnee.id);
                bcpInterventions.Remove(interventionSelectionnee);
            }
        }

        public void InterventionSelectionnee2UneIntervention()
        {
            uneIntervention.id = interventionSelectionnee.id;
            uneIntervention.description = interventionSelectionnee.description;
            uneIntervention.nombreHeures = (int)interventionSelectionnee.nombreHeures;
            uneIntervention.prixHeure = (double)interventionSelectionnee.prixHeure;
            uneIntervention.tva = (double)interventionSelectionnee.tva;
            uneIntervention.prixTotal = (double)interventionSelectionnee.prixTotal;
        }

        public class VM_UneIntervention : BasePropriete
        {
            private int _id, _nombreHeures;
            private string _description;
            private double _tva, _prixTotal, _prixHeure;

            public int id
            {
                get { return _id; }
                set { AssignerChamp<int>(ref _id, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string description
            {
                get { return _description; }
                set { AssignerChamp<string>(ref _description, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int nombreHeures
            {
                get { return _nombreHeures; }
                set { AssignerChamp<int>(ref _nombreHeures, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public double prixHeure
            {
                get { return _prixHeure; }
                set { AssignerChamp<double>(ref _prixHeure, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public double tva
            {
                get { return _tva; }
                set { AssignerChamp<double>(ref _tva, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public double prixTotal
            {
                get { return _prixTotal; }
                set { AssignerChamp<double>(ref _prixTotal, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
        }
    }
}
