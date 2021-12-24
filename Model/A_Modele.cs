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
 public class A_Modele : ADBase
 {
  #region Constructeurs
  public A_Modele(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string modele, string motorisation, string carburant, int? cylindree, int? puissance, double? consommation, int? poids)
  {
   CreerCommande("AjouterModele");
   int res = 0;
   Commande.Parameters.Add("id", SqlDbType.Int);
   Direction("id", ParameterDirection.Output);
   if(modele == null) Commande.Parameters.AddWithValue("@modele", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@modele", modele);
   if(motorisation == null) Commande.Parameters.AddWithValue("@motorisation", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@motorisation", motorisation);
   if(carburant == null) Commande.Parameters.AddWithValue("@carburant", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@carburant", carburant);
   if(cylindree == null) Commande.Parameters.AddWithValue("@cylindree", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@cylindree", cylindree);
   if(puissance == null) Commande.Parameters.AddWithValue("@puissance", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@puissance", puissance);
   if(consommation == null) Commande.Parameters.AddWithValue("@consommation", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@consommation", consommation);
   if(poids == null) Commande.Parameters.AddWithValue("@poids", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@poids", poids);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("id"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int id, string modele, string motorisation, string carburant, int? cylindree, int? puissance, double? consommation, int? poids)
  {
   CreerCommande("ModifierModele");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   if(modele == null) Commande.Parameters.AddWithValue("@modele", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@modele", modele);
   if(motorisation == null) Commande.Parameters.AddWithValue("@motorisation", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@motorisation", motorisation);
   if(carburant == null) Commande.Parameters.AddWithValue("@carburant", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@carburant", carburant);
   if(cylindree == null) Commande.Parameters.AddWithValue("@cylindree", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@cylindree", cylindree);
   if(puissance == null) Commande.Parameters.AddWithValue("@puissance", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@puissance", puissance);
   if(consommation == null) Commande.Parameters.AddWithValue("@consommation", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@consommation", consommation);
   if(poids == null) Commande.Parameters.AddWithValue("@poids", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@poids", poids);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_Modele> Lire(string Index)
  {
   CreerCommande("SelectionnerModele");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_Modele> res = new List<C_Modele>();
   while (dr.Read())
   {
    C_Modele tmp = new C_Modele();
    tmp.id = int.Parse(dr["id"].ToString());
    tmp.modele = dr["modele"].ToString();
    tmp.motorisation = dr["motorisation"].ToString();
    tmp.carburant = dr["carburant"].ToString();
   if(dr["cylindree"] != DBNull.Value) tmp.cylindree = int.Parse(dr["cylindree"].ToString());
   if(dr["puissance"] != DBNull.Value) tmp.puissance = int.Parse(dr["puissance"].ToString());
   if(dr["consommation"] != DBNull.Value) tmp.consommation = double.Parse(dr["consommation"].ToString());
   if(dr["poids"] != DBNull.Value) tmp.poids = int.Parse(dr["poids"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_Modele Lire_ID(int id)
  {
   CreerCommande("SelectionnerModele_ID");
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_Modele res = new C_Modele();
   while (dr.Read())
   {
    res.id = int.Parse(dr["id"].ToString());
    res.modele = dr["modele"].ToString();
    res.motorisation = dr["motorisation"].ToString();
    res.carburant = dr["carburant"].ToString();
   if(dr["cylindree"] != DBNull.Value) res.cylindree = int.Parse(dr["cylindree"].ToString());
   if(dr["puissance"] != DBNull.Value) res.puissance = int.Parse(dr["puissance"].ToString());
   if(dr["consommation"] != DBNull.Value) res.consommation = double.Parse(dr["consommation"].ToString());
   if(dr["poids"] != DBNull.Value) res.poids = int.Parse(dr["poids"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int id)
  {
   CreerCommande("SupprimerModele");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
