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

        private bool _ActiverUneFiche2;
        public bool ActiverUneFiche2
        {
            get { return _ActiverUneFiche2; }
            set
            {
                AssignerChamp<bool>(ref _ActiverUneFiche2, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ActiverBcpFiche2 = !ActiverUneFiche2;
            }
        }

        private bool _ActiverUneFiche3;
        public bool ActiverUneFiche3
        {
            get { return _ActiverUneFiche3; }
            set
            {
                AssignerChamp<bool>(ref _ActiverUneFiche3, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ActiverBcpFiche3 = !ActiverUneFiche3;
            }
        }

        private bool _ActiverBcpFiche;
        public bool ActiverBcpFiche
        {
            get { return _ActiverBcpFiche; }
            set { AssignerChamp<bool>(ref _ActiverBcpFiche, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private bool _ActiverBcpFiche2;
        public bool ActiverBcpFiche2
        {
            get { return _ActiverBcpFiche2; }
            set { AssignerChamp<bool>(ref _ActiverBcpFiche2, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private bool _ActiverBcpFiche3;
        public bool ActiverBcpFiche3
        {
            get { return _ActiverBcpFiche3; }
            set { AssignerChamp<bool>(ref _ActiverBcpFiche3, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private C_TypeEntretien _typeEntretienSelectionnee;
        public C_TypeEntretien typeEntretienSelectionnee
        {
            get { return _typeEntretienSelectionnee; }
            set { AssignerChamp<C_TypeEntretien>(ref _typeEntretienSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private C_TypeEntretien_Intervention _typeEntretienSelectionnee_intervention;
        public C_TypeEntretien_Intervention typeEntretienSelectionnee_intervention
        {
            get { return _typeEntretienSelectionnee_intervention; }
            set { AssignerChamp<C_TypeEntretien_Intervention>(ref _typeEntretienSelectionnee_intervention, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private C_TypeEntretien_Piece _typeEntretienSelectionnee_piece;
        public C_TypeEntretien_Piece typeEntretienSelectionnee_piece
        {
            get { return _typeEntretienSelectionnee_piece; }
            set { AssignerChamp<C_TypeEntretien_Piece>(ref _typeEntretienSelectionnee_piece, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Données extérieures
        private VM_UnTypeEntretien _unTypeEntretien;
        public VM_UnTypeEntretien unTypeEntretien
        {
            get { return _unTypeEntretien; }
            set { AssignerChamp<VM_UnTypeEntretien>(ref _unTypeEntretien, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private VM_UnTypeEntretien_intervention _unTypeEntretien_intervention;
        public VM_UnTypeEntretien_intervention unTypeEntretien_intervention
        {
            get { return _unTypeEntretien_intervention; }
            set { AssignerChamp<VM_UnTypeEntretien_intervention>(ref _unTypeEntretien_intervention, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private VM_UnTypeEntretien_piece _unTypeEntretien_piece;
        public VM_UnTypeEntretien_piece unTypeEntretien_piece
        {
            get { return _unTypeEntretien_piece; }
            set { AssignerChamp<VM_UnTypeEntretien_piece>(ref _unTypeEntretien_piece, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private ObservableCollection<C_TypeEntretien> _bcpTypeEntretiens = new ObservableCollection<C_TypeEntretien>();
        public ObservableCollection<C_TypeEntretien> bcpTypeEntretiens
        {
            get { return _bcpTypeEntretiens; }
            set { _bcpTypeEntretiens = value; }
        }

        private ObservableCollection<C_TypeEntretien_Intervention> _bcpTypeEntretiens_intervetions = new ObservableCollection<C_TypeEntretien_Intervention>();
        public ObservableCollection<C_TypeEntretien_Intervention> bcpTypeEntretiens_interventions
        {
            get { return _bcpTypeEntretiens_intervetions; }
            set { _bcpTypeEntretiens_intervetions = value; }
        }

        private ObservableCollection<C_TypeEntretien_Piece> _bcpTypeEntretiens_pieces = new ObservableCollection<C_TypeEntretien_Piece>();
        public ObservableCollection<C_TypeEntretien_Piece> bcpTypeEntretiens_pieces
        {
            get { return _bcpTypeEntretiens_pieces; }
            set { _bcpTypeEntretiens_pieces = value; }
        }

        private ObservableCollection<C_Intervention> _bcpInterventions = new ObservableCollection<C_Intervention>();
        public ObservableCollection<C_Intervention> bcpInterventions
        {
            get { return _bcpInterventions; }
            set { _bcpInterventions = value; }
        }

        private ObservableCollection<C_Piece> _bcpPieces = new ObservableCollection<C_Piece>();
        public ObservableCollection<C_Piece> bcpPieces
        {
            get { return _bcpPieces; }
            set { _bcpPieces = value; }
        }
        #endregion

        #region Commandes
        public BaseCommande commandeConfirmer { get; set; }
        public BaseCommande commandeAnnuler { get; set; }
        public BaseCommande commandeAjouter { get; set; }
        public BaseCommande commandeModifier { get; set; }
        public BaseCommande commandeSupprimer { get; set; }

        public BaseCommande commandeConfirmerTypeEntretien_Intervention { get; set; }
        public BaseCommande commandeAnnulerTypeEntretien_Intervention { get; set; }
        public BaseCommande commandeAjouterTypeEntretien_Intervention { get; set; }
        public BaseCommande commandeModifierTypeEntretien_Intervention { get; set; }
        public BaseCommande commandeSupprimerTypeEntretien_Intervention { get; set; }

        public BaseCommande commandeConfirmerTypeEntretien_Piece { get; set; }
        public BaseCommande commandeAnnulerTypeEntretien_Piece { get; set; }
        public BaseCommande commandeAjouterTypeEntretien_Piece { get; set; }
        public BaseCommande commandeModifierTypeEntretien_Piece { get; set; }
        public BaseCommande commandeSupprimerTypeEntretien_Piece { get; set; }

        #endregion

        public VM_TypeEntretien()
        {
            unTypeEntretien = new VM_UnTypeEntretien();
            unTypeEntretien_intervention = new VM_UnTypeEntretien_intervention();
            unTypeEntretien_piece = new VM_UnTypeEntretien_piece();

            bcpTypeEntretiens = ChargerTypeEntretiens(chaineConnexion);
            bcpPieces = ChargerPieces(chaineConnexion);
            bcpInterventions = ChargerInterventions(chaineConnexion);
            bcpTypeEntretiens_interventions = ChargerTypeEntretien_Interventions(chaineConnexion);
            bcpTypeEntretiens_pieces = ChargerTypeEntretien_Pieces(chaineConnexion);

            ActiverUneFiche = false;
            ActiverUneFiche2 = false;
            ActiverUneFiche3 = false;

            commandeConfirmer = new BaseCommande(Confirmer);
            commandeAnnuler = new BaseCommande(Annuler);
            commandeAjouter = new BaseCommande(Ajouter);
            commandeModifier = new BaseCommande(Modifier);
            commandeSupprimer = new BaseCommande(Supprimer);

            commandeConfirmerTypeEntretien_Intervention = new BaseCommande(ConfirmerTypeEntretien_Intervention);
            commandeAnnulerTypeEntretien_Intervention = new BaseCommande(AnnulerTypeEntretien_Intervention);
            commandeAjouterTypeEntretien_Intervention= new BaseCommande(AjouterTypeEntretien_Intervention);
            commandeModifierTypeEntretien_Intervention = new BaseCommande(ModifierTypeEntretien_Intervention);
            commandeSupprimerTypeEntretien_Intervention= new BaseCommande(SupprimerTypeEntretien_Intervention);

            commandeConfirmerTypeEntretien_Piece = new BaseCommande(ConfirmerTypeEntretien_Piece);
            commandeAnnulerTypeEntretien_Piece = new BaseCommande(AnnulerTypeEntretien_Piece);
            commandeAjouterTypeEntretien_Piece = new BaseCommande(AjouterTypeEntretien_Piece);
            commandeModifierTypeEntretien_Piece = new BaseCommande(ModifierTypeEntretien_Piece);
            commandeSupprimerTypeEntretien_Piece = new BaseCommande(SupprimerTypeEntretien_Piece);

        }



        private ObservableCollection<C_TypeEntretien> ChargerTypeEntretiens(string chaineConnexion)
        {
            ObservableCollection<C_TypeEntretien> rep = new ObservableCollection<C_TypeEntretien>();
            List<C_TypeEntretien> lTmp = new G_TypeEntretien(chaineConnexion).Lire("id");
            foreach (C_TypeEntretien Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
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

        private ObservableCollection<C_Piece> ChargerPieces(string chaineConnexion)
        {
            //ObservableCollection<C_Client> rep = new ObservableCollection<C_Client>();
            List<C_Piece> lTmp = new G_Piece(chaineConnexion).Lire("id");
            ObservableCollection<C_Piece> c = new ObservableCollection<C_Piece>();
            foreach (C_Piece Tmp in lTmp)
                c.Add(Tmp);
            return c;
        }

        private ObservableCollection<C_TypeEntretien_Intervention> ChargerTypeEntretien_Interventions(string chaineConnexion)
        {
            //ObservableCollection<C_Client> rep = new ObservableCollection<C_Client>();
            List<C_TypeEntretien_Intervention> lTmp = new G_TypeEntretien_Intervention(chaineConnexion).Lire("id");
            ObservableCollection<C_TypeEntretien_Intervention> c = new ObservableCollection<C_TypeEntretien_Intervention>();
            foreach (C_TypeEntretien_Intervention Tmp in lTmp)
                c.Add(Tmp);
            return c;
        }

        private ObservableCollection<C_TypeEntretien_Piece> ChargerTypeEntretien_Pieces(string chaineConnexion)
        {
            //ObservableCollection<C_Client> rep = new ObservableCollection<C_Client>();
            List<C_TypeEntretien_Piece> lTmp = new G_TypeEntretien_Piece(chaineConnexion).Lire("id");
            ObservableCollection<C_TypeEntretien_Piece> c = new ObservableCollection<C_TypeEntretien_Piece>();
            foreach (C_TypeEntretien_Piece Tmp in lTmp)
                c.Add(Tmp);
            return c;
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


        public void ConfirmerTypeEntretien_Intervention()
        {
            if (nAjout == -1)
            {
                C_Intervention AjoutIntervention = new C_Intervention();
                AjoutIntervention = new G_Intervention(chaineConnexion).Lire_ID((int)unTypeEntretien_intervention.interventionId);
                unTypeEntretien_intervention.prixHeure = AjoutIntervention.prixHeure;
                unTypeEntretien_intervention.tva = AjoutIntervention.tva;
                unTypeEntretien_intervention.prix = AjoutIntervention.prixTotal;
                unTypeEntretien_intervention.id = new G_TypeEntretien_Intervention(chaineConnexion).Ajouter(unTypeEntretien_intervention.interventionId, unTypeEntretien_intervention.entretienId,unTypeEntretien_intervention.prixHeure,unTypeEntretien_intervention.prix,unTypeEntretien_intervention.tva);
                bcpTypeEntretiens_interventions.Add(new C_TypeEntretien_Intervention(unTypeEntretien_intervention.id,unTypeEntretien_intervention.interventionId,unTypeEntretien_intervention.entretienId,unTypeEntretien_intervention.prixHeure,unTypeEntretien_intervention.prix,unTypeEntretien_intervention.tva));
            }
            else
            {
                C_Intervention ModificationIntervention = new C_Intervention();
                ModificationIntervention = new G_Intervention(chaineConnexion).Lire_ID((int)unTypeEntretien_intervention.interventionId);
                unTypeEntretien_intervention.prixHeure = ModificationIntervention.prixHeure;
                unTypeEntretien_intervention.tva = ModificationIntervention.tva;
                unTypeEntretien_intervention.prix = ModificationIntervention.prixTotal;

                new G_TypeEntretien_Intervention(chaineConnexion).Modifier(unTypeEntretien_intervention.id, unTypeEntretien_intervention.interventionId, unTypeEntretien_intervention.entretienId, unTypeEntretien_intervention.prixHeure, unTypeEntretien_intervention.prix, unTypeEntretien_intervention.tva);
                bcpTypeEntretiens_interventions[nAjout] = new C_TypeEntretien_Intervention(unTypeEntretien_intervention.id, unTypeEntretien_intervention.interventionId, unTypeEntretien_intervention.entretienId, unTypeEntretien_intervention.prixHeure, unTypeEntretien_intervention.prix, unTypeEntretien_intervention.tva);
            }
            ActiverUneFiche2 = false;
        }

        public void AnnulerTypeEntretien_Intervention()
        {
            ActiverUneFiche2 = false;
        }

        public void AjouterTypeEntretien_Intervention()
        {
            unTypeEntretien_intervention = new VM_UnTypeEntretien_intervention();
            nAjout = -1;
            ActiverUneFiche2 = true;
        }

        public void ModifierTypeEntretien_Intervention()
        {
            if (typeEntretienSelectionnee_intervention != null)
            {
                C_TypeEntretien_Intervention  Tmp = new G_TypeEntretien_Intervention(chaineConnexion).Lire_ID(typeEntretienSelectionnee_intervention.id);
                unTypeEntretien_intervention = new VM_UnTypeEntretien_intervention();
                unTypeEntretien_intervention.id = Tmp.id;
                unTypeEntretien_intervention.interventionId = Tmp.interventionId;
                unTypeEntretien_intervention.entretienId = Tmp.entretienId;
                unTypeEntretien_intervention.prixHeure = Tmp.prixHeure;
                unTypeEntretien_intervention.tva = Tmp.tva;
                unTypeEntretien_intervention.prix = Tmp.prix;
                ActiverUneFiche2 = true;
            }
        }
        public void SupprimerTypeEntretien_Intervention()
        {
            if (typeEntretienSelectionnee_intervention != null)
            {
                new G_TypeEntretien_Intervention(chaineConnexion).Supprimer(typeEntretienSelectionnee_intervention.id);
                bcpTypeEntretiens_interventions.Remove(typeEntretienSelectionnee_intervention);
            }
        }

        public void typeEntretienSelectionnee2UnTypeEntretien()
        {
            unTypeEntretien.id = typeEntretienSelectionnee.id;
            unTypeEntretien.nom = typeEntretienSelectionnee.nom;
            unTypeEntretien.kilometrage = typeEntretienSelectionnee.kilometrage;
        }

        public void typeEntretienSelectionnee_intervention2UnTypeEntretien_intervention()
        {
            unTypeEntretien_intervention.id = typeEntretienSelectionnee_intervention.id;
            unTypeEntretien_intervention.interventionId = typeEntretienSelectionnee_intervention.interventionId;
            unTypeEntretien_intervention.entretienId = typeEntretienSelectionnee_intervention.entretienId;
            unTypeEntretien_intervention.prixHeure = typeEntretienSelectionnee_intervention.prixHeure;
            unTypeEntretien_intervention.tva = typeEntretienSelectionnee_intervention.tva;
            unTypeEntretien_intervention.prix = typeEntretienSelectionnee_intervention.prix;
        }

        public void typeEntretienSelectionnee_piece2UnTypeEntretien_piece()
        {
            unTypeEntretien_piece.id = typeEntretienSelectionnee_piece.id;
            unTypeEntretien_piece.pieceId = typeEntretienSelectionnee_piece.pieceId;
            unTypeEntretien_piece.entretienId = typeEntretienSelectionnee_piece.entretienId;
            unTypeEntretien_piece.quantite = typeEntretienSelectionnee_piece.quantite;
            unTypeEntretien_piece.tva = typeEntretienSelectionnee_piece.tva;
            unTypeEntretien_piece.prix = typeEntretienSelectionnee_piece.prix;
        }

        public void ConfirmerTypeEntretien_Piece()
        {
            if (nAjout == -1)
            {
                C_Piece AjoutPiece = new C_Piece();
                AjoutPiece = new G_Piece(chaineConnexion).Lire_ID((int)unTypeEntretien_piece.pieceId);
                unTypeEntretien_piece.quantite = AjoutPiece.quantite;
                unTypeEntretien_piece.prix = AjoutPiece.prix;
                unTypeEntretien_piece.tva = AjoutPiece.tva;
                unTypeEntretien_piece.id = new G_TypeEntretien_Piece(chaineConnexion).Ajouter(unTypeEntretien_piece.pieceId, unTypeEntretien_piece.entretienId, unTypeEntretien_piece.quantite, unTypeEntretien_piece.prix, unTypeEntretien_piece.tva);
                bcpTypeEntretiens_pieces.Add(new C_TypeEntretien_Piece(unTypeEntretien_piece.id, unTypeEntretien_piece.pieceId, unTypeEntretien_piece.entretienId, unTypeEntretien_piece.quantite, unTypeEntretien_piece.prix, unTypeEntretien_piece.tva));
            }
            else
            {
                C_Piece ModificationPiece = new C_Piece();
                ModificationPiece = new G_Piece(chaineConnexion).Lire_ID((int)unTypeEntretien_piece.pieceId);

                unTypeEntretien_piece.quantite = ModificationPiece.quantite;
                unTypeEntretien_piece.prix = ModificationPiece.prix;
                unTypeEntretien_piece.tva = ModificationPiece.tva;

                new G_TypeEntretien_Piece(chaineConnexion).Modifier(unTypeEntretien_piece.id, unTypeEntretien_piece.pieceId, unTypeEntretien_piece.entretienId, unTypeEntretien_piece.quantite, unTypeEntretien_piece.prix, unTypeEntretien_piece.tva);
                bcpTypeEntretiens_pieces[nAjout] = new C_TypeEntretien_Piece(unTypeEntretien_piece.id, unTypeEntretien_piece.pieceId, unTypeEntretien_piece.entretienId, unTypeEntretien_piece.quantite, unTypeEntretien_piece.prix, unTypeEntretien_piece.tva);
            }
            ActiverUneFiche3 = false;
        }

        public void AnnulerTypeEntretien_Piece()
        {
            ActiverUneFiche3 = false;
        }

        public void AjouterTypeEntretien_Piece()
        {
            unTypeEntretien_piece = new VM_UnTypeEntretien_piece();
            nAjout = -1;
            ActiverUneFiche3 = true;
        }

        public void ModifierTypeEntretien_Piece()
        {
            if (typeEntretienSelectionnee_piece != null)
            {
                C_TypeEntretien_Piece Tmp = new G_TypeEntretien_Piece(chaineConnexion).Lire_ID(typeEntretienSelectionnee_piece.id);
                unTypeEntretien_piece = new VM_UnTypeEntretien_piece();
                unTypeEntretien_piece.id = Tmp.id;
                unTypeEntretien_piece.pieceId = Tmp.pieceId;
                unTypeEntretien_piece.entretienId = Tmp.entretienId;
                unTypeEntretien_piece.quantite = Tmp.quantite;
                unTypeEntretien_piece.tva = Tmp.tva;
                unTypeEntretien_piece.prix = Tmp.prix;
                ActiverUneFiche3 = true;
            }
        }
        public void SupprimerTypeEntretien_Piece()
        {
            if (typeEntretienSelectionnee_piece != null)
            {
                new G_TypeEntretien_Piece(chaineConnexion).Supprimer(typeEntretienSelectionnee_piece.id);
                bcpTypeEntretiens_pieces.Remove(typeEntretienSelectionnee_piece);
            }
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

        public class VM_UnTypeEntretien_intervention : BasePropriete
        {
            private int _id;
            private int? _interventionId;
            private int? _entretienId;
            private double? _prixHeure;
            private double? _prix;
            private double? _tva;

            public int id
            {
                get { return _id; }
                set { AssignerChamp<int>(ref _id, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public int? interventionId
            {
                get { return _interventionId; }
                set { AssignerChamp<int?>(ref _interventionId, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int? entretienId
            {
                get { return _entretienId; }
                set { AssignerChamp<int?>(ref _entretienId, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public double? prixHeure
            {
                get { return _prixHeure; }
                set { AssignerChamp<double?>(ref _prixHeure, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public double? prix
            {
                get { return _prix; }
                set { AssignerChamp<double?>(ref _prix, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public double? tva
            {
                get { return _tva; }
                set { AssignerChamp<double?>(ref _tva, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
        }

        public class VM_UnTypeEntretien_piece : BasePropriete
        {
            private int _id;
            private int? _pieceId;
            private int? _entretienId;
            private int? _quantite;
            private double? _prix;
            private double? _tva;

            public int id
            {
                get { return _id; }
                set { AssignerChamp<int>(ref _id, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public int? pieceId
            {
                get { return _pieceId; }
                set { AssignerChamp<int?>(ref _pieceId, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int? entretienId
            {
                get { return _entretienId; }
                set { AssignerChamp<int?>(ref _entretienId, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int? quantite
            {
                get { return _quantite; }
                set { AssignerChamp<int?>(ref _quantite, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public double? prix
            {
                get { return _prix; }
                set { AssignerChamp<double?>(ref _prix, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public double? tva
            {
                get { return _tva; }
                set { AssignerChamp<double?>(ref _tva, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
        }
    }
}
