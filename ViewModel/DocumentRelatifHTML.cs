using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Projet_Garage.Classes;
using Projet_Garage.Gestion;
using System.IO;

namespace WpfApp_Garage.ViewModel
{
    class VM_DocumentRelatifHTML : BasePropriete
    {
        private string chaineConnexion = ConfigurationManager.ConnectionStrings["WpfApp_Garage.Properties.Settings.chaineConnexionBD"].ConnectionString;
        private DataTable dataTableVehiculesGE;
        private DataTable dataTableVehiculesPE;

        private BindingSource dataVehiculesGE;
        private BindingSource dataVehiculesPE;

        public VM_DocumentRelatifHTML()
        {

        }
        public void genererDocumentHTML()
        {
            dataTableVehiculesGE = new DataTable();
            dataTableVehiculesGE.Columns.Add(new DataColumn("id", System.Type.GetType("System.Int32")));
            dataTableVehiculesGE.Columns.Add(new DataColumn("modele du vehicule"));
            dataTableVehiculesGE.Columns.Add(new DataColumn("nom du client"));
            dataTableVehiculesGE.Columns.Add(new DataColumn("Immatriculation"));
            dataTableVehiculesGE.Columns.Add(new DataColumn("Premiere immatriculation"));
            dataTableVehiculesGE.Columns.Add(new DataColumn("Couleur"));
            dataTableVehiculesGE.Columns.Add(new DataColumn("Kilometrage"));



            List<C_Vehicule> vehiculesGE = new G_Vehicule(chaineConnexion).Lire("id");
            foreach(C_Vehicule v in vehiculesGE)
            {
                C_Client c = new G_Client(chaineConnexion).Lire_ID(Convert.ToInt32(v.clientId));
                C_Modele m = new G_Modele(chaineConnexion).Lire_ID(Convert.ToInt32(v.modeleId));
                if (Convert.ToInt32(v.kilometrage) > 100000)
                    dataTableVehiculesGE.Rows.Add(v.id, m.modele, c.prenom +" "+c.nom, v.immatriculation, Convert.ToDateTime(v.datePremiereImmatriculation).ToString("dd/MM/yyyy"), v.couleur, v.kilometrage + " km");
            }

            dataVehiculesGE = new BindingSource();
            dataVehiculesGE.DataSource = dataTableVehiculesGE;

            dataTableVehiculesPE = new DataTable();
            dataTableVehiculesPE.Columns.Add(new DataColumn("id", System.Type.GetType("System.Int32")));
            dataTableVehiculesPE.Columns.Add(new DataColumn("Modele du vehicule"));
            dataTableVehiculesPE.Columns.Add(new DataColumn("Nom du client"));
            dataTableVehiculesPE.Columns.Add(new DataColumn("Immatriculation"));
            dataTableVehiculesPE.Columns.Add(new DataColumn("Premiere immatriculation"));
            dataTableVehiculesPE.Columns.Add(new DataColumn("Couleur"));
            dataTableVehiculesPE.Columns.Add(new DataColumn("Kilometrage"));

            List<C_Vehicule> vehiculesPE = new G_Vehicule(chaineConnexion).Lire("id");
            foreach (C_Vehicule v in vehiculesPE)
            {
                C_Client c = new G_Client(chaineConnexion).Lire_ID(Convert.ToInt32(v.clientId));
                C_Modele m = new G_Modele(chaineConnexion).Lire_ID(Convert.ToInt32(v.modeleId));
                if (Convert.ToInt32(v.kilometrage) < 100000)
                    dataTableVehiculesPE.Rows.Add(v.id, m.modele, c.prenom + " " + c.nom, v.immatriculation, Convert.ToDateTime(v.datePremiereImmatriculation).ToString("dd/MM/yyyy"), v.couleur, v.kilometrage + " km");
            }

            dataVehiculesPE = new BindingSource();
            dataVehiculesPE.DataSource = dataTableVehiculesPE;

            StringBuilder strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<html>");
            strHTMLBuilder.Append("<head>");
            strHTMLBuilder.Append("</head>");
            strHTMLBuilder.Append("<body>");
            strHTMLBuilder.Append("<h2 style='text-align:center ;f '>Les vehicules qui doivent faire un grand entretien</h1>");
            //strHTMLBuilder.Append("<h1 style='text-align:center ; style='color: blue';font-family:arial; '>voiture </h1>");
            strHTMLBuilder.Append("<table align='center' border='2px' cellpadding='2' cellspacing='1'style=' border: 1px solid #ccc;font-size: 12pt;font-family:arial'>");
            strHTMLBuilder.Append("<tr>");

            foreach (DataColumn colonne in dataTableVehiculesGE.Columns)
            {
                strHTMLBuilder.Append("<td >");
                strHTMLBuilder.Append(colonne.ColumnName);
                strHTMLBuilder.Append("</td>");
            }
            strHTMLBuilder.Append("</tr>");
            foreach (DataRow ligne in dataTableVehiculesGE.Rows)
            {
                
                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn colonne in dataTableVehiculesGE.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(ligne[colonne.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }
            strHTMLBuilder.Append("</table>");

            strHTMLBuilder.Append("<h2 style='text-align:center ;f '>Les vehicules qui doivent faire un petit entretien</h1>");
            //strHTMLBuilder.Append("<h1 style='text-align:center ; style='color: blue';font-family:arial; '>voiture </h1>");
            strHTMLBuilder.Append("<table align='center' border='2px' cellpadding='2' cellspacing='1'style=' border: 1px solid #ccc;font-size: 12pt;font-family:arial'>");
            strHTMLBuilder.Append("<tr>");

            foreach (DataColumn colonne in dataTableVehiculesPE.Columns)
            {
                strHTMLBuilder.Append("<td >");
                strHTMLBuilder.Append(colonne.ColumnName);
                strHTMLBuilder.Append("</td>");
            }
            strHTMLBuilder.Append("</tr>");
            foreach (DataRow ligne in dataTableVehiculesPE.Rows)
            {

                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn colonne in dataTableVehiculesPE.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(ligne[colonne.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }
            strHTMLBuilder.Append("</table>");
            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");
            string Htmltext = strHTMLBuilder.ToString();
            File.WriteAllText(@"C:\Users\adilb\Desktop\projectWPF\WpfApp-Garage\DocumentEntretiens.html", Htmltext);
        }
    }
 }



