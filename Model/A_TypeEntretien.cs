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
 public class A_TypeEntretien : ADBase
 {
  #region Constructeurs
  public A_TypeEntretien(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string nom, Int64 kilometrage)
  {
   CreerCommande("AjouterTypeEntretien");
   int res = 0;
   Commande.Parameters.Add("id", SqlDbType.Int);
   Direction("id", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@nom", nom);
   Commande.Parameters.AddWithValue("@kilometrage", kilometrage);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("id"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int id, string nom, Int64 kilometrage)
  {
   CreerCommande("ModifierTypeEntretien");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Parameters.AddWithValue("@nom", nom);
   Commande.Parameters.AddWithValue("@kilometrage", kilometrage);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_TypeEntretien> Lire(string Index)
  {
   CreerCommande("SelectionnerTypeEntretien");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_TypeEntretien> res = new List<C_TypeEntretien>();
   while (dr.Read())
   {
    C_TypeEntretien tmp = new C_TypeEntretien();
    tmp.id = int.Parse(dr["id"].ToString());
    tmp.nom = dr["nom"].ToString();
    tmp.kilometrage = Int64.Parse(dr["kilometrage"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_TypeEntretien Lire_ID(int id)
  {
   CreerCommande("SelectionnerTypeEntretien_ID");
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_TypeEntretien res = new C_TypeEntretien();
   while (dr.Read())
   {
    res.id = int.Parse(dr["id"].ToString());
    res.nom = dr["nom"].ToString();
    res.kilometrage = Int64.Parse(dr["kilometrage"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int id)
  {
   CreerCommande("SupprimerTypeEntretien");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
