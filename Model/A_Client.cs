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
 public class A_Client : ADBase
 {
  #region Constructeurs
  public A_Client(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string nom, string prenom, DateTime? dateNaissance, string adresse, string numeroTelephone, string adresseEmail)
  {
   CreerCommande("AjouterClient");
   int res = 0;
   Commande.Parameters.Add("id", SqlDbType.Int);
   Direction("id", ParameterDirection.Output);
   if(nom == null) Commande.Parameters.AddWithValue("@nom", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@nom", nom);
   if(prenom == null) Commande.Parameters.AddWithValue("@prenom", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@prenom", prenom);
   if(dateNaissance == null) Commande.Parameters.AddWithValue("@dateNaissance", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@dateNaissance", dateNaissance);
   if(adresse == null) Commande.Parameters.AddWithValue("@adresse", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@adresse", adresse);
   if(numeroTelephone == null) Commande.Parameters.AddWithValue("@numeroTelephone", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@numeroTelephone", numeroTelephone);
   if(adresseEmail == null) Commande.Parameters.AddWithValue("@adresseEmail", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@adresseEmail", adresseEmail);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("id"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int id, string nom, string prenom, DateTime? dateNaissance, string adresse, string numeroTelephone, string adresseEmail)
  {
   CreerCommande("ModifierClient");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   if(nom == null) Commande.Parameters.AddWithValue("@nom", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@nom", nom);
   if(prenom == null) Commande.Parameters.AddWithValue("@prenom", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@prenom", prenom);
   if(dateNaissance == null) Commande.Parameters.AddWithValue("@dateNaissance", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@dateNaissance", dateNaissance);
   if(adresse == null) Commande.Parameters.AddWithValue("@adresse", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@adresse", adresse);
   if(numeroTelephone == null) Commande.Parameters.AddWithValue("@numeroTelephone", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@numeroTelephone", numeroTelephone);
   if(adresseEmail == null) Commande.Parameters.AddWithValue("@adresseEmail", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@adresseEmail", adresseEmail);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_Client> Lire(string Index)
  {
   CreerCommande("SelectionnerClient");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_Client> res = new List<C_Client>();
   while (dr.Read())
   {
    C_Client tmp = new C_Client();
    tmp.id = int.Parse(dr["id"].ToString());
    tmp.nom = dr["nom"].ToString();
    tmp.prenom = dr["prenom"].ToString();
   if(dr["dateNaissance"] != DBNull.Value) tmp.dateNaissance = DateTime.Parse(dr["dateNaissance"].ToString());
    tmp.adresse = dr["adresse"].ToString();
    tmp.numeroTelephone = dr["numeroTelephone"].ToString();
    tmp.adresseEmail = dr["adresseEmail"].ToString();
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_Client Lire_ID(int id)
  {
   CreerCommande("SelectionnerClient_ID");
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_Client res = new C_Client();
   while (dr.Read())
   {
    res.id = int.Parse(dr["id"].ToString());
    res.nom = dr["nom"].ToString();
    res.prenom = dr["prenom"].ToString();
   if(dr["dateNaissance"] != DBNull.Value) res.dateNaissance = DateTime.Parse(dr["dateNaissance"].ToString());
    res.adresse = dr["adresse"].ToString();
    res.numeroTelephone = dr["numeroTelephone"].ToString();
    res.adresseEmail = dr["adresseEmail"].ToString();
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int id)
  {
   CreerCommande("SupprimerClient");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
