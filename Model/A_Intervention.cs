#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Projet_Garage.Classes;
#endregion

namespace Projet_Garage.Acces
{
 /// <summary>
 /// Couche d'accès aux données (Data Access Layer)
 /// </summary>
 public class A_Intervention : ADBase
 {
  #region Constructeurs
  public A_Intervention(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string description, int? nombreHeures, double? prixHeure, double? tva, double? prixTotal)
  {
   CreerCommande("AjouterIntervention");
   int res = 0;
   Commande.Parameters.Add("id", SqlDbType.Int);
   Direction("id", ParameterDirection.Output);
   if(description == null) Commande.Parameters.AddWithValue("@description", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@description", description);
   if(nombreHeures == null) Commande.Parameters.AddWithValue("@nombreHeures", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@nombreHeures", nombreHeures);
   if(prixHeure == null) Commande.Parameters.AddWithValue("@prixHeure", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@prixHeure", prixHeure);
   if(tva == null) Commande.Parameters.AddWithValue("@tva", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@tva", tva);
   if(prixTotal == null) Commande.Parameters.AddWithValue("@prixTotal", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@prixTotal", prixTotal);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("id"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int id, string description, int? nombreHeures, double? prixHeure, double? tva, double? prixTotal)
  {
   CreerCommande("ModifierIntervention");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   if(description == null) Commande.Parameters.AddWithValue("@description", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@description", description);
   if(nombreHeures == null) Commande.Parameters.AddWithValue("@nombreHeures", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@nombreHeures", nombreHeures);
   if(prixHeure == null) Commande.Parameters.AddWithValue("@prixHeure", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@prixHeure", prixHeure);
   if(tva == null) Commande.Parameters.AddWithValue("@tva", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@tva", tva);
   if(prixTotal == null) Commande.Parameters.AddWithValue("@prixTotal", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@prixTotal", prixTotal);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_Intervention> Lire(string Index)
  {
   CreerCommande("SelectionnerIntervention");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_Intervention> res = new List<C_Intervention>();
   while (dr.Read())
   {
    C_Intervention tmp = new C_Intervention();
    tmp.id = int.Parse(dr["id"].ToString());
    tmp.description = dr["description"].ToString();
   if(dr["nombreHeures"] != DBNull.Value) tmp.nombreHeures = int.Parse(dr["nombreHeures"].ToString());
   if(dr["prixHeure"] != DBNull.Value) tmp.prixHeure = double.Parse(dr["prixHeure"].ToString());
   if(dr["tva"] != DBNull.Value) tmp.tva = double.Parse(dr["tva"].ToString());
   if(dr["prixTotal"] != DBNull.Value) tmp.prixTotal = double.Parse(dr["prixTotal"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_Intervention Lire_ID(int id)
  {
   CreerCommande("SelectionnerIntervention_ID");
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_Intervention res = new C_Intervention();
   while (dr.Read())
   {
    res.id = int.Parse(dr["id"].ToString());
    res.description = dr["description"].ToString();
   if(dr["nombreHeures"] != DBNull.Value) res.nombreHeures = int.Parse(dr["nombreHeures"].ToString());
   if(dr["prixHeure"] != DBNull.Value) res.prixHeure = double.Parse(dr["prixHeure"].ToString());
   if(dr["tva"] != DBNull.Value) res.tva = double.Parse(dr["tva"].ToString());
   if(dr["prixTotal"] != DBNull.Value) res.prixTotal = double.Parse(dr["prixTotal"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int id)
  {
   CreerCommande("SupprimerIntervention");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
