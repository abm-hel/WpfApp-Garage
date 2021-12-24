#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using Projet_Garage.Model;
using Projet_Garage.Acces;
#endregion

namespace Projet_Garage.Gestion
{
 /// <summary>
 /// Couche intermédiaire de gestion (Business Layer)
 /// </summary>
 public class G_Piece : G_Base
 {
  #region Constructeurs
  public G_Piece()
   : base()
  { }
  public G_Piece(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string nom, string fabricant, double? prix, double? tva, int? quantite)
  { return new A_Piece(ChaineConnexion).Ajouter(nom, fabricant, prix, tva, quantite); }
  public int Modifier(int id, string nom, string fabricant, double? prix, double? tva, int? quantite)
  { return new A_Piece(ChaineConnexion).Modifier(id, nom, fabricant, prix, tva, quantite); }
  public List<C_Piece> Lire(string Index)
  { return new A_Piece(ChaineConnexion).Lire(Index); }
  public C_Piece Lire_ID(int id)
  { return new A_Piece(ChaineConnexion).Lire_ID(id); }
  public int Supprimer(int id)
  { return new A_Piece(ChaineConnexion).Supprimer(id); }
 }
}
