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
    class VM_ChiffreAffaire : BasePropriete
    {
        private string chaineConnexion = ConfigurationManager.ConnectionStrings["WpfApp_Garage.Properties.Settings.chaineConnexionBD"].ConnectionString;
        public BaseCommande commandeCalculerChiffreAffaires { get; set; }

        public VM_ChiffreAffaire()
        {
            commandeCalculerChiffreAffaires = new BaseCommande(ChiffreAffaire);
            DateDebutSemaine = DateTime.Now.AddDays(-7);
        }

        private string _LeChiffreAffaires;
        public string LeChiffreAffaires
        {
            get { return _LeChiffreAffaires; }
            set { AssignerChamp<string>(ref _LeChiffreAffaires, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private DateTime _DateDebutSemaine;
        public DateTime DateDebutSemaine
        {
            get { return _DateDebutSemaine; }
            set { AssignerChamp<DateTime>(ref _DateDebutSemaine, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        public void ChiffreAffaire()
        {
            DateTime date = DateDebutSemaine;
            double chiffre = 0;

            List<C_Entretien_Intervention> interventionsEffectuees = new G_Entretien_Intervention(chaineConnexion).Lire("id");

            foreach (C_Entretien_Intervention intervention  in interventionsEffectuees)
            {
                C_Entretien entretien = new G_Entretien(chaineConnexion).Lire_ID(Convert.ToInt32(intervention.entretienId));
               for (int i = 0; i < 7; i++)
               {
                  if (Convert.ToDateTime(entretien.datePassage).Date == date.AddDays(i).Date)
                  {
                        chiffre = chiffre + Convert.ToDouble(intervention.prix);
                  }
               }
            }

            List<C_Entretien_Piece> piecesVendues = new G_Entretien_Piece(chaineConnexion).Lire("id");

            foreach (C_Entretien_Piece piece in piecesVendues)
            {
                C_Entretien entretien = new G_Entretien(chaineConnexion).Lire_ID(Convert.ToInt32(piece.entretienId));
                for (int i = 0; i < 7; i++)
                {
                    if (Convert.ToDateTime(entretien.datePassage).Date == date.AddDays(i).Date)
                    {
                        chiffre = chiffre + Convert.ToDouble(piece.prix*piece.quantite);
                    }
                }
            }

            LeChiffreAffaires = string.Format("{0:0.00}", chiffre) + " €";
        }


    }

    
}
