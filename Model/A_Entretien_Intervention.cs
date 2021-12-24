#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Projet_Garage.Model;
#endregion

namespace Projet_Garage.Acces
{
 /// <summary>
 /// Couche d'accès aux données (Data Access Layer)
 /// </summary>
 public class A_Entretien_Intervention : ADBase
 {
  #region Constructeurs
  public A_Entretien_Intervention(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int? interventionId, int? entretienId, double? prixHeure, double? prix, double? tva)
  {
   CreerCommande("AjouterEntretien_Intervention");
   int res = 0;
   Commande.Parameters.Add("id", SqlDbType.Int);
   Direction("id", ParameterDirection.Output);
   if(interventionId == null) Commande.Parameters.AddWithValue("@interventionId", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@interventionId", interventionId);
   if(entretienId == null) Commande.Parameters.AddWithValue("@entretienId", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@entretienId", entretienId);
   if(prixHeure == null) Commande.Parameters.AddWithValue("@prixHeure", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@prixHeure", prixHeure);
   if(prix == null) Commande.Parameters.AddWithValue("@prix", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@prix", prix);
   if(tva == null) Commande.Parameters.AddWithValue("@tva", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@tva", tva);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("id"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int id, int? interventionId, int? entretienId, double? prixHeure, double? prix, double? tva)
  {
   CreerCommande("ModifierEntretien_Intervention");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   if(interventionId == null) Commande.Parameters.AddWithValue("@interventionId", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@interventionId", interventionId);
   if(entretienId == null) Commande.Parameters.AddWithValue("@entretienId", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@entretienId", entretienId);
   if(prixHeure == null) Commande.Parameters.AddWithValue("@prixHeure", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@prixHeure", prixHeure);
   if(prix == null) Commande.Parameters.AddWithValue("@prix", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@prix", prix);
   if(tva == null) Commande.Parameters.AddWithValue("@tva", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@tva", tva);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_Entretien_Intervention> Lire(string Index)
  {
   CreerCommande("SelectionnerEntretien_Intervention");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_Entretien_Intervention> res = new List<C_Entretien_Intervention>();
   while (dr.Read())
   {
    C_Entretien_Intervention tmp = new C_Entretien_Intervention();
    tmp.id = int.Parse(dr["id"].ToString());
   if(dr["interventionId"] != DBNull.Value) tmp.interventionId = int.Parse(dr["interventionId"].ToString());
   if(dr["entretienId"] != DBNull.Value) tmp.entretienId = int.Parse(dr["entretienId"].ToString());
   if(dr["prixHeure"] != DBNull.Value) tmp.prixHeure = double.Parse(dr["prixHeure"].ToString());
   if(dr["prix"] != DBNull.Value) tmp.prix = double.Parse(dr["prix"].ToString());
   if(dr["tva"] != DBNull.Value) tmp.tva = double.Parse(dr["tva"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_Entretien_Intervention Lire_ID(int id)
  {
   CreerCommande("SelectionnerEntretien_Intervention_ID");
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_Entretien_Intervention res = new C_Entretien_Intervention();
   while (dr.Read())
   {
    res.id = int.Parse(dr["id"].ToString());
   if(dr["interventionId"] != DBNull.Value) res.interventionId = int.Parse(dr["interventionId"].ToString());
   if(dr["entretienId"] != DBNull.Value) res.entretienId = int.Parse(dr["entretienId"].ToString());
   if(dr["prixHeure"] != DBNull.Value) res.prixHeure = double.Parse(dr["prixHeure"].ToString());
   if(dr["prix"] != DBNull.Value) res.prix = double.Parse(dr["prix"].ToString());
   if(dr["tva"] != DBNull.Value) res.tva = double.Parse(dr["tva"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int id)
  {
   CreerCommande("SupprimerEntretien_Intervention");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
