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
 public class A_Piece : ADBase
 {
  #region Constructeurs
  public A_Piece(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string nom, string fabricant, double? prix, double? tva, int? quantite)
  {
   CreerCommande("AjouterPiece");
   int res = 0;
   Commande.Parameters.Add("id", SqlDbType.Int);
   Direction("id", ParameterDirection.Output);
   if(nom == null) Commande.Parameters.AddWithValue("@nom", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@nom", nom);
   if(fabricant == null) Commande.Parameters.AddWithValue("@fabricant", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@fabricant", fabricant);
   if(prix == null) Commande.Parameters.AddWithValue("@prix", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@prix", prix);
   if(tva == null) Commande.Parameters.AddWithValue("@tva", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@tva", tva);
   if(quantite == null) Commande.Parameters.AddWithValue("@quantite", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@quantite", quantite);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("id"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int id, string nom, string fabricant, double? prix, double? tva, int? quantite)
  {
   CreerCommande("ModifierPiece");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   if(nom == null) Commande.Parameters.AddWithValue("@nom", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@nom", nom);
   if(fabricant == null) Commande.Parameters.AddWithValue("@fabricant", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@fabricant", fabricant);
   if(prix == null) Commande.Parameters.AddWithValue("@prix", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@prix", prix);
   if(tva == null) Commande.Parameters.AddWithValue("@tva", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@tva", tva);
   if(quantite == null) Commande.Parameters.AddWithValue("@quantite", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@quantite", quantite);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_Piece> Lire(string Index)
  {
   CreerCommande("SelectionnerPiece");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_Piece> res = new List<C_Piece>();
   while (dr.Read())
   {
    C_Piece tmp = new C_Piece();
    tmp.id = int.Parse(dr["id"].ToString());
    tmp.nom = dr["nom"].ToString();
    tmp.fabricant = dr["fabricant"].ToString();
   if(dr["prix"] != DBNull.Value) tmp.prix = double.Parse(dr["prix"].ToString());
   if(dr["tva"] != DBNull.Value) tmp.tva = double.Parse(dr["tva"].ToString());
   if(dr["quantite"] != DBNull.Value) tmp.quantite = int.Parse(dr["quantite"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_Piece Lire_ID(int id)
  {
   CreerCommande("SelectionnerPiece_ID");
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_Piece res = new C_Piece();
   while (dr.Read())
   {
    res.id = int.Parse(dr["id"].ToString());
    res.nom = dr["nom"].ToString();
    res.fabricant = dr["fabricant"].ToString();
   if(dr["prix"] != DBNull.Value) res.prix = double.Parse(dr["prix"].ToString());
   if(dr["tva"] != DBNull.Value) res.tva = double.Parse(dr["tva"].ToString());
   if(dr["quantite"] != DBNull.Value) res.quantite = int.Parse(dr["quantite"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int id)
  {
   CreerCommande("SupprimerPiece");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
