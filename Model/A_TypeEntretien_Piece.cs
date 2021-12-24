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
 public class A_TypeEntretien_Piece : ADBase
 {
  #region Constructeurs
  public A_TypeEntretien_Piece(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int? pieceId, int? entretienId, int? quantite, double? prix, double? tva)
  {
   CreerCommande("AjouterTypeEntretien_Piece");
   int res = 0;
   Commande.Parameters.Add("id", SqlDbType.Int);
   Direction("id", ParameterDirection.Output);
   if(pieceId == null) Commande.Parameters.AddWithValue("@pieceId", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@pieceId", pieceId);
   if(entretienId == null) Commande.Parameters.AddWithValue("@entretienId", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@entretienId", entretienId);
   if(quantite == null) Commande.Parameters.AddWithValue("@quantite", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@quantite", quantite);
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
  public int Modifier(int id, int? pieceId, int? entretienId, int? quantite, double? prix, double? tva)
  {
   CreerCommande("ModifierTypeEntretien_Piece");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   if(pieceId == null) Commande.Parameters.AddWithValue("@pieceId", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@pieceId", pieceId);
   if(entretienId == null) Commande.Parameters.AddWithValue("@entretienId", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@entretienId", entretienId);
   if(quantite == null) Commande.Parameters.AddWithValue("@quantite", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@quantite", quantite);
   if(prix == null) Commande.Parameters.AddWithValue("@prix", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@prix", prix);
   if(tva == null) Commande.Parameters.AddWithValue("@tva", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@tva", tva);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_TypeEntretien_Piece> Lire(string Index)
  {
   CreerCommande("SelectionnerTypeEntretien_Piece");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_TypeEntretien_Piece> res = new List<C_TypeEntretien_Piece>();
   while (dr.Read())
   {
    C_TypeEntretien_Piece tmp = new C_TypeEntretien_Piece();
    tmp.id = int.Parse(dr["id"].ToString());
   if(dr["pieceId"] != DBNull.Value) tmp.pieceId = int.Parse(dr["pieceId"].ToString());
   if(dr["entretienId"] != DBNull.Value) tmp.entretienId = int.Parse(dr["entretienId"].ToString());
   if(dr["quantite"] != DBNull.Value) tmp.quantite = int.Parse(dr["quantite"].ToString());
   if(dr["prix"] != DBNull.Value) tmp.prix = double.Parse(dr["prix"].ToString());
   if(dr["tva"] != DBNull.Value) tmp.tva = double.Parse(dr["tva"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_TypeEntretien_Piece Lire_ID(int id)
  {
   CreerCommande("SelectionnerTypeEntretien_Piece_ID");
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_TypeEntretien_Piece res = new C_TypeEntretien_Piece();
   while (dr.Read())
   {
    res.id = int.Parse(dr["id"].ToString());
   if(dr["pieceId"] != DBNull.Value) res.pieceId = int.Parse(dr["pieceId"].ToString());
   if(dr["entretienId"] != DBNull.Value) res.entretienId = int.Parse(dr["entretienId"].ToString());
   if(dr["quantite"] != DBNull.Value) res.quantite = int.Parse(dr["quantite"].ToString());
   if(dr["prix"] != DBNull.Value) res.prix = double.Parse(dr["prix"].ToString());
   if(dr["tva"] != DBNull.Value) res.tva = double.Parse(dr["tva"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int id)
  {
   CreerCommande("SupprimerTypeEntretien_Piece");
   int res = 0;
   Commande.Parameters.AddWithValue("@id", id);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
