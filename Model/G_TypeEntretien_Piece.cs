#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using Projet_Garage.Classes;
using Projet_Garage.Acces;
#endregion

namespace Projet_Garage.Gestion
{
 /// <summary>
 /// Couche intermédiaire de gestion (Business Layer)
 /// </summary>
 public class G_TypeEntretien_Piece : G_Base
 {
  #region Constructeurs
  public G_TypeEntretien_Piece()
   : base()
  { }
  public G_TypeEntretien_Piece(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int? pieceId, int? entretienId, int? quantite, double? prix, double? tva)
  { return new A_TypeEntretien_Piece(ChaineConnexion).Ajouter(pieceId, entretienId, quantite, prix, tva); }
  public int Modifier(int id, int? pieceId, int? entretienId, int? quantite, double? prix, double? tva)
  { return new A_TypeEntretien_Piece(ChaineConnexion).Modifier(id, pieceId, entretienId, quantite, prix, tva); }
  public List<C_TypeEntretien_Piece> Lire(string Index)
  { return new A_TypeEntretien_Piece(ChaineConnexion).Lire(Index); }
  public C_TypeEntretien_Piece Lire_ID(int id)
  { return new A_TypeEntretien_Piece(ChaineConnexion).Lire_ID(id); }
  public int Supprimer(int id)
  { return new A_TypeEntretien_Piece(ChaineConnexion).Supprimer(id); }
 }
}
