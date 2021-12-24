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
 public class G_Intervention : G_Base
 {
  #region Constructeurs
  public G_Intervention()
   : base()
  { }
  public G_Intervention(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string description, int? nombreHeures, double? prixHeure, double? tva, double? prixTotal)
  { return new A_Intervention(ChaineConnexion).Ajouter(description, nombreHeures, prixHeure, tva, prixTotal); }
  public int Modifier(int id, string description, int? nombreHeures, double? prixHeure, double? tva, double? prixTotal)
  { return new A_Intervention(ChaineConnexion).Modifier(id, description, nombreHeures, prixHeure, tva, prixTotal); }
  public List<C_Intervention> Lire(string Index)
  { return new A_Intervention(ChaineConnexion).Lire(Index); }
  public C_Intervention Lire_ID(int id)
  { return new A_Intervention(ChaineConnexion).Lire_ID(id); }
  public int Supprimer(int id)
  { return new A_Intervention(ChaineConnexion).Supprimer(id); }
 }
}
