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
 public class A_Entretien : ADBase
 {
  #region Constructeurs
  public A_Entretien(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int? vehiculeId, DateTime? datePassage)
  {
   CreerCommande("AjouterEntretien");
   int res = 0;
   Commande.Parameters.Add("id", SqlDbType.Int);
   Direction("id", ParameterDirection.Output);
   if(vehiculeId == null) Commande.Parameters.AddWithValue("@vehiculeId", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@vehiculeId", vehiculeId);
   if(datePassage == null) Commande.Parameters.AddWithValue("@datePassage", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@datePassage", datePassage);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("id"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int id, int? vehiculeId, DateTime? datePassage)
  {
   CreerCommande("ModifierEntretien");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   if(vehiculeId == null) Commande.Parameters.AddWithValue("@vehiculeId", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@vehiculeId", vehiculeId);
   if(datePassage == null) Commande.Parameters.AddWithValue("@datePassage", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@datePassage", datePassage);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_Entretien> Lire(string Index)
  {
   CreerCommande("SelectionnerEntretien");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_Entretien> res = new List<C_Entretien>();
   while (dr.Read())
   {
    C_Entretien tmp = new C_Entretien();
    tmp.id = int.Parse(dr["id"].ToString());
   if(dr["vehiculeId"] != DBNull.Value) tmp.vehiculeId = int.Parse(dr["vehiculeId"].ToString());
   if(dr["datePassage"] != DBNull.Value) tmp.datePassage = DateTime.Parse(dr["datePassage"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_Entretien Lire_ID(int id)
  {
   CreerCommande("SelectionnerEntretien_ID");
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_Entretien res = new C_Entretien();
   while (dr.Read())
   {
    res.id = int.Parse(dr["id"].ToString());
   if(dr["vehiculeId"] != DBNull.Value) res.vehiculeId = int.Parse(dr["vehiculeId"].ToString());
   if(dr["datePassage"] != DBNull.Value) res.datePassage = DateTime.Parse(dr["datePassage"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int id)
  {
   CreerCommande("SupprimerEntretien");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
