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
 public class A_Vehicule : ADBase
 {
  #region Constructeurs
  public A_Vehicule(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int? modeleId, int? clientId, string immatriculation, DateTime? datePremiereImmatriculation, string couleur, Int64? kilometrage)
  {
   CreerCommande("AjouterVehicule");
   int res = 0;
   Commande.Parameters.Add("id", SqlDbType.Int);
   Direction("id", ParameterDirection.Output);
   if(modeleId == null) Commande.Parameters.AddWithValue("@modeleId", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@modeleId", modeleId);
   if(clientId == null) Commande.Parameters.AddWithValue("@clientId", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@clientId", clientId);
   if(immatriculation == null) Commande.Parameters.AddWithValue("@immatriculation", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@immatriculation", immatriculation);
   if(datePremiereImmatriculation == null) Commande.Parameters.AddWithValue("@datePremiereImmatriculation", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@datePremiereImmatriculation", datePremiereImmatriculation);
   if(couleur == null) Commande.Parameters.AddWithValue("@couleur", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@couleur", couleur);
   if(kilometrage == null) Commande.Parameters.AddWithValue("@kilometrage", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@kilometrage", kilometrage);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("id"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int id, int? modeleId, int? clientId, string immatriculation, DateTime? datePremiereImmatriculation, string couleur, Int64? kilometrage)
  {
   CreerCommande("ModifierVehicule");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   if(modeleId == null) Commande.Parameters.AddWithValue("@modeleId", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@modeleId", modeleId);
   if(clientId == null) Commande.Parameters.AddWithValue("@clientId", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@clientId", clientId);
   if(immatriculation == null) Commande.Parameters.AddWithValue("@immatriculation", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@immatriculation", immatriculation);
   if(datePremiereImmatriculation == null) Commande.Parameters.AddWithValue("@datePremiereImmatriculation", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@datePremiereImmatriculation", datePremiereImmatriculation);
   if(couleur == null) Commande.Parameters.AddWithValue("@couleur", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@couleur", couleur);
   if(kilometrage == null) Commande.Parameters.AddWithValue("@kilometrage", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@kilometrage", kilometrage);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_Vehicule> Lire(string Index)
  {
   CreerCommande("SelectionnerVehicule");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_Vehicule> res = new List<C_Vehicule>();
   while (dr.Read())
   {
    C_Vehicule tmp = new C_Vehicule();
    tmp.id = int.Parse(dr["id"].ToString());
   if(dr["modeleId"] != DBNull.Value) tmp.modeleId = int.Parse(dr["modeleId"].ToString());
   if(dr["clientId"] != DBNull.Value) tmp.clientId = int.Parse(dr["clientId"].ToString());
    tmp.immatriculation = dr["immatriculation"].ToString();
   if(dr["datePremiereImmatriculation"] != DBNull.Value) tmp.datePremiereImmatriculation = DateTime.Parse(dr["datePremiereImmatriculation"].ToString());
    tmp.couleur = dr["couleur"].ToString();
   if(dr["kilometrage"] != DBNull.Value) tmp.kilometrage = Int64.Parse(dr["kilometrage"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_Vehicule Lire_ID(int id)
  {
   CreerCommande("SelectionnerVehicule_ID");
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_Vehicule res = new C_Vehicule();
   while (dr.Read())
   {
    res.id = int.Parse(dr["id"].ToString());
   if(dr["modeleId"] != DBNull.Value) res.modeleId = int.Parse(dr["modeleId"].ToString());
   if(dr["clientId"] != DBNull.Value) res.clientId = int.Parse(dr["clientId"].ToString());
    res.immatriculation = dr["immatriculation"].ToString();
   if(dr["datePremiereImmatriculation"] != DBNull.Value) res.datePremiereImmatriculation = DateTime.Parse(dr["datePremiereImmatriculation"].ToString());
    res.couleur = dr["couleur"].ToString();
   if(dr["kilometrage"] != DBNull.Value) res.kilometrage = Int64.Parse(dr["kilometrage"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int id)
  {
   CreerCommande("SupprimerVehicule");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
